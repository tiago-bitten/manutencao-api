using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Empresas;
using SistemaManutencao.Application.UseCases.Empresas;

namespace SistemaManutencao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EmpresasController : ControllerBase
    {
        private readonly CreateEmpresa _createEmpresa;
        private readonly GetAllEmpresas _getAllEmpresas;

        public EmpresasController(CreateEmpresa createEmpresa, GetAllEmpresas getAllEmpresas)
        {
            _createEmpresa = createEmpresa;
            _getAllEmpresas = getAllEmpresas;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateEmpresaDTO dto, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var empresaDTO = await _createEmpresa.ExecuteAsync(dto, authHeader);

            HttpContext.Items["MensagemAPI"] = "Empresa criada com sucesso";

            return Ok(empresaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empresasDTO = await _getAllEmpresas.ExecuteAsync();

            return Ok(empresasDTO);
        }
    }
}
