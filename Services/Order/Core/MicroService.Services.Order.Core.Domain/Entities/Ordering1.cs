using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroService.Services.Order.Core.Domain.Entities
{
    public class Ordering1
    {
        public int Ordering1ID { get; set; }
        public string UserID { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime OrderingDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}
