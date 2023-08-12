using AutoMapper;
using MicroService.Services.Order.Core.Domain;
using MicroService.Services.Ordering.Core.Application.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Services.Order.Core.Application.Mappings
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<ResultOrderingDto, Domain.Entities.Ordering>().ReverseMap();
            CreateMap<CreateOrderingDto, Domain.Entities.Ordering>().ReverseMap();
            CreateMap<UpdateOrderingDto, Domain.Entities.Ordering>().ReverseMap();
        }
    }
}
