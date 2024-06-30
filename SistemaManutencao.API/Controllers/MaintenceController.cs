using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Domain.Interfaces.Services;

namespace SistemaManutencao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MaintenceController : ControllerBase
    {
        private readonly DatabaseCleanupService _databaseCleanupService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IAuthService _authService;

        public MaintenceController(DatabaseCleanupService databaseCleanupService, IUsuarioRepository usuarioRepository, IAuthService authService)
        {
            _databaseCleanupService = databaseCleanupService;
            _usuarioRepository = usuarioRepository;
            _authService = authService;
        }

        [HttpPost("CleanupDatabase")]
        public async Task<IActionResult> CleanupAndSeedDatabaseAsync()
        {
            await _databaseCleanupService.CleanupAndSeedDatabaseAsync();

            var usuario = _usuarioRepository.GetByEmailAsync("usuario@padrao.com").Result;

            HttpContext.Items.Add("MensagemAPI", "Banco limpado, e semeado com sucesso");

            return Ok(_authService.GenerateTokenAsync(usuario));
        }
    }
}
