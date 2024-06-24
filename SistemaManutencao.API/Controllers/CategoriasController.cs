﻿using Microsoft.AspNetCore.Mvc;
using SistemaManutencao.Application.DTOs.Entities.Categoria;
using SistemaManutencao.Application.UseCases.Categorias;

namespace SistemaManutencao.API.Controllers
{
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
        public async Task<IActionResult> Create([FromBody] CreateCategoriaDTO dto)
        {
            var categoriaDTO = await _createCategoria.ExecuteAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = categoriaDTO.Id }, categoriaDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var categoriaDTO = await _getCategoriaById.ExecuteAsync(id);

            return Ok(categoriaDTO);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? nome)
        {
            var categoriasDTO = await _getAllCategorias.ExecuteAsync(nome);


            return Ok(categoriasDTO);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateCategoriaDTO dto)
        {
            var categoriaDTO = await _updateCategoria.ExecuteAsync(id, dto);
            
            return Ok(categoriaDTO);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _deleteCategoria.ExecuteAsync(id);

            return NoContent();
        }
    }
}
