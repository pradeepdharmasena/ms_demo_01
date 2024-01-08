using CommandService.Models;

namespace CommandService.Services
{
    public interface ICommandService
    {
        public bool Create(Command command);

        public Command? GetById(int commandId);

        public ICollection<Command>? GetByPlatformId(int platformId);
    }
}
