using Microservice.Services.Cargo.DataAccessLayer.Abstract;
using Microservice.Services.Cargo.DataAccessLayer.Context;
using Microservice.Services.Cargo.DataAccessLayer.Repository;
using Microservice.Services.Cargo.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservice.Services.Cargo.DataAccessLayer.EntityFramework
{
    public class EfCargoDetailDal : GenericRepository<CargoDetail>, ICargoDetailDal
    {
        public EfCargoDetailDal(CargoContext cargoContext) : base(cargoContext)
        {

        }
    }
}
