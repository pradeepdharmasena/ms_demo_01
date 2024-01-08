using CommandService.Services;
using CommandService.Services.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Formats.Asn1;

namespace CommandService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformService _platformService;

        public PlatformController(IPlatformService platformService)
        {
            _platformService = platformService;
        }
        [HttpPost]

        public async Task Create(PlatformPublishDto platformPublishDto)
        {
            Console.WriteLine("--> Platfrom Controller Triggered... " + platformPublishDto.Name);
           await Task.Run(() => _platformService.Create(platformPublishDto)) ;
        }
    }
}
