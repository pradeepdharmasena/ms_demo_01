using CommandService.Models;
using CommandService.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandService.Services
{
    public interface IPlatformService
    {
        public bool Create(PlatformPublishDto platformPublishDto);
    }
}
