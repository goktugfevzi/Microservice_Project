using Microservice.Services.Cargo.BusinessLayer.Abstract;
using Microservice.Services.Cargo.DataAccessLayer.Abstract;
using Microservice.Services.Cargo.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Services.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoList()
        {
            var values = _cargoDetailService.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult CargoDetailGet(int id)
        {
            var value = _cargoDetailService.GetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CargoStateCreate(CargoDetail cargoDetail)
        {
            _cargoDetailService.Insert(cargoDetail);
            return Ok("Kargo Detayı Ekleme");
        }
        [HttpPut]
        public IActionResult CargoDetailUpdate(CargoDetail cargoDetail)
        {
            _cargoDetailService.Update(cargoDetail);
            return Ok("Kargo Detayı Güncellendi");
        }
        [HttpDelete]
        public IActionResult CargoDetailDelete(CargoDetail cargoDetail)
        {
            _cargoDetailService.Delete(cargoDetail);
            return Ok("Kargo Detayı Silindi");
        }
    }
}
