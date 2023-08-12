
using AutoMapper;
using MediatR;
using MicroService.Services.Order.Core.Application.Features.CQRS.Queries;
using MicroService.Services.Order.Core.Application.Interfaces;
using MicroService.Services.Order.Core.Domain.Entities;
using MicroService.Services.Order.Core.Application.Dtos.AddressDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Casgem.MicroService.Services.Orde.Core.Application.Features.CQRS.Handlers
{
    public class GetAllAdressQueryHandler : IRequestHandler<GetAllAddressQueryRequest, List<ResultAddressDto>>
    {
        private readonly IRepository<Address> _repository;

        public GetAllAdressQueryHandler(IRepository<Address> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        private readonly IMapper _mapper;
        public async Task<List<ResultAddressDto>> Handle(GetAllAddressQueryRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultAddressDto>>(values);
        }
    }
}