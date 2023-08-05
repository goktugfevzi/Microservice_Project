using Microservices.Catalog.Dtos.CategoryDtos;
using Microservices.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroServices.Catalog.Controllers
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
        public async Task<IActionResult> GetAll()
        {
            var categories = await _categoryService.GetCategoryListAsync();
            return Ok(categories);
        }


        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDTOs)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDTOs);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDTOs)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDTOs);
            return Ok();
        }

    }
}