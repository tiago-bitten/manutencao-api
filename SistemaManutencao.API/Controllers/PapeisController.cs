using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Papeis;
using SistemaManutencao.Application.UseCases.Papeis;
using SistemaManutencao.Infra.Data.Constants;

namespace SistemaManutencao.API.Controllers
{
    [Authorize(Policy = Policies.UsuarioAtivo)]
    [Route("api/[controller]")]
    [ApiController]
    public class PapeisController : ControllerBase
    {
        private readonly CreatePapel _createPapel;

        public PapeisController(CreatePapel createPapel)
        {
            _createPapel = createPapel;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreatePapelDTO dto, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var papelDTO = await _createPapel.ExecuteAsync(dto, authHeader);

            HttpContext.Items["MensagemAPI"] = "Papel criado com sucesso";

            return Ok(papelDTO);
        }
    }
}
