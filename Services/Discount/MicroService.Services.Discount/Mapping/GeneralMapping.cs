using AutoMapper;
using MicroService.Services.Discount.Dtos;
using MicroService.Services.Discount.Models;

namespace MicroService.Services.Discount.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<DiscountCoupons, ResultDiscountDto>().ReverseMap();
            CreateMap<DiscountCoupons, CreateDiscountDto>().ReverseMap();
            CreateMap<DiscountCoupons, UpdateDiscountDto>().ReverseMap();

        }
    }
}
