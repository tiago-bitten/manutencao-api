using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Equipamento;
using SistemaManutencao.Application.UseCases.Equipamentos;

namespace SistemaManutencao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentosController : ControllerBase
    {
        private readonly CreateEquipamento _createEquipamento;

        public EquipamentosController(CreateEquipamento createEquipamento)
        {
            _createEquipamento = createEquipamento;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateEquipamentoDTO dto)
        {
            var equipamentoDTO = await _createEquipamento.ExecuteAsync(dto);

            return Ok(equipamentoDTO);
        }
    }
}
