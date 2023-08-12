using AutoMapper;
using MediatR;
using MicroService.Services.Order.Core.Application.Features.CQRS.Queries;
using MicroService.Services.Order.Core.Application.Interfaces;
using MicroService.Services.Order.Core.Domain.Entities;
using MicroService.Services.Ordering.Core.Application.Dtos.OrderDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casgem.MicroService.Services.Orde.Core.Application.Features.CQRS.Handlers
{
    public class GetAllOrderingQueryHandler : IRequestHandler<GetAllOrderingQueryRequest, List<ResultOrderingDto>>
    {
        private readonly IRepository<Ordering> _repository;

        public GetAllOrderingQueryHandler(IRepository<Ordering> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;
        public async Task<List<ResultOrderingDto>> Handle(GetAllOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultOrderingDto>>(values);
        }
    }
}