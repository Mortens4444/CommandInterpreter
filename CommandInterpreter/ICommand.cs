namespace CommandInterpreter
{
    public interface ICommand
    {
        string Symbol { get; }

        string Description { get; }

        void Execute(string argument);
    }
}
