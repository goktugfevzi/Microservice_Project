using MediatR;
using MicroService.Services.Order.Core.Application.Dtos.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Services.Order.Core.Application.Features.CQRS.Queries
{
    public class GetAllAddressQueryRequest : IRequest<List<ResultAddressDto>>
    {

      
    }
}
