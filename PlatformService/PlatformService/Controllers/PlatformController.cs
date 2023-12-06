using Microsoft.AspNetCore.Mvc;
using PlatformService.Services;
using PlatformService.Services.DataSyncing;
using PlatformService.Services.Dtos;

namespace PlatformService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformsService _platformService;
        private readonly ICommandDataClient _commandDataClient;

        public PlatformController(
            IPlatformsService platformService,
            ICommandDataClient commandDataClient)
        {
            _platformService = platformService;
            _commandDataClient = commandDataClient;
        }

        [HttpGet]
        public ActionResult<IEnumerable<PlatformCreateDto>> Get()
        {
            var result = _platformService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<IEnumerable<PlatformCreateDto>> GetById(int id)
        {
            var result = _platformService.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<PlatformCreateDto>> Create(PlatformCreateDto platformCreateDto)
        {
            PlatformReadDto platformReadDto = _platformService.Save(platformCreateDto);

            try
            {
                await _commandDataClient.SendFromPlatformToCommand(platformReadDto);
            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(ex.ToString());
            }

            return Ok(platformReadDto);
        }
    }
}