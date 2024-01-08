using CommandService.Models;
using CommandService.Repository;
using CommandService.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandService.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;

        public PlatformService(IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
        }

        public bool Create(PlatformPublishDto platformPublishDto)
        {
            Platform platform = new Platform();
            platform.Name = platformPublishDto.Name;
            platform.ExternalId = platformPublishDto.ExternalId;
            return _platformRepository.Create(platform);
        }
    }
}
