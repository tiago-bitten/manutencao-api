using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Usuarios;
using SistemaManutencao.Application.UseCases.Auth;

namespace SistemaManutencao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly Login _login;

        public AuthController(Login login)
        {
            _login = login;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var token = await _login.ExecuteAsync(dto);

            return Ok(token);
        }
    }
}
