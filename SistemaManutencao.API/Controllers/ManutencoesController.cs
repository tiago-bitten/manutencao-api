using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Manutencoes;
using SistemaManutencao.Application.UseCases.Manutencoes;
using SistemaManutencao.Domain.Entities;
using SistemaManutencao.Infra.Data.Constants;

namespace SistemaManutencao.API.Controllers
{
    [Authorize(Policy = Policies.UsuarioAtivo)]
    [Route("api/[controller]")]
    [ApiController]
    public class ManutencoesController : ControllerBase
    {
        private readonly CreateManutencao _createManutencao;
        private readonly GetAllManutencoes _getAllManutencoes;

        public ManutencoesController(CreateManutencao createManutencao, GetAllManutencoes getAllManutencoes)
        {
            _createManutencao = createManutencao;
            _getAllManutencoes = getAllManutencoes;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateManutencaoDTO dto, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var manutencaoDTO = await _createManutencao.ExecuteAsync(dto, authHeader);

            HttpContext.Items["MensagemAPI"] = "Manutenção criada com sucesso";

            return Ok(manutencaoDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] Filtro filtro, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var manutencoesDTO = await _getAllManutencoes.ExecuteAsync(filtro, authHeader);

            return Ok(manutencoesDTO);
        }
    }
}
