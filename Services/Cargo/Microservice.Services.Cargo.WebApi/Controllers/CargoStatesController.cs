using Microservice.Services.Cargo.BusinessLayer.Abstract;
using Microservice.Services.Cargo.EntityLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Microservice.Services.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoStatesController : ControllerBase
    {
        private readonly ICargoStateService _stateService;

        public CargoStatesController(ICargoStateService stateService)
        {
            _stateService = stateService;
        }


        [HttpGet]
        public IActionResult CargoList()
        {
            var values = _stateService.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult CargoStateGet(int id)
        {
            var value = _stateService.GetById(id);
            return Ok(value);
        }
        [HttpPost]
        public IActionResult CargoStateCreate(CargoState cargoState)
        {
            _stateService.Insert(cargoState);
            return Ok("Kargo Durumu Ekleme");
        }
        [HttpPut]
        public IActionResult CargoStateUpdate(CargoState cargoState)
        {
            _stateService.Update(cargoState);
            return Ok("Kargo Durumu Güncellendi");
        }
        [HttpDelete]
        public IActionResult CargoStateDelete(CargoState cargoState)
        {
            _stateService.Delete(cargoState);
            return Ok("Kargo Durumu Silindi");
        }
    }
}
