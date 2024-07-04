using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.OrdensServicos;
using SistemaManutencao.Application.UseCases.OrdensServicos;
using SistemaManutencao.Infra.Data.Constants;

namespace SistemaManutencao.API.Controllers
{
    [Authorize(Policy = Policies.UsuarioAtivo)]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdensServicosController : ControllerBase
    {
        private readonly CreateOrdemServico _createOrdemServico;

        public OrdensServicosController(CreateOrdemServico createOrdemServico)
        {
            _createOrdemServico = createOrdemServico;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateOrdemServicoDTO dto, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var ordemServicoDTO = await _createOrdemServico.ExecuteAsync(dto, authHeader);

            HttpContext.Items["MensagemAPI"] = "Ordem de serviço criada com sucesso";

            return Ok(ordemServicoDTO);
        }
    }
}
