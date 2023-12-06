using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformService.Services.Dtos
{
    public class PlatformReadDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        
        public string Publisher { get; set; }
        
        public string Version { get; set; }
    }
}
