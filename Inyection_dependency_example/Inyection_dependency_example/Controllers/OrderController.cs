using Inyection_dependency_example.DTOs;
using Inyection_dependency_example.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Inyection_dependency_example.Controllers
{

    [ApiController]
    [Route("api/Order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrder orderService;


        public OrderController(IOrder orderService)
        {
            this.orderService = orderService;
        }



        [HttpPost("Create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderDTO order)
        {
            var id = await orderService.CreateOrder(order);

            return Ok(new
            {
                message = "La orden se a creado exitosamente :)",
                orderId = id
            });
        }
    }
}