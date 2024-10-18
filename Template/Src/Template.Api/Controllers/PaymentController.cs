using Core.Uow;
using Microsoft.AspNetCore.Mvc;
using Template.Application;
using Template.Domain.Entities;

namespace Template.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [UnitOfWork(false)]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("{orderId}/Process")]
        public async Task<IActionResult> ProcessPayment(Guid orderId, [FromBody] PaymentMethod method)
        {
            await _paymentService.ProcessPayment(orderId, method);
            return Ok();
        }
    }
}
