using AutoMapper;
using MediatR;
using MicroService.Services.Order.Core.Application.Dtos;
using MicroService.Services.Order.Core.Application.Features.CQRS.Commands;
using MicroService.Services.Order.Core.Application.Interfaces;
using MicroService.Services.Order.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Services.Order.Core.Application.Features.CQRS.Handlers
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommandRequest>
    {
        private readonly IRepository<Ordering1> _repository;

        public RemoveOrderingCommandHandler(IRepository<Ordering1> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
           
                await _repository.DeleteAsync(value);
          
        }
    }
}