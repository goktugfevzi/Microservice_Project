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
    public class EfCargoStateDal : GenericRepository<CargoState>,ICargoStateDal
    {
        public EfCargoStateDal(CargoContext context) : base(context) { }
    }
}
