using CommandService.Repository;
using Command = CommandService.Models.Command;

namespace CommandService.Services
{
    public class CommandService : ICommandService
    {
        private readonly ICommandRepository _commandRepository;

        public CommandService(ICommandRepository commandRepository) 
        { 
            _commandRepository = commandRepository;
        }
        public bool Create(Command command)
        { 
            return _commandRepository.Create(command);
        }

        public Command? GetById(int commandId)
        {
            return _commandRepository.GetById(commandId);
        }

        public ICollection<Command>? GetByPlatformId(int platformId)
        {
            return _commandRepository.GetByPlatfromId(platformId);
        }
    }
}
