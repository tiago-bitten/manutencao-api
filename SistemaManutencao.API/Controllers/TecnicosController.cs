using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Tecnicos;
using SistemaManutencao.Application.UseCases.Tecnicos;
using SistemaManutencao.Domain.Interfaces.Repositories;
using SistemaManutencao.Infra.Data.Repositories;

namespace SistemaManutencao.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TecnicosController : ControllerBase
    {
        private readonly CreateTecnico _createTecnico;
        private readonly ITecnicoRepository _tecnicoRepository;

        public TecnicosController(CreateTecnico createTecnico, ITecnicoRepository tecnicoRepository)
        {
            _createTecnico = createTecnico;
            _tecnicoRepository = tecnicoRepository;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateTecnicoDTO dto)
        {
            var tecnicoDTO = await _createTecnico.ExecuteAsync(dto);
            
            return CreatedAtAction(nameof(Create), tecnicoDTO);
        }

        [HttpGet("Teste")]
        public async Task<IActionResult> Teste()
        {
            var numeroEquipamentos = await _tecnicoRepository.GetNumeroEquipamentos();

            return Ok(numeroEquipamentos);
        }
    }
}
