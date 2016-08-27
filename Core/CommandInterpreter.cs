namespace PawIcn.Core
{
    using System.Linq;
    using Interfaces;
    using Models.Commands;
    using UI;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IDatabase database;
        private IAnimalFactory animalFactory;
        private ICommandFactory commnadFactory;
        private OutputWriter writer;

        public CommandInterpreter(IDatabase database, IAnimalFactory animalFactory, ICommandFactory commandFactory, OutputWriter writer)
        {
            this.Databse = database;
            this.AnimalFactory = animalFactory;
            this.CommandFactory = commandFactory;
            this.Writer = writer;
        }

        public OutputWriter Writer
        {
            get { return this.writer; }

            private set { this.writer = value; }
        }

        public IDatabase Databse
        {
            get { return this.database; }

            private set { this.database = value; }
        }

        public IAnimalFactory AnimalFactory
        {
            get { return this.animalFactory; }

            private set { this.animalFactory = value; }
        }

        public ICommandFactory CommandFactory
        {
            get { return this.commnadFactory; }

            private set { this.commnadFactory = value; }
        }

        public IExecutable InterpretateCommand(string[] data)
        {
            IExecutable command = null;

            string commandName = data[0];
            string[] commandParams = data.Skip(1).ToArray();

            switch (commandName)
            {
                case "RegisterCleansingCenter":
                    command = new RegisterCleansingCenter(commandParams, this.Databse);
                    break;
                case "RegisterAdoptionCenter":
                    command = new RegisterAdoptionCenter(commandParams, this.Databse);
                    break;
                case "RegisterCastrationCenter":
                    command = new RegisterCastratingCenter(commandParams, this.Databse);
                    break;
                case "RegisterDog":
                    command = new RegisterDog(commandParams, this.Databse, this.AnimalFactory);
                    break;
                case "RegisterCat":
                    command = new RegisterCat(commandParams, this.Databse, this.AnimalFactory);
                    break;
                case "SendForCleansing":
                    command = new SendForCleansing(commandParams, this.Databse);
                    break;
                case "SendForCastration":
                    command = new SendForCastrating(commandParams, this.Databse);
                    break;
                case "Cleanse":
                    command = new Cleanse(commandParams, this.Databse);
                    break;
                case "Castrate":
                    command= new Castrate(commandParams, this.Databse);
                    break;
                case "Adopt":
                    command = new Adopt(commandParams, this.Databse);
                    break;
                case "CastrationStatistics":
                    command = new CastrationStatistics(commandParams, this.Databse, this.writer);
                    break;
                case "Paw Paw Pawah":
                    command = new PawPawPawah(commandParams, this.Databse, this.Writer);
                    break;
            }
            return command;
        }
    }
}
