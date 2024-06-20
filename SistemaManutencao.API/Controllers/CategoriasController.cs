using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using UseCases;

namespace SistemaManutencao.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly CreateCategoria _createCategoria;

        public CategoriasController(CreateCategoria createCategoria)
        {
            _createCategoria = createCategoria;
        }

        [HttpPost("Criar")]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaDTO dto)
        {
            var categoria = await _createCategoria.ExecuteAsync(dto);

            return Ok(categoria);
        }
    }
}
