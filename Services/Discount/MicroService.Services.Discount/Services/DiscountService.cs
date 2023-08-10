using AutoMapper;
using MicroService.Services.Discount.Context;
using MicroService.Services.Discount.Dtos;
using MicroService.Services.Discount.Models;
using MicroService.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace MicroService.Services.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _dapperContext;
        private readonly IMapper _mapper;

        public DiscountService(DapperContext dapperContext, IMapper mapper)
        {
            _dapperContext = dapperContext;
            _mapper = mapper;
        }

        public async Task<Response<NoContent>> CreateDiscountCoupons(CreateDiscountDto createDiscountDto)
        {
            var createCoupon = _mapper.Map<DiscountCoupons>(createDiscountDto);
            createCoupon.CreatedTime = DateTime.Now;

            await _dapperContext.DiscountCouponses.AddAsync(createCoupon);
            await _dapperContext.SaveChangesAsync();
            return Response<NoContent>.Success(201);

        }

        public async Task<Response<NoContent>> DeleteDiscountCoupons(int id)
        {
            var result = await _dapperContext.DiscountCouponses.FindAsync(id);
            if (result == null)
            {
                return Response<NoContent>.Fail("silinecek kupon bulunamadı", 404);
            }
            _dapperContext.DiscountCouponses.Remove(result);
            await _dapperContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);
        }

        public async Task<Response<List<ResultDiscountDto>>> GetAllDiscountCouponsAsync()
        {
            var values = await _dapperContext.DiscountCouponses.ToListAsync();
            return Response<List<ResultDiscountDto>>.Success(_mapper.Map<List<ResultDiscountDto>>(values), 200);
        }

        public async Task<Response<ResultDiscountDto>> GetByIdDiscountCoupon(int id)
        {
            var result = await _dapperContext.DiscountCouponses.FindAsync(id);
            if (result == null)
            {
                return Response<ResultDiscountDto>.Fail("Kupon bulunamadı", 404);
            }
            return Response<ResultDiscountDto>.Success(_mapper.Map<ResultDiscountDto>(result), 200);
        }

        public async Task<Response<NoContent>> UpdateDiscountCoupons(UpdateDiscountDto updateDiscountDto)
        {
            var existingResponse = await _dapperContext.DiscountCouponses.FindAsync(updateDiscountDto.DiscountCouponsID);
            if (existingResponse == null)
            {
                return Response<NoContent>.Fail("Güncellenecek kupon kalmadı", 404);
            }
            _mapper.Map(updateDiscountDto, existingResponse);
            _dapperContext.DiscountCouponses.Update(existingResponse);
            await _dapperContext.SaveChangesAsync();
            return Response<NoContent>.Success(204);

        }
    }
}
