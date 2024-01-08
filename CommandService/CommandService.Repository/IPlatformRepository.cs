using CommandService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandService.Repository
{
    public interface IPlatformRepository
    {
        public bool Create(Platform platform);
    }
}
