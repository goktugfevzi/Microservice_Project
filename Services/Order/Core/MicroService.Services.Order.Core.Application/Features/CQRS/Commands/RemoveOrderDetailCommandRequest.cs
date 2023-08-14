using AutoMapper;
using MediatR;
using MicroService.Services.Order.Core.Application.Dtos.AddressDtos;
using MicroService.Services.Order.Core.Application.Interfaces;
using MicroService.Services.Order.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Services.Order.Core.Application.Features.CQRS.Commands
{
    public class RemoveOrderDetailCommandRequest : IRequest
    {
        public RemoveOrderDetailCommandRequest(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
