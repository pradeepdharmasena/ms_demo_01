using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandService.Services.EventProcessing
{
    public interface IEventProcessing
    {
        public void ProcessEvent(string message);
    }
}
