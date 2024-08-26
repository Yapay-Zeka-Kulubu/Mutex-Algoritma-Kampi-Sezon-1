using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstack_library.DTO;
using LibraryApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using LibraryApp.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace fullstack_library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        readonly IConfiguration _config;

        public AccountController(IUserRepository userRepo, IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        //TODO make every action method async Task<>

        [HttpPost("Login")]
        [AllowAnonymous]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var user = _userRepo.Users.Include(u => u.Role).FirstOrDefault(u => u.Username == loginDTO.Username);
            if (user == null) return NotFound(new { message = "Username not found" });
            if (user.Password != loginDTO.Password) return StatusCode(401, new { message = "Password is incorrect" });

            //TODO return with jwt
            UserDTO userDTO = new UserDTO
            {
                Id = user.Id,
                RoleId = user.RoleId,
                RoleName = user.Role.Name,
                Name = user.Name,
                Surname = user.Surname,
                Gender = user.Gender,
                BirthDate = user.BirthDate,
                FineAmount = user.FineAmount,
                IsPunished = user.IsPunished,
                Username = user.Username,
            };

            string token = GenerateJWT(user);

            return Ok(new
            {
                userDTO = userDTO,
                token = token,
            });
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            _userRepo.CreateUser(new User
            {
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                Username = registerDTO.Username,
                Password = registerDTO.Password,
                BirthDate = registerDTO.BirthDate,
                Gender = registerDTO.Gender,
                RoleId = 1,
            });
            return Ok(new { message = "User registered" });
        }

        private string GenerateJWT(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Secret").Value ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim("userId", user.Id.ToString()),
                    new Claim("roleId", user.RoleId.ToString()),
                    new Claim("roleName", user.Role.Name.ToString()),
                    new Claim("name", user.Name.ToString()),
                    new Claim("surname", user.Surname.ToString()),
                    new Claim("gender", user.Gender.ToString()),
                    new Claim("birthdate", user.BirthDate.ToString()),
                    new Claim("fineAmount", user.FineAmount.ToString()),
                    new Claim("isPunished", user.IsPunished.ToString()),
                    new Claim("username", user.Username.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}