using CommandService.Models;
using CommandService.Services;
using CommandService.Services.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace CommandService.Controllers
{
    [ApiController]
    [Route("/c/command")]
    public class CommandController : ControllerBase
    {
        

        private readonly ICommandService _commmandService;

        public CommandController(ICommandService commandService)
        {
            _commmandService = commandService;
        }

        [HttpGet]
        public ActionResult GetByPlatfromId([FromQuery] int platfromId)
        {
            return Ok(_commmandService.GetByPlatformId(platfromId));

        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetById(int id)
        { 
            Command? command = _commmandService.GetById(id);
            if (command == null) 
            {
                return Ok("sorry... No such command for " + id);
            }
            return Ok(command);
        }

        [HttpPost]
        [Route("/create")]
        public ActionResult Create(Command command)
        {
            bool isCreated = _commmandService.Create(command);
            return Ok(isCreated);
        }

        [HttpPost]
        public ActionResult testConnection(PlatformPublishDto platformPublishDto) {
            Console.WriteLine("Recived the Data" + platformPublishDto.Name);
            return Ok("Recived the Data");
        }
        
    }
}