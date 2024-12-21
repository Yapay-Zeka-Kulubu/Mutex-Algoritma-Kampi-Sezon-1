using libraryApp.backend.Repository.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using libraryApp.backend.Entity;
using libraryApp.backend.Dtos;
using Microsoft.AspNetCore.Authorization;
using libraryApp.backend.Repository.Concrete;

namespace libraryApp.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepo;
        private readonly IRoleRepository _roleRepo;
        private readonly IPunishRepository _punishRepo;


        public UserController(IRoleRepository roleRepo, IUserRepository userRepo, IPunishRepository punishRepo)
        {
            _userRepo = userRepo;
            _roleRepo = roleRepo;
            _punishRepo = punishRepo;
        }

        [HttpPut("ChangeRole")]
        //[Authorize(Policy="ManagerPolicy")]
        //[Authorize(Policy="NotPunishedPolicy")]

        public async Task<IActionResult> ChangeRole(ChangeRoleDto changeRoleDto)
        {
            var user = await _userRepo.GetUseridAsync(changeRoleDto.userId);
            if (user == null)
                return NotFound(new { Message = "User could not found" });
            //Manager olduğunu düşünelim
            //if (user.RoleId == 5) return BadRequest(new { Message = "You cannot change the role of this user." });  //id 5 managerdan geliyormus            if (!_roleRepo.Roles.Any(r => r.id == changeRoleDto.newRoleId))
            if (!_roleRepo.GetAllRolesAsync.Any(r => r.id == changeRoleDto.newRoleId))
                return NotFound(new { Message = "Role could not found" });

            user.roleId = changeRoleDto.newRoleId;
            await _userRepo.UpdateUserAsync(user);
            return Ok(new { Message = "User's role changed" });

        }

        [HttpPut("SetPunishment")]
        //[Authorize(Policy = "StaffOrManagerPolicy")]
        //[Authorize(Policy = "NotPunishedPolicy")]

        public async Task<IActionResult> SetPunishment(PunishDto punishDto)
        {
            if (punishDto.isPunish)  //update create dahil fronttan alınıyor
            {
                if (!_userRepo.GetAllUsersAsync.Any(u => u.id == punishDto.punisherId))
                    return NotFound(new { message = "Punisher could not found." });
                var punish = new Punishment
                {
                    userId = punishDto.userId,
                    punishmentDate = DateOnly.FromDateTime(DateTime.Now), //Buna bak
                    isActive = punishDto.isPunish,
                    fineAmount = punishDto.fineAmount,

                };
                await _punishRepo.CreatePunishAsync(punish);
            }
            else //caza aktif ama ceza kalmısşsa onun aktifliğini döndürüyor
            {
                var punishment = await _punishRepo.GetAllPunishmentsAsync.FirstOrDefaultAsync(p => p.userId == punishDto.userId);
                if (punishment == null)
                    return NotFound();
                punishment.isActive = false;
                await _punishRepo.UpdatePunishAsync(punishment);
            }


            return Ok(new {Message="Updated"});
        }


        [HttpGet("getuserformessaging/{roleId}")]
        public async Task<IActionResult> GetUserforMessaging(int roleId)
        {
            //1=üye 2=yönetici 3=görevli 4=yazar
            int[] rolesToMessage = roleId == 1 ? [3] : roleId == 2 ? [3, 4] : roleId == 3 ? [1, 2, 4] : roleId == 4 ? [2, 3] : [0];

            var users = await _userRepo.GetAllUsersAsync.Include(u => u.RegisterRequests).Where(u => u.RegisterRequests.Any(rr => rr.confirmation) && rolesToMessage.Contains(u.roleId)).Include(u => u.Role).ToListAsync(); //filtreleme oluyor  userlar arasındaki roller arraye göre filtrelendi
            return Ok(users.Select(u => new UserFDto
            {
                userId = u.id,
                fullname = u.name + " " + u.surname,
                roleName = u.Role.name,
            }));

        }


        [HttpGet("getuserforpunishment/{roleId}")]

        public async Task<IActionResult> GetUserforPunishment(int roleId)
        {
            int[] rolesToPunish = roleId == 2 ? [1, 3, 4] : roleId == 3 ? [1, 4] : roleId == 1 ? [0] : roleId == 4 ? [0] : [0];
            var usersP = await _userRepo.GetAllUsersAsync.Include(u => u.RegisterRequests).Where(p => p.RegisterRequests.Any(rr => rr.confirmation) && rolesToPunish.Contains(p.roleId)).Include(u => u.Role).Include(u => u.Punishments).ToListAsync();
            return Ok(usersP.Select(p => new UserFDto
            {
                userId = p.id,
                fullname = p.name + " " + p.surname,
                roleName = p.Role.name,
                isPunished = p.Punishments.Any(p => p.isActive)
            }));
        }


        [HttpGet("getusersforrolechanging/{roleId}")]

        public async Task<IActionResult> GetUserforRoleChanging(int roleId)
        {
            int[] roleChange = roleId == 2 ? [1, 3, 4] : [0];
            var userChangeRole = await _userRepo.GetAllUsersAsync.Include(u => u.RegisterRequests).Where(c => c.RegisterRequests.Any(rr => rr.confirmation) && roleChange.Contains(c.roleId)).Include(u => u.Role).ToListAsync();
            return Ok(userChangeRole.Select(c => new UserFDto
            {
                userId = c.id,
                fullname = c.name + " " + c.surname,
                roleName = c.Role.name,
            }));
        }

        //[HttpGet("getusersforlowserrole")]
        //public async Task<IActionResult> GetUsersForPunishment()
        //{
        //    var users = await _userRepo.GetAllUsersAsync();

        //    // Ceza almış veya ceza alma riski taşıyan kullanıcıları filtreleme
        //    var punishedUsers = users.Where(u => u.HasPunishment || /* ceza alma durumu kontrolü */).Select(u => new
        //    {
        //        u.Id,
        //        u.Username,
        //        Punishments = u.Punishments.Select(p => new
        //        {
        //            p.Type,
        //            p.Date // Ceza türü ve tarihi
        //        }).ToList()
        //    }).ToList();

        //    return Ok(punishedUsers);
        //}




        //[HttpGet("getusersforrolechanging")]
        //public async Task<IActionResult> GetUsersForRoleChanging()
        //{
        //    var users = await _userRepo.GetAllUsersAsync();

        //    // Rol değiştirme için uygun kullanıcıları filtreleme
        //    var eligibleForRoleChange = users.Where(u => /* rol değiştirme uygunluk kontrolü */).Select(u => new
        //    {
        //        u.Id,
        //        u.Username,
        //        CurrentRole = u.Role.Name // Kullanıcının mevcut rolü
        //    }).ToList();

        //    return Ok(eligibleForRoleChange);
        //}





    }
}
