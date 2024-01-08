using CommandService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandService.Repository
{
    public class PlatformRepository : IPlatformRepository
    {
        private readonly AppDbContext _appDbContext;

        public PlatformRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
            
        }

        public bool Create(Platform platform)
        {
            try
            {
                _appDbContext.Add(platform);
                _appDbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured in saving platform : " + ex.Message);
                return false;
            }
        }
        
    }
}
