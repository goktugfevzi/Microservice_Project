using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Services.Ordering.Core.Application.Dtos.OrderDtos
{
    public class UpdateOrderingDto
    {
        public int OrderDetailID { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }
        public int ProductAmount { get; set; }
        public int OrderingID { get; set; }
    }
}
