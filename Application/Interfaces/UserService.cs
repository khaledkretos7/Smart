using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SmartCity.Application.DTOs;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly PasswordHasher<User> _passwordHasher;

        public UserService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<User?> AuthenticateAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return null;

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, password);

            return result == PasswordVerificationResult.Success ? user : null;
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUserAsync(CreateUserDto dto)
        {
            var entity = _mapper.Map<User>(dto);
            entity.Password = _passwordHasher.HashPassword(entity, dto.Password);
            entity.CreatedAt = DateTime.UtcNow;

            _context.Users.Add(entity);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(entity);
        }

        public async Task<UserDto> UpdateUserAsync(int id, UserDto dto)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity == null) return null;

            _mapper.Map(dto, entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(entity);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var entity = await _context.Users.FindAsync(id);
            if (entity == null) return false;

            _context.Users.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
