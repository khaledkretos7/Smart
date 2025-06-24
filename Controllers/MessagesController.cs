using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace SmartResidenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var messages = await _messageService.GetAllMessagesAsync();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var message = await _messageService.GetMessageByIdAsync(id);
            if (message == null) return NotFound();
            return Ok(message);
        }

        [HttpPost]
        public async Task<IActionResult> Create(MessageDto dto)
        {
            var message = await _messageService.CreateMessageAsync(dto);
            return Ok(message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, MessageDto dto)
        {
            var message = await _messageService.UpdateMessageAsync(id, dto);
            if (message == null) return NotFound();
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _messageService.DeleteMessageAsync(id);
            if (!result) return NotFound();
            return Ok(new { message = "Message deleted successfully" });
        }
    }
}
