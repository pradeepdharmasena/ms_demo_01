using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandService.Services.Dtos
{
    public  class PlatformPublishDto
    {

        public int ExternalId { get; set; }

        public string Name { get; set; }
    }
}
