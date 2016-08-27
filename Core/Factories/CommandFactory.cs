using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawIcn.Core.Factories
{
    using Interfaces;
    public class CommandFactory : ICommandFactory
    {
        private IDatabase database;
        private IAnimalFactory animalFactory;

        public IExecutable CreateCommand()
        {
            IExecutable command = null;

            return command;
        }
    }
}
