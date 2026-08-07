using Microsoft.AspNetCore.Mvc;

namespace GreetingsApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GreetingsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetGreeting()
        {
            return Ok(new
            {
                message = "Hii welcome to greetings app"
            });
        }
    }
}