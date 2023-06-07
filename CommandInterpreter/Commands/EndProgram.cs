namespace CommandInterpreter.Commands
{
    public class EndProgram : ICommand
    {
        public string Symbol => "🚫";

        public string Description => "End this application with the specified error code.";

        public void Execute(string argument)
        {
            var errorCode = Int32.Parse(argument);
            Environment.Exit(errorCode);
        }
    }
}
