using Microsoft.AspNetCore.Mvc;
using MyMediator.Interfaces;
using MyMediator.Types;
using WebApplication4dg.sqrs.Order;

namespace WebApplication4dg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateOrderController : Controller
    {

        private readonly IMediator mediator;
        public CreateOrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("CreateOrder")]
        public async Task<ActionResult> CreateOrder(OrderDTO order)
        {
            var command = new CreateOrder { Order = order };
            await mediator.SendAsync(command);


            return BadRequest("Ожидайте одобрения заявки");
        }  
    }
}