using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using social.Dtos;
using social.Models;
using social.Services;

namespace social.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AuthService service) : ControllerBase
    {
        private readonly AuthService _service = service;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(dto);
            var user = await _service.RegisterAsync(dto);
            if (user.Succeeded)
            {
                return Ok("Register successfully");
            }
            else
            {
                return StatusCode(500, user.Errors);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var result = await _service.Login(dto);
                return Ok($"Token: {result}");
            }
            catch (Exception e)
            {
                return Unauthorized(value: e.Message);
            }
        }
    }
}
