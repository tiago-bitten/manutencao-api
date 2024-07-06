using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Modelo;
using SistemaManutencao.Application.UseCases.Modelos;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Infra.Data.Constants;

namespace SistemaManutencao.API.Controllers
{
    [Authorize(Policy = Policies.UsuarioAtivo)]
    [Route("api/[controller]")]
    [ApiController]
    public class ModelosController : ControllerBase
    {
        private readonly CreateModelo _createModelo;
        private readonly GetModeloById _getModeloById;
        private readonly GetAllModelos _getAllModelos;
        private readonly UpdateModelo _updateModelo;
        private readonly DeleteModelo _deleteModelo;

        public ModelosController(CreateModelo createModelo, GetModeloById getModeloById, GetAllModelos getAllModelos, UpdateModelo updateModelo, DeleteModelo deleteModelo)
        {
            _createModelo = createModelo;
            _getModeloById = getModeloById;
            _getAllModelos = getAllModelos;
            _updateModelo = updateModelo;
            _deleteModelo = deleteModelo;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateModeloDTO dto, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var modeloDTO = await _createModelo.ExecuteAsync(dto, authHeader);

            HttpContext.Items["MensagemAPI"] = "Modelo criado com sucesso";

            return CreatedAtAction(nameof(GetById), new { id = modeloDTO.Id }, modeloDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var modeloDTO = await _getModeloById.ExecuteAsync(id);

            if (modeloDTO == null)
                return NotFound();

            HttpContext.Items["MensagemAPI"] = "Modelo retornado com sucesso";

            return Ok(modeloDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Filtro filtros, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var modelosDTO = await _getAllModelos.ExecuteAsync(filtros, authHeader);

            HttpContext.Items["MensagemAPI"] = "Modelos retornados com sucesso";

            return Ok(modelosDTO);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateModeloDTO dto)
        {
            var modeloDTO = await _updateModelo.ExecuteAsync(id, dto);

            HttpContext.Items["MensagemAPI"] = "Modelo atualizado com sucesso";

            return Ok(modeloDTO);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteModelo.ExecuteAsync(id);

            HttpContext.Items["MensagemAPI"] = "Modelo deletado com sucesso";

            return Ok();
        }
    }
}
