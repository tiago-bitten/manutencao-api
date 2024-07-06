using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Localizacoes;
using SistemaManutencao.Application.UseCases.Localizacoes;
using SistemaManutencao.Domain.Entities;

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
        public async Task<IActionResult> Create([FromBody] CreateLocalizacaoDTO dto, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var localizacao = await _createLocalizacao.ExecuteAsync(dto, authHeader);

            HttpContext.Items["MensagemAPI"] = "Localização criada com sucesso";

            return CreatedAtAction(nameof(GetById), new { id = localizacao.Id }, localizacao);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var localizacao = await _getLocalizacaoById.ExecuteAsync(id);

            if (localizacao == null)
                return NotFound();

            HttpContext.Items["MensagemAPI"] = "Localização retornada com sucesso";

            return Ok(localizacao);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Filtro filtros, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var localizacoes = await _getAllLocalizacoes.ExecuteAsync(filtros, authHeader);

            HttpContext.Items["MensagemAPI"] = "Localizações retornadas com sucesso";

            return Ok(localizacoes);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateLocalizacaoDTO dto)
        {
            var localizacao = await _updateLocalizacao.ExecuteAsync(id, dto);

            HttpContext.Items["MensagemAPI"] = "Localização atualizada com sucesso";

            return Ok(localizacao);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteLocalizacao.ExecuteAsync(id);

            HttpContext.Items["MensagemAPI"] = "Localização deletada com sucesso";

            return Ok();
        }
    }
}
