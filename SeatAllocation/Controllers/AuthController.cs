using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeatAllocation.Data;
using SeatAllocation.DTOs;
using SeatAllocation.Services;
using Microsoft.EntityFrameworkCore;

namespace SeatAllocation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JWTService _jwtService;
        private readonly AppDbContext _context;

        public AuthController(
            AuthService authService,
            JWTService jwtService,
            AppDbContext context,
            EmailService emailService)
        {
            _authService = authService;
            _jwtService = jwtService;
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { message = "Invalid request" });

                var result = await _authService.Register(dto);

                return Ok(new
                {
                    message = "User registered successfully",
                    data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Registration failed",
                    error = ex.Message
                });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                if (dto == null)
                    return BadRequest(new { message = "Invalid request" });

                var token = await _authService.Login(dto, _jwtService);

                if (token == null)
                    return Unauthorized(new { message = "Invalid email or password" });

                return Ok(new
                {
                    message = "Login successful",
                    token
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Login failed",
                    error = ex.Message
                });
            }
        }

        
    }
}
