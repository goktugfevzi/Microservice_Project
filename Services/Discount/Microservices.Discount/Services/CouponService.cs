using Dapper;
using Microservices.Discount.Dtos;
using MicroServices.Shared.Dtos;
using Npgsql;
using System.Data;
using System.Data.Common;

namespace Microservices.Discount.Services
{
    public class CouponService : ICouponService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbconnection;

        public CouponService(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbconnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<Response<NoContent>> CreateCoupon(CreateCouponDto createCouponDto)
        {
            var values = await _dbconnection.ExecuteAsync("Insert Into Coupon (Rate,Code,CreatedTime) VALUES (@Rate,@Code,@CreatedTime)", createCouponDto);

            if (values > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Ekleme Sırasında Hata oluşttu", 500);
        }



        public async Task<Response<NoContent>> DeleteCoupon(int id)
        {
            var values = await _dbconnection.ExecuteAsync("delete from coupon where CouponID=@CouponID",
                new { CouponID = id });
            return values > 0 ? Response<NoContent>.Success(204) : Response<NoContent>.Fail("Kupon bulunmadı", 404);
        }

        public async Task<Response<List<ResultCouponDto>>> GetCouponList()
        {
            var values = await _dbconnection.QueryAsync<ResultCouponDto>("Select * From Coupon");
            return Response<List<ResultCouponDto>>.Success(values.ToList(), 200);
        }

        public async Task<Response<ResultCouponDto>> GetCouponByID(int id)
        {
            var values = (await _dbconnection.QueryAsync<ResultCouponDto>("select * from Coupon WHERE CouponID=@CouponID")).FirstOrDefault();
            var parameters = new DynamicParameters();
            parameters.Add("@CouponID", id);
            if (values == null)
            {
                return Response<ResultCouponDto>.Fail("Kupon Bulunamadı", 404);
            }
            return Response<ResultCouponDto>.Success(values, 200);
        }

        public async Task<Response<NoContent>> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            var values = await _dbconnection.ExecuteAsync("UPDATE Coupon SET  Code=@Code,Rate=@Rate WHERE CouponID=@CouponID");
            var parameters = new DynamicParameters();
            parameters.Add("@Rate", updateCouponDto.Rate);
            parameters.Add("@Code", updateCouponDto.Code);
            parameters.Add("@CouponID", updateCouponDto.CouponID);

            if (values > 0)
            {
                return Response<NoContent>.Success(204);
            }
            return Response<NoContent>.Fail("Kupon bulunamadı", 404);
        }
    }
}
