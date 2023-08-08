using MicroService.Services.Catalog.Dtos.CategoryDtos;
using MicroService.Shared.Dtos;

namespace MicroService.Services.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<Response<List<ResultCategoryDto>>> GetAllCategoryAsync();
        Task<Response<ResultCategoryDto>> GetByIDCategoryAsync(string id);
        Task<Response<NoContent>> CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task<Response<NoContent>> UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task<Response<NoContent>> DeleteCategoryAsync(string id);

    }
}
