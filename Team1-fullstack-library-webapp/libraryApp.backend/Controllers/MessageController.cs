using libraryApp.backend.Dtos;
using libraryApp.backend.Entity;
using libraryApp.backend.Repository.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        public MessageController(IMessageRepository messageRepository) 
        { 
            _messageRepository = messageRepository;
        }
        [HttpGet("getMessages")]
        public async Task<IActionResult> GetAllMessages()
        {
            var messages = await _messageRepository.GetAllMessages.ToListAsync();
            if (!messages.Any())
            {
                return NotFound();
            }
            List<GetMessageDTO> messageDTO = messages.Select(m => new GetMessageDTO
            {
                title = m.title,
                content = m.content,
                sendingDate = m.sendingDate,
                isRead = m.isRead,
            }).ToList();
            return Ok(messageDTO);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var message = await _messageRepository.GetMessageById(id);
            if (message == null)
            {
                return NotFound();
            }
            GetMessageDTO getMessageDTO = new GetMessageDTO
            {
                title = message.title,
                content = message.content,
                sendingDate = message.sendingDate,
                isRead = message.isRead,
            };
            return Ok(getMessageDTO);
        }
        [HttpGet("isReadMessages")]
        public async Task<IActionResult> GetIsReadMessages()
        {
            var messages = await _messageRepository.GetAllMessages
                .Where(m => m.isRead == true)
                .ToListAsync();

            if (messages == null || !messages.Any())
            {
                return NotFound();
            }

            var messageDTO = messages.Select(m => new GetMessageDTO
            {
                title = m.title,
                content = m.content,
                sendingDate = m.sendingDate,
                isRead = m.isRead,
            }).ToList();

            return Ok(messageDTO);
        }

        [HttpPost("sendMessage")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDTO messageDto)
        {
            if (messageDto == null || string.IsNullOrEmpty(messageDto.title) || string.IsNullOrEmpty(messageDto.content))
            {
                return BadRequest(new { Message = "Message information is missing or invalid." });
            }

            var newMessage = new Message
            {
                title = messageDto.title,
                content = messageDto.content,
                sendingDate = DateOnly.FromDateTime(DateTime.UtcNow),
                senderId = messageDto.senderId,
                recieverId = messageDto.receiverId
            };

            await _messageRepository.AddMessage(newMessage);
            await _messageRepository.UpdateMessage(newMessage);

            return CreatedAtAction(nameof(GetMessageById), new { id = newMessage.id }, newMessage);
        }
        [HttpGet("getinbox/{userId}")]
        public async Task<IActionResult> GetInbox(int userId)
        {
            var messages = await _messageRepository.GetAllMessages
                                                   .Where(m => m.recieverId == userId)
                                                   .Include(m => m.sender)
                                                   .ToListAsync();

            if (messages == null || !messages.Any())
            {
                return NotFound();
            }

            var messageDTOs = messages.Select(m => new GetMessageDTO
            {
                title = m.title,
                content = m.content,
                sendingDate = m.sendingDate,
                isRead = m.isRead,
                senderName = m.sender.name + " " + m.sender.surname,
            }).ToList();

            return Ok(messageDTOs);
        }

    }
}
