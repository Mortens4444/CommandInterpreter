using System.Diagnostics;

namespace CommandInterpreter.Commands
{
    public class StartProcess : ICommand
    {
        public string Symbol => "⚙️";

        public string Description => "Start a new process.";

        public void Execute(string argument)
        {
            Process.Start(argument);
        }
    }
}
