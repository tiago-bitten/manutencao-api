using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Tecnicos;
using SistemaManutencao.Application.UseCases.Tecnicos;

namespace SistemaManutencao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosController : ControllerBase
    {
        private readonly CreateTecnico _createTecnico;

        public TecnicosController(CreateTecnico createTecnico)
        {
            _createTecnico = createTecnico;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateTecnicoDTO dto)
        {
            var tecnicoDTO = await _createTecnico.ExecuteAsync(dto);

            HttpContext.Items["MensagemAPI"] = "Técnico criado com sucesso";
            
            return CreatedAtAction(nameof(Create), tecnicoDTO);
        }
    }
}
