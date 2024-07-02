using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Application.UseCases.Categorias;
using SistemaManutencao.Infra.Data.Constants;

namespace SistemaManutencao.API.Controllers
{
    [Authorize(Policy = Policies.UsuarioAtivo)]
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly CreateCategoria _createCategoria;
        private readonly GetCategoriaById _getCategoriaById;
        private readonly GetAllCategorias _getAllCategorias;
        private readonly UpdateCategoria _updateCategoria;
        private readonly DeleteCategoria _deleteCategoria;

        public CategoriasController(CreateCategoria createCategoria, GetCategoriaById getCategoriaById, GetAllCategorias getAllCategorias, UpdateCategoria updateCategoria, DeleteCategoria deleteCategoria)
        {
            _createCategoria = createCategoria;
            _getCategoriaById = getCategoriaById;
            _getAllCategorias = getAllCategorias;
            _updateCategoria = updateCategoria;
            _deleteCategoria = deleteCategoria;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CreateCategoriaDTO dto, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var categoriaDTO = await _createCategoria.ExecuteAsync(dto, authHeader);

            HttpContext.Items["MensagemAPI"] = "Categoria criada com sucesso";

            return CreatedAtAction(nameof(GetById), new { id = categoriaDTO.Id }, categoriaDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var categoriaDTO = await _getCategoriaById.ExecuteAsync(id);

            HttpContext.Items["MensagemAPI"] = "Categoria retornada com sucesso";

            return Ok(categoriaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? nome, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var categoriasDTO = await _getAllCategorias.ExecuteAsync(nome, authHeader);

            HttpContext.Items["MensagemAPI"] = "Categorias retornadas com sucesso";

            return Ok(categoriasDTO);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoriaDTO dto, [FromHeader(Name = "Authorization")] string authHeader)
        {
            var categoriaDTO = await _updateCategoria.ExecuteAsync(id, dto, authHeader);

            HttpContext.Items["MensagemAPI"] = "Categoria atualizada com sucesso";
            
            return Ok(categoriaDTO);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteCategoria.ExecuteAsync(id);

            HttpContext.Items["MensagemAPI"] = "Categoria deletada com sucesso";

            return Ok();
        }
    }
}
