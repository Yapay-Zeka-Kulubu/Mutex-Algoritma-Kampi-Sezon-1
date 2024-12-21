using libraryApp.backend.Dtos;
using libraryApp.backend.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libraryApp.backend.Entity;
using Org.BouncyCastle.Crypto.Generators;
using Microsoft.AspNetCore.Authorization;
using System.Linq;


namespace libraryApp.backend.Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IRegisterRequestRepository _registerRequestRepository;

        public AccountController(IUserRepository userRepo, IRegisterRequestRepository registerRequestRepository)
        {
            _userRepo = userRepo;
            _registerRequestRepository = registerRequestRepository;
        }

        [HttpPost("Login")]
        [AllowAnonymous]

        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await _userRepo.GetAllUsersAsync.Include(u => u.RegisterRequests).Include(u => u.Role).Where(u => u.RegisterRequests.Any(rr => rr.confirmation)).FirstOrDefaultAsync(u => u.username == loginDto.username);
            if (user == null)//acık şifre kontrolü 
                return NotFound(new { message = "Username could not found" });
            if (user.password != loginDto.password)
                return BadRequest(new { Message = "password is incorrect" });


            // if (!BCrypt.Net.BCrypt.Verify(loginDto.password, user.password)) return StatusCode(401, new { message = "Password is not correct" });

            UserDto userDto = new UserDto
            {
                id = user.id,
                roleId = user.roleId,
                name = user.name,
                surname = user.surname,
                email = user.email,
                username = user.username,
                userStatus = user.userStatus,
                roleName = user.Role.name,
            };

            //  string token = GenerateJWT(user);

            return Ok(new
            {
                userDTO = userDto
                // token = token,
            });
        }

        [HttpPost("Register")]
        [AllowAnonymous]

        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (_userRepo.GetAllUsersAsync.Any(u => u.username == registerDto.username)) return BadRequest("This username already exits.");

            var user = new User
            {
                roleId = 1,
                name = registerDto.name,
                surname = registerDto.surname,
                username = registerDto.username,
                email = registerDto.email,
                password = registerDto.password, //=BCrypt.Net.BCrypt.HashPassword(registerDto.password)
                userStatus = false,

            };
            await _userRepo.CreateUserAsync(user);

            await _registerRequestRepository.CreateRegisterRequestAsync(new RegisterRequest{
                userId = user.id,
                requestDate = DateOnly.FromDateTime(DateTime.Now),
                pending = true,
                confirmation = false,
            });
            return Ok(new { message = "User registered" });


        }


        //Bu kısımda GenereteJwt var bak buna 



        [HttpGet("getaccountcreationrequests")]

        public async Task<ActionResult<List<RegisterRequest>>> GetAccountCreationRequests()
        {
            var requests = await _registerRequestRepository.GetAllRegisterRequestsAsync.Include(rra => rra.User).Where(r => r.pending == true).ToListAsync();//Iregisterrequest ile bağdaşacak
            var reqDTOS = requests.Select(r => new AccountCreationReqDTO
            {
                Id = r.id,
                FullName = r.User.name + " "+ r.User.surname,
                Username = r.User.username,
                RequestDate = r.requestDate,
            });
            return Ok(reqDTOS);
        }

        [HttpPut("setaccountcreationrequest")]
        public async Task<IActionResult> SetAccountCreationRequest(UserRegisterDto userRequestDto)
        {

            var request = await _registerRequestRepository.GetAllRegisterRequestsAsync.FirstOrDefaultAsync(r => r.id == userRequestDto.requestId);
            if (request == null) return NotFound( new {Message="Rejected"});//404 gibi
            request.pending = false;
            request.confirmation = userRequestDto.isApproved;
            await _registerRequestRepository.UpdateAsync(request);
            return Ok(new {Message=" Approved"}); //201
        }

    }
}
