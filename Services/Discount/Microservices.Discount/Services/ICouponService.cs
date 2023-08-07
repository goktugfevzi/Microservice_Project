using Microservices.Discount.Dtos;
using MicroServices.Shared.Dtos;

namespace Microservices.Discount.Services
{
    public interface ICouponService
    {
        Task<Response<List<ResultCouponDto>>> GetCouponList();
        Task<Response<NoContent>> CreateCoupon(CreateCouponDto createCouponDto);
        Task<Response<NoContent>> UpdateCoupon(UpdateCouponDto updateCouponDto);
        Task<Response<NoContent>> DeleteCoupon(int id);
        Task<Response<ResultCouponDto>> GetCouponByID(int id);


    }
}
