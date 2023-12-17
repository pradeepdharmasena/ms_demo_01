using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlatformService.Models;
using PlatformService.Repository;
using PlatformService.Services.Dtos;
using System.Runtime.CompilerServices;

namespace PlatformService.Services
{
    public class PlatformsService : IPlatformsService
    {
        private AppDbContext _dbContext;
        private readonly IMapper _mapper;

        //AppDbContext appdbContex,
        public PlatformsService(IMapper mapper)
        {
            _dbContext =  new AppDbContext();
            _mapper = mapper;
        }
        public List<PlatformReadDto> GetAll()
        {
            var result = _dbContext.Platforms.ToList();
            return _mapper.Map<List<PlatformReadDto>>(result);
            
        }

        public  PlatformReadDto Save(PlatformCreateDto platformCreateDto)
        {
            try
            {
                Platform platform = _mapper.Map<Platform>(platformCreateDto);
                _dbContext.Add(platform);
                _dbContext.SaveChangesAsync();
                return _mapper.Map<PlatformReadDto>(platform);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public PlatformReadDto GetById(int id)
        {
            try
            {
                var result = _dbContext.Platforms.FirstOrDefault(t => t.Id == id);
                var platformReadDto = _mapper.Map<PlatformReadDto>(result);
                return platformReadDto;
            }catch (Exception ex)
            {
                throw new Exception($"{ex.Message}");
            }
        }
    }
}