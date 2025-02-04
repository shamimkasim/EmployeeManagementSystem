using EmployeeManagementSystem.Application.DTOs.Requests;
using EmployeeManagementSystem.Application.DTOs.Responses;
using EmployeeManagementSystem.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmployeeManagementSystem.API.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        
        [AllowAnonymous]
        [HttpPost("login")]
        [ProducesResponseType(typeof(AuthResponse), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authService.LoginAsync(request);
            return Ok(result);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost("register")]
        [ProducesResponseType(typeof(AuthResponse), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Register([FromBody] CreateEmployeeRequest request)
        {
            var result = await _authService.RegisterAsync(request);
            return CreatedAtAction("GetById", "Employee", new { id = result.UserId }, result);
        }
    }
}
