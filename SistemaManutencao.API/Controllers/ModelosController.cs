using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Application.UseCases.Modelo;

namespace SistemaManutencao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly CreateModelo _createModelo;
        private readonly GetModeloById _getModeloById;
        private readonly GetAllModelos _getAllModelos;
        private readonly UpdateModelo _updateModelo;

        public ModelosController(CreateModelo createModelo, GetModeloById getModeloById, GetAllModelos getAllModelos, UpdateModelo updateModelo)
        {
            _createModelo = createModelo;
            _getModeloById = getModeloById;
            _getAllModelos = getAllModelos;
            _updateModelo = updateModelo;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateModeloDTO dto)
        {
            var modeloDTO = await _createModelo.ExecuteAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = modeloDTO.Id }, modeloDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var modeloDTO = await _getModeloById.ExecuteAsync(id);

            return Ok(modeloDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var modelosDTO = await _getAllModelos.ExecuteAsync();

            return Ok(modelosDTO);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateModeloDTO dto)
        {
            var modeloDTO = await _updateModelo.ExecuteAsync(id, dto);

            return Ok(modeloDTO);
        }
    }
}
