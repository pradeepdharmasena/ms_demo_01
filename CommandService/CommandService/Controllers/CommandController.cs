using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [ApiController]
    [Route("/c/command")]
    public class CommandController : ControllerBase
    {
        

        private readonly ILogger<CommandController> _logger;

        

        [HttpGet]
        public ActionResult get()
        {
            return Ok("Command Server up and runing...");
        }

        [HttpPost]
        public ActionResult testConnection() {
            Console.WriteLine("Recived the Data");
            return Ok("Recived the Data");
        }
        
    }
}