using AutoMapper;
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
    public class UpdateOrderDetailCommandHandler : IRequestHandler<UpdateOrderDetailCommandRequest>
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommandRequest request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.OrderDetailID);

            values.ProductName = request.ProductName;
            values.ProductPrice = request.ProductPrice;
            values.ProductID = request.ProductID;
            values.ProductAmount = request.ProductAmount;
            values.OrderingID = request.OrderingID;

            await _repository.UpdateAsync(values);
        }
    }
}
//public int OrderDetailID { get; set; }
//public string ProductID { get; set; }
//public string ProductName { get; set; }
//public string ProductPrice { get; set; }
//public int ProductAmount { get; set; }
//public int OrderingID { get; set; }