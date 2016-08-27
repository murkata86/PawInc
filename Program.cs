namespace PawIcn
{
    using Core;
    using Core.Factories;
    using Core.Factory;
    using Interfaces;
    using UI;

    class Program
    {
        static void Main()
        {
            InputReader reader = new InputReader();
            OutputWriter writer = new OutputWriter();
            IDatabase db = new Database();
            IAnimalFactory animalFactory = new AnimalFactory();
            ICommandFactory commandFactory = new CommandFactory();
            ICommandInterpreter commandInterpreter = new CommandInterpreter(db,animalFactory, commandFactory,writer);

            Engine engine = new Engine(db, commandInterpreter, reader, writer);
            engine.Run();
        }
    }
}
