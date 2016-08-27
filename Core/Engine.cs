namespace PawIcn.Core
{
    using System;
    using Interfaces;
    using UI;

    public class Engine
    {
        private IDatabase database;
        private IAnimalFactory animalFactory;
        private ICommandInterpreter commandInterpreter;
        private InputReader reader;
        private OutputWriter writer;

        public Engine(IDatabase database ,ICommandInterpreter commandInterpreter, InputReader reader, OutputWriter writer)
        {
            this.CommandInterpreter = commandInterpreter;
            this.Reader = reader;
            this.Database = database;
            this.Writer = writer;
        }

        public ICommandInterpreter CommandInterpreter
        {
            get { return this.commandInterpreter;}

            private set { this.commandInterpreter = value; }
        }

        public InputReader Reader
        {
            get { return this.reader; }

            private set { this.reader = value; }
        }

        public IDatabase Database
        {
            get { return this.database; }

            private set { this.database = value; }
        }

        public OutputWriter Writer
        {
            get { return this.writer; }

            private set { this.writer = value; }
        }

        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadInput();

                if (input == "Paw Paw Pawah")
                {
                    this.Writer.WriteOutput(this.database.Statistics());
                    break;
                }

                string[] data = input.Split(new[] {'|', ' '}, StringSplitOptions.RemoveEmptyEntries);

                IExecutable command = this.CommandInterpreter.InterpretateCommand(data);

                command.Execute();
            }
        }
    }
}
