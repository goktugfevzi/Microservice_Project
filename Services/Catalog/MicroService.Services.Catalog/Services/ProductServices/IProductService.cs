using MicroService.Services.Catalog.Dtos.ProductDtos;
using MicroService.Shared.Dtos;

namespace MicroService.Services.Catalog.Services.ProductServices
{
    public interface IProductService
    {
        Task<Response<List<ResultProductDto>>> GetAllProductAsync();
        Task<Response<ResultProductDto>> GetByIDProductAsync(string id);
        Task<Response<NoContent>> CreateProductAsync(CreateProductDto createProductDto);
        Task<Response<NoContent>> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<Response<NoContent>> DeleteProductAsync(string id);

    }
}
