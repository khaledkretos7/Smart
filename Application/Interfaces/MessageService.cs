using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public MessageService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MessageDto>> GetAllMessagesAsync()
        {
            var messages = await _context.Messages.ToListAsync();
            return _mapper.Map<IEnumerable<MessageDto>>(messages);
        }

        public async Task<MessageDto> GetMessageByIdAsync(int id)
        {
            var message = await _context.Messages.FindAsync(id);
            return message == null ? null : _mapper.Map<MessageDto>(message);
        }

        public async Task<MessageDto> CreateMessageAsync(MessageDto dto)
        {
            var entity = _mapper.Map<Message>(dto);
            _context.Messages.Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<MessageDto>(entity);
        }

        public async Task<MessageDto> UpdateMessageAsync(int id, MessageDto dto)
        {
            var entity = await _context.Messages.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<MessageDto>(entity);
        }

        public async Task<bool> DeleteMessageAsync(int id)
        {
            var entity = await _context.Messages.FindAsync(id);
            if (entity == null) return false;

            _context.Messages.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}