using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> Get()
        {
            var categories = await _categoryService.GetCategories();

            if (categories == null)
            {
                return NotFound("Categorias não encontradas");
            }

            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetCategoryById")]
        public async Task<ActionResult<CategoryDTO>> Get(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound("Categoria não encontrada");
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDTO categoryDTO)
        {
            if (categoryDTO == null)
            {
                return BadRequest("Dados inválidos");
            }

            await _categoryService.Add(categoryDTO);

            return new CreatedAtRouteResult("GetCategoryById", new { id = categoryDTO.Id }, categoryDTO);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoryDTO categoryDTO)
        {
            if (id != categoryDTO.Id)
                return BadRequest();

            if (categoryDTO == null)
                return BadRequest();

            await _categoryService.Update(categoryDTO);

            return Ok(categoryDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound("Categoria não existente na base de dados");
            }

            await _categoryService.Remove(id);

            return Ok("Categoria excluída com sucesso!");
        }
    }
}
