using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Services.Order.Core.Application.Dtos.OrderDetailDtos
{
    public class CreateOrderDetailDto
    {
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public int OrderID { get; set; }
    }
}
