using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Services.Cargo.EntityLayer.Entities
{
    public class CargoDetail
    {
        public int CargoDetailID { get; set; }
        public int OrdersID { get; set; }
        public int CargoStateID { get; set; }
        public CargoState CargoState { get; set; }
    }
}
