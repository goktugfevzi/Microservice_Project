﻿using MediatR;
using MicroService.Services.Order.Core.Application.Dtos.AddressDtos;
using MicroService.Services.Order.Core.Application.Dtos.OrderDetailDtos;
using MicroService.Services.Ordering.Core.Application.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Services.Order.Core.Application.Features.CQRS.Queries
{
    public class GetByIdOrderDetailQueryRequest : IRequest<ResultOrderDetailDto>
    {
        public int Id { get; set; }

        public GetByIdOrderDetailQueryRequest(int id)
        {
            Id = id;
        }
    }
}