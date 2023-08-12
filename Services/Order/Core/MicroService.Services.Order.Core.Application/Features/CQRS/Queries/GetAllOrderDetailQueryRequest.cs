using MediatR;
using MicroService.Services.Ordering.Core.Application.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Services.Order.Core.Application.Features.CQRS.Queries
{
    public class GetAllOrderDetailQueryRequest : IRequest<List<ResultOrderingDto>>
    {

    }
}
