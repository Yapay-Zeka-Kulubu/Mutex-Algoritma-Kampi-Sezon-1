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
using BCrypt.Net;
using LibraryApp.WebAPI.Utils;

namespace fullstack_library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly ISettingRepository _settingRepo;

        readonly IConfiguration _config;

        public AccountController(IUserRepository userRepo, IConfiguration config, ISettingRepository settingRepository)
        {
            _userRepo = userRepo;
            _config = config;
            _settingRepo = settingRepository;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            //checks if user found with the surname and if found checks password
            var user = await _userRepo.Users.Include(u => u.Role).FirstOrDefaultAsync(u => u.Username == loginDTO.Username);
            if (user == null) return NotFound(new { message = "Username not found" });
            if (!BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.Password)) return StatusCode(401, new { message = "Password is incorrect" });

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

            //returns userdata with generated jwt
            return Ok(new
            {
                userDTO = userDTO,
                token = token,
            });
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (_userRepo.Users.Any(u => u.Username == registerDTO.Username)) return BadRequest(new {Message="Username already exits"});

            await _userRepo.CreateUserAsync(new User
            {
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                Username = registerDTO.Username,
                Password = BCrypt.Net.BCrypt.HashPassword(registerDTO.Password),
                BirthDate = registerDTO.BirthDate,
                Gender = registerDTO.Gender,
                RoleId = 1,
                AccountCreationDate = DateTime.UtcNow,
            });
            return Ok(new { message = "User registered" });
        }

        private string GenerateJWT(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config.GetSection("AppSettings:Secret").Value ?? "");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity([
                    new Claim("roleName", user.Role.Name.ToString()),
                    new Claim("isPunished", user.IsPunished.ToString()),
                ]),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}