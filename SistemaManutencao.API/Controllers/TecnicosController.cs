using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Tecnicos;
using SistemaManutencao.Application.UseCases.Tecnicos;
using SistemaManutencao.Infra.Data.Constants;

namespace SistemaManutencao.API.Controllers
{
    [Authorize(Policy = Policies.UsuarioAtivo)]
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosController : ControllerBase
    {
        private readonly CreateTecnico _createTecnico;
        private readonly GetAllTecnicos _getAllTecnicos;

        public TecnicosController(CreateTecnico createTecnico, GetAllTecnicos getAllTecnicos)
        {
            _createTecnico = createTecnico;
            _getAllTecnicos = getAllTecnicos;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateTecnicoDTO dto, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var tecnicoDTO = await _createTecnico.ExecuteAsync(dto, authHeader);

            HttpContext.Items["MensagemAPI"] = "Técnico criado com sucesso";
            
            return CreatedAtAction(nameof(Create), tecnicoDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? nome, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var tecnicos = await _getAllTecnicos.ExecuteAsync(nome, authHeader);

            return Ok(tecnicos);
        }
    }
}
