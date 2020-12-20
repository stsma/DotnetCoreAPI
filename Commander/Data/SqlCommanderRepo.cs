using System.Collections.Generic;
using System.Linq;
using Commander.Models;
using System;

namespace Commander.Data
{
    public class SqlCommanderRepo: ICommanderRepo
    {
        private readonly CommanderContext _dbContext;
        public SqlCommanderRepo(CommanderContext dbContext)
        {
            _dbContext = dbContext;   
        }

        public void CreateCommand(Command cmd)
        {
            if(cmd == null) throw new ArgumentNullException(nameof(cmd));
            _dbContext.Add(cmd);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _dbContext.Commands;
        }

        public Command GetCommandById(int id)
        {
            return _dbContext.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges() >= 0;
        }

        public void DeleteCommand(Command cmd)
        {
            if (cmd == null)
                throw new NullReferenceException();
            else
                _dbContext.Remove(cmd);
        }

        public void UpdateCommand(Command cmd)
        {
            //
        }
    }
}