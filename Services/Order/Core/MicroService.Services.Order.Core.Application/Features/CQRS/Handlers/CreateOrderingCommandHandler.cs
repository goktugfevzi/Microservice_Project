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
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommandRequest>
    {
        private readonly IRepository<Ordering1> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering1> repository)
        {
            _repository = repository;
        }

        public Task Handle(CreateOrderingCommandRequest request, CancellationToken cancellationToken)
        {
            var value = new Ordering1
            {

                TotalPrice = request.TotalPrice,
                OrderingDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                UserID = request.UserID
            };
            return _repository.CreateAsync(value);
        }
    }
}