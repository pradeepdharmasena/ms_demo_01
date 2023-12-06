using PlatformService.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Services.DataSyncing
{
    public interface ICommandDataClient
    {
        public  Task SendFromPlatformToCommand(PlatformReadDto platformReadDto);
    }
}
