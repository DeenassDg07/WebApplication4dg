using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using MyMediator.Interfaces;
using MyMediator.Types;
using WebApplication4dg.sqrs.Registration;

namespace WebApplication4dg.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class RegisterController(IMediator mediator) : Controller
        {
            private readonly IMediator mediator = mediator;

            [HttpPost("/register")]
            public async Task<ActionResult> RegisterUser(RegisterDTO user)
            {
                var command = new Register() { User = user }; ;
                await mediator.SendAsync(command);
                return Ok();
            }
        }
}


