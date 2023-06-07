using System.Diagnostics;

namespace CommandInterpreter.Commands
{
    public class OpenUrl : ICommand
    {
        public string Symbol => "🔗";

        public string Description => "Open an URL.";

        public void Execute(string argument)
        {
            string url = argument.Trim();
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
    }
}
