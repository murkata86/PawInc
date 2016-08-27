namespace PawIcn.Interfaces
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretateCommand(string[] data);
    }
}
