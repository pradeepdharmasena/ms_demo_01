using CommandService.Models;

namespace CommandService.Repository
{
    public class CommandRepository : ICommandRepository
    {
        private readonly AppDbContext _appDbContext;

        public CommandRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }


        public bool Create(Command command)
        {
            _appDbContext.Commands.Add(command);
            _appDbContext.SaveChanges();
            return true;
        }

        public Command? GetById(int commandId)
        {
            try
            {
                Command? command = _appDbContext.Commands.FirstOrDefault(c => c.Id == commandId);
                if (command == null)
                {
                    return null;
                }
                return command;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ICollection<Command>? GetByPlatfromId(int platfromId)
        {
            try
            {
                Platform? platfrom = _appDbContext.Platforms.FirstOrDefault(c => c.Id == platfromId);
                if (platfrom == null)
                {
                    return null;
                }
                return platfrom.Commands;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
