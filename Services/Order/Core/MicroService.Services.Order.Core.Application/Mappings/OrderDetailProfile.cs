using AutoMapper;
using MicroService.Services.Order.Core.Application.Dtos.OrderDetailDtos;
using MicroService.Services.Order.Core;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroService.Services.Order.Core.Domain.Entities;

namespace MicroService.Services.Order.Core.Application.Mappings
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<ResultOrderDetailDto, OrderDetail>().ReverseMap();
            CreateMap<CreateOrderDetailDto, OrderDetail>().ReverseMap();
            CreateMap<UpdateOrderDetailDto, OrderDetail>().ReverseMap();
        }
    }
}
