using PlatformService.Services.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlatformService.Services.DataSyncing
{
    public class CommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;

        public CommandDataClient(HttpClient httpClient) {
            _httpClient = httpClient;
        }
        public async Task SendFromPlatformToCommand(PlatformReadDto platformReadDto)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(platformReadDto),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync("http://command-cluster-ip-service.default.svc.cluster.local:80/Command", httpContent);
            //https://localhost:7223/Command
            //http://command-cluster-ip-service:80/Command
            //command-cluster-ip-service.default.svc.cluster.local
            //10.1.0.91:80
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Sync post to command Service is completed....");
            }
            else
            {
                Console.WriteLine("Sync post to command Service is unable to complete....");
            }
        }
    }
}
