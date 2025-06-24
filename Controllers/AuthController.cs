using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace SmartResidenceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly JwtService _jwtService;

        public AuthController(IUserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userService.AuthenticateAsync(dto.Username, dto.Password);
            if (user == null)
                return Unauthorized(new { message = "Invalid username or password" });

            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });

        }
    }
}
