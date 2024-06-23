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
        private readonly GetEquipamentoById _getEquipamentoById;
        private readonly GetAllEquipamentos _getAllEquipamentos;
        private readonly UpdateEquipamento _updateEquipamento;
        private readonly DeleteEquipamento _deleteEquipamento;

        public EquipamentosController(CreateEquipamento createEquipamento, GetEquipamentoById getEquipamentoById, GetAllEquipamentos getAllEquipamentos, UpdateEquipamento updateEquipamento, DeleteEquipamento deleteEquipamento)
        {
            _createEquipamento = createEquipamento;
            _getEquipamentoById = getEquipamentoById;
            _getAllEquipamentos = getAllEquipamentos;
            _updateEquipamento = updateEquipamento;
            _deleteEquipamento = deleteEquipamento;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateEquipamentoDTO dto)
        {
            var equipamentoDTO = await _createEquipamento.ExecuteAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = equipamentoDTO.Id }, equipamentoDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var equipamentoDTO = await _getEquipamentoById.ExecuteAsync(id);

            return Ok(equipamentoDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var equipamentosDTO = await _getAllEquipamentos.ExecuteAsync();

            return Ok(equipamentosDTO);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateEquipamentoDTO dto)
        {
            var equipamentoDTO = await _updateEquipamento.ExecuteAsync(id, dto);

            return Ok(equipamentoDTO);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteEquipamento.ExecuteAsync(id);

            return NoContent();
        }
    }
}
