using Ecommerce.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using order_service_lambda.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace order_service_lambda.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        public OrderController(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await orderService.GetList());
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult> Get(string guid)
        {
            return Ok(await orderService.Get(guid));
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Order orderModel)
        {
            return Ok(await orderService.Post(orderModel));
        }

        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Order orderModel)
        {
            return Ok(await orderService.Put(orderModel));
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{guid}")]
        public async Task<ActionResult> Delete(string guid)
        {
            return Ok(await orderService.Delete(guid));
        }
    }
}
