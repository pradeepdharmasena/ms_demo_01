using PlatformService.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Services
{
    public interface IPlatformsService
    {
        public List<PlatformReadDto>  GetAll();

        public  PlatformReadDto Save(PlatformCreateDto platformGetDto);
        public PlatformReadDto GetById(int id);
    }
}
