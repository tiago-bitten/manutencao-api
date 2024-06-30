using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Proprietarios;
using SistemaManutencao.Application.UseCases.Proprietarios;

namespace SistemaManutencao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProprietariosController : ControllerBase
    {
        private readonly CreateProprietario _createProprietario;
        private readonly GetAllProprietarios _getAllProprietarios;

        public ProprietariosController(CreateProprietario createProprietario, GetAllProprietarios getAllProprietarios)
        {
            _createProprietario = createProprietario;
            _getAllProprietarios = getAllProprietarios;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateProprietarioDTO dto, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var proprietarioDTO = await _createProprietario.ExecuteAsync(dto, authHeader);

            HttpContext.Items["MensagemAPI"] = "Proprietário criado com sucesso";

            return Ok(proprietarioDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var proprietariosDTO = await _getAllProprietarios.ExecuteAsync();

            return Ok(proprietariosDTO);
        }
    }
}
