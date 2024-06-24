using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
using SistemaManutencao.Application.UseCases.Localizacoes;

namespace SistemaManutencao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacoesController : ControllerBase
    {
        private readonly CreateLocalizacao _createLocalizacao;
        private readonly GetLocalizacaoById _getLocalizacaoById;
        private readonly GetAllLocalizacoes _getAllLocalizacoes;
        private readonly UpdateLocalizacao _updateLocalizacao;
        private readonly DeleteLocalizacao _deleteLocalizacao;

        public LocalizacoesController(CreateLocalizacao createLocalizacao, GetLocalizacaoById getLocalizacaoById, GetAllLocalizacoes getAllLocalizacoes, UpdateLocalizacao updateLocalizacao, DeleteLocalizacao deleteLocalizacao)
        {
            _createLocalizacao = createLocalizacao;
            _getLocalizacaoById = getLocalizacaoById;
            _getAllLocalizacoes = getAllLocalizacoes;
            _updateLocalizacao = updateLocalizacao;
            _deleteLocalizacao = deleteLocalizacao;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateLocalizacaoDTO dto)
        {
            var localizacao = await _createLocalizacao.ExecuteAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = localizacao.Id }, localizacao);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var localizacao = await _getLocalizacaoById.ExecuteAsync(id);

            if (localizacao == null)
                return NotFound();

            return Ok(localizacao);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? nome)
        {
            var localizacoes = await _getAllLocalizacoes.ExecuteAsync(nome);

            return Ok(localizacoes);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLocalizacaoDTO dto)
        {
            var localizacao = await _updateLocalizacao.ExecuteAsync(id, dto);

            return Ok(localizacao);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteLocalizacao.ExecuteAsync(id);

            return NoContent();
        }
    }
}
