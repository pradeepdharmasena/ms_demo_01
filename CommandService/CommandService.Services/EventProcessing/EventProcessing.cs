using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using CommandService.Services.Dtos;
using CommandService.Repository;
using CommandService.Models;

namespace CommandService.Services.EventProcessing
{
    public class EventProcessing : IEventProcessing
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public EventProcessing(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }
        public void ProcessEvent(string message)
        {
            var eventType = DetermineEvent(message);

            switch (eventType)
            {
                case EventType.PlatformEvent:
                    SavePlatform(message);
                    break;
                default:
                    Console.WriteLine("Proccess Event Not a Platfrom");
                    break;
            }

        }

        private EventType DetermineEvent(string notification) 
        {
            var eventType = JsonSerializer.Deserialize<GenaricEventDto>(notification);
            if (eventType == null) 
            {
                return EventType.None;
            }
            switch (eventType.Event)
            {
                case "PlatformPublished":
                    return EventType.PlatformEvent;
                    
                default:
                    return EventType.None;
            }
        }

        private bool SavePlatform(string platform)
        {
            if (platform == null) 
            { 
                
            }

            using (var scope = _serviceScopeFactory.CreateScope()) 
            { 
                var repo = scope.ServiceProvider.GetRequiredService<IPlatformRepository>();
                var PlatformPublishDto =  JsonSerializer.Deserialize<PlatformPublishDto>(platform);

                Platform platformObj = new Platform();
                platformObj.ExternalId = PlatformPublishDto.ExternalId;
                platformObj.Name = PlatformPublishDto.Name;

                try
                {
                    return repo.Create(platformObj);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occured in Saving platform : " + ex.Message);
                    return false;
                }
            }
        }
    }

    enum EventType
    {
        None,
        PlatformEvent
    }
}
