﻿using AutoMapper;
using MediatR;
using MicroService.Services.Order.Core.Application.Dtos.AddressDtos;
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
    public class RemoveAddressCommandHandler : IRequestHandler<RemoveAddressCommandRequest>
    {
        private readonly IRepository<Address> _repository;

        public RemoveAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(RemoveAddressCommandRequest request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(value);

        }
    }
}
