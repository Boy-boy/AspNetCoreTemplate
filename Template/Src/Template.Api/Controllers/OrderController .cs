using Core.Uow;
using Microsoft.AspNetCore.Mvc;
using Template.Application;
using Template.Infrastructure.Dtos;

namespace Template.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [UnitOfWork(false)]
    public class OrderController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrderController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] List<CreateOrderItemDto> orderItems)
        {
            await _orderService.CreateOrder(orderItems);
            return Ok();
        }

        [HttpPut("{orderId}/confirm")]
        public async Task<IActionResult> ConfirmOrder(Guid orderId)
        {
            await _orderService.ConfirmOrder(orderId);
            return Ok();
        }

        [HttpPut("{orderId}/cancel")]
        public async Task<IActionResult> CancelOrder(Guid orderId)
        {
            await _orderService.CancelOrder(orderId);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrders()
        {
            return await _orderService.GetAllOrders();
        }
    }
}
