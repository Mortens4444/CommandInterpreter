namespace CommandInterpreter.Commands
{
    public class Wait : ICommand
    {
        public string Symbol => "⏳";

        public string Description => "Sleep for the given milliseconds.";

        public void Execute(string argument)
        {
            var milliseconds = Int32.Parse(argument);
            Thread.Sleep(milliseconds);
        }
    }
}
