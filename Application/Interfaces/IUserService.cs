using Application.DTOs;
using Domain.Entities;
using SmartCity.Application.DTOs;

namespace Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> AuthenticateAsync(string username, string password);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task<UserDto> GetUserByIdAsync(int id);
        Task<UserDto> CreateUserAsync(CreateUserDto createUserDto);
        Task<UserDto> UpdateUserAsync(int id, UserDto dto);
        Task<bool> DeleteUserAsync(int id);
    }
}
