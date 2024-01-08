using CommandService.Models;

namespace CommandService.Repository
{
    public interface ICommandRepository
    {
        public bool Create(Command command);
        public Command? GetById(int commandId);

        public ICollection<Command>? GetByPlatfromId(int platfromId);
    }
}
