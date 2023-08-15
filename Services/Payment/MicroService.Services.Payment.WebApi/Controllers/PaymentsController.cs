using MicroService.Services.Payment.WebApi.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MicroService.Services.Payment.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly PaymentContext _context;

        public PaymentsController(PaymentContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult PaymentList()
        {
            var avlues = _context.PaymentDetails.ToList();
            return Ok(avlues);
        }


        [HttpPost]
        public IActionResult PaymentCreate(PaymentDetail paymentDetail)
        {
            _context.PaymentDetails.Add(paymentDetail);
            return Ok("Ödeme Yapıldı");
        }
    }
}
