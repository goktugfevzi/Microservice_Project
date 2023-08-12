using AutoMapper;
using MediatR;
using MicroService.Services.Order.Core.Application.Interfaces;
using MicroService.Services.Ordering.Core.Application.Dtos.OrderDtos;
using MicroService.Services.Order.Core.Application.Dtos;
using MicroService.Services.Order.Core.Application.Features.CQRS.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroService.Services.Order.Core.Domain.Entities;

namespace MicroService.Services.Order.Core.Application.Features.CQRS.Handlers
{
    public class GetAllOrderingQueryHandler : IRequestHandler<GetAllOrderingQueryRequest, List<ResultOrderingDto>>
    {
        private readonly IRepository<Ordering1> _repository;
        private readonly IMapper _mapper;

        public GetAllOrderingQueryHandler(IRepository<Ordering1> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ResultOrderingDto>> Handle(GetAllOrderingQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultOrderingDto>>(values);
        }
    }
}