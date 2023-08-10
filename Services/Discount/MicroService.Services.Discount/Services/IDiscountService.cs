using MicroService.Services.Discount.Dtos;
using MicroService.Services.Discount.Models;
using MicroService.Shared.Dtos;

namespace MicroService.Services.Discount.Services
{
    public interface IDiscountService
    {
        Task<Response<List<ResultDiscountDto>>> GetAllDiscountCouponsAsync();
        Task<Response<ResultDiscountDto>> GetByIdDiscountCoupon(int id);
        Task<Response<NoContent>> CreateDiscountCoupons(CreateDiscountDto createDiscountDto);
        Task<Response<NoContent>> UpdateDiscountCoupons(UpdateDiscountDto updateDiscountDto);
        Task<Response<NoContent>> DeleteDiscountCoupons(int id);
    }
}
