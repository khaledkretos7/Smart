using Application.DTOs;

namespace Application.Interfaces
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDto>> GetAllMessagesAsync();
        Task<MessageDto> GetMessageByIdAsync(int id);
        Task<MessageDto> CreateMessageAsync(MessageDto dto);
        Task<MessageDto> UpdateMessageAsync(int id, MessageDto dto);
        Task<bool> DeleteMessageAsync(int id);
    }
}
