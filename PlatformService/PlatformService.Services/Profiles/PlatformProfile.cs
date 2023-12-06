using AutoMapper;
using PlatformService.Models;
using PlatformService.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Services.Profiles
{
    internal class PlatformProfile : Profile
    {
        public PlatformProfile()
        {
            CreateMap<Platform, PlatformCreateDto>();
            CreateMap<PlatformCreateDto, Platform>();
            CreateMap<PlatformReadDto, Platform>();
            CreateMap<Platform, PlatformReadDto>();
        }
    }
}
