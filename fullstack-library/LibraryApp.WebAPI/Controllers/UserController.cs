using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fullstack_library.DTO;
using LibraryApp.Data.Abstract;
using LibraryApp.Data.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace fullstack_library.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly IMessageRepository _msgRepo;
        private readonly IRoleRepository _roleRepo;

        public UserController(IUserRepository userRepo, IMessageRepository msgRepo, IRoleRepository roleRepo)
        {
            _userRepo = userRepo;
            _msgRepo = msgRepo;
            _roleRepo = roleRepo;
        }

        [HttpPut("SetRegistirationRequest")]
        [Authorize(Policy = "StaffOrManagerPolicy")]
        public IActionResult ApproveRegistiration(UserRegistirationDTO userRegistirationDTO)
        {
            var user = _userRepo.GetUserById(userRegistirationDTO.UserId);
            if (user == null) return NotFound(new { message = "User not found" });

            if (userRegistirationDTO.IsApproved)
            {
                user.RoleId++;
                _userRepo.UpdateUser(user);
            }
            else
                _userRepo.DeleteUser(user);

            return Ok(new { message = "Operation done!" });
        }

        [HttpPut("SetPunishment")]
        [Authorize(Policy = "StaffOrManagerPolicy")]
        public IActionResult SetPunishment(PunishUserDTO punishUserDTO)
        {
            //TODO can be used for both staff and users like if it is punished cannot login to system and later on we can change ispunished to false and maybe use punishmentDTO for the parameters

            var user = _userRepo.GetUserById(punishUserDTO.UserId);
            if (user == null) return NotFound(new { message = "User not found" });
            if (!_userRepo.Users.Any(u => u.Id == punishUserDTO.PunisherId)) return NotFound(new { message = "Punisher not found" });
            user.FineAmount = punishUserDTO.FineAmount;
            user.IsPunished = punishUserDTO.IsPunished;
            _userRepo.UpdateUser(user);
            _msgRepo.CreateMessage(new Message
            {
                ReceiverId = user.Id,
                Details = punishUserDTO.IsPunished ? punishUserDTO.Details : "Your punishment removed. Thanks for being good boy.",
                SenderId = punishUserDTO.PunisherId,
                Title = punishUserDTO.IsPunished ? "You are punished from library at " + DateTime.Now : "Your punishment removed.",
            });

            return Ok(new { message = "Punishment status updated" });
        }

        [HttpPost("SendMessage")]
        [Authorize(Policy="MemberOrHigherPolicy")]
        public IActionResult SendMessage(MessageDTO msg)
        {
            var sender = _userRepo.GetUserById(msg.SenderId);
            if (sender == null) return NotFound(new { message = "Sender user not found" });
            var receiver = _userRepo.GetUserById(msg.ReceiverId);
            if (receiver == null) return NotFound(new { message = "Receiver user not found" });

            //FIXME cannot send title rn

            var entity = new Message
            {
                SenderId = msg.SenderId,
                ReceiverId = msg.ReceiverId,
                Title = msg.Title,
                Details = msg.Details,
            };
            _msgRepo.CreateMessage(entity);

            return Ok(new { Message = "Message has been sent" });
        }

        [HttpGet("GetInbox")]
        [Authorize(Policy="MemberOrHigherPolicy")]
        public IActionResult GetInbox([FromQuery] int userId)
        {
            var msgs = _msgRepo.GetMessagesByReceiverId(userId);
            msgs.Reverse();
            return Ok(msgs.Select(m =>
            new MessageDTO
            {
                Id = m.Id,
                Title = m.Title,
                Details = m.Details,
                ReceiverId = m.ReceiverId,
                SenderId = m.SenderId,
                SenderName = m.Sender.Name + " " + m.Sender.Surname,
                IsReceiverRead = m.IsReceiverRead,
            }));
        }

        [HttpGet("GetUsersOfLowerOrEqualRole")]
        [Authorize(Policy="MemberOrHigherPolicy")]
        public IActionResult GetUsersOfLowerOrEqualRole([FromQuery] int roleId, [FromQuery] int userId)
        {
            //designed like the higher the role the greater it's id
            //return lower or same roles
            var users = _userRepo.Users.Where(u => u.RoleId <= roleId && u.RoleId != 1 && u.Id != userId).Include(u => u.Role);

            return Ok(users.Select(u => new
            {
                Id = u.Id,
                Name = u.Name + " " + u.Surname,
                RoleName = u.Role.Name,
            }
            ));
        }

        [HttpGet("GetUsersOfLowerRole")]
        [Authorize(Policy="MemberOrHigherPolicy")]
        public IActionResult GetUsersOfLowerRole([FromQuery] int roleId, [FromQuery] int userId)
        {
            //designed like the higher the role the greater it's id
            //return lower roles
            var users = _userRepo.Users.Where(u => u.RoleId < roleId && u.RoleId != 1 && u.Id != userId).Include(u => u.Role);

            return Ok(users.Select(u => new
            {
                Id = u.Id,
                Name = u.Name + " " + u.Surname,
                RoleId = u.RoleId,
                RoleName = u.Role.Name,
                IsPunished = u.IsPunished,
                FineAmount = u.FineAmount,
            }
            ));
        }

        [HttpGet("MemberRegistirations")]
        [Authorize(Policy = "StaffOrManagerPolicy")]
        public IActionResult GetPendingRegistirations()
        {
            var pendingUsers = _userRepo.Users.Where(u => u.RoleId == 1);

            return Ok(pendingUsers.Select(pu => new UserDTO
            {
                BirthDate = pu.BirthDate,
                Gender = pu.Gender,
                Id = pu.Id,
                Name = pu.Name,
                Surname = pu.Surname,
                Username = pu.Username,
            }));
        }

        [HttpGet("GetAllRoles")]
        [Authorize(Policy="MemberOrHigherPolicy")]
        public IActionResult GetAllRoles([FromQuery] int roleId)
        {
            //designed like the higher the role the greater it's id
            //return lower roles
            var roles = _roleRepo.Roles.Where(r => r.Id != roleId && r.Id != 1);

            return Ok(roles.Select(r => new
            {
                r.Id,
                r.Name
            }
            ));
        }

        [HttpPost("UpdateMessageReadState")]
        [Authorize(Policy="MemberOrHigherPolicy")]
        public IActionResult UpdateMessageReadState(MessageDTO readMsg)
        {
            var msg = _msgRepo.Messages.FirstOrDefault(m => m.Id == readMsg.Id);
            if (msg == null) return NotFound(new { Message = "Message could not found" });
            msg.IsReceiverRead = true;

            _msgRepo.UpdateMessage(msg);

            return Ok(new { Message = "Message updated" });
        }

        [HttpPut("ChangeRole")]
        [Authorize(Policy = "ManagerPolicy")]
        public IActionResult ChangeRole(UpdateRoleDTO updateRoleDTO)
        {
            var user = _userRepo.GetUserById(updateRoleDTO.UserId);
            if (user == null) return NotFound(new { Message = "User could not found" });
            if (!_roleRepo.Roles.Any(r => r.Id == updateRoleDTO.NewRoleId)) return NotFound(new { Message = "Role could not found" });

            user.RoleId = updateRoleDTO.NewRoleId;
            _userRepo.UpdateUser(user);
            return Ok(new { Message = "Operation Done!" });
        }
    }
}