using Microservices.Catalog.Dtos.ProductDtos;
using Microservices.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace MicroServices.Product.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _productService.GetProductListAsync();
            return Ok(categories);
        }


        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(string id)
        {
            var category = await _productService.GetProductByIdAsync(id);
            return Ok(category);
        }


        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDTOs)
        {
            await _productService.CreateProductAsync(createProductDTOs);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productService.DeleteProductAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDTOs)
        {
            await _productService.UpdateProductAsync(updateProductDTOs);
            return Ok();
        }

    }
}