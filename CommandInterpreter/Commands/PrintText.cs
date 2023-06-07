namespace CommandInterpreter.Commands
{
    public class PrintText : ICommand
    {
        public string Symbol => "🖨";

        public string Description => "Print text to command line.";

        public void Execute(string argument)
        {
            Console.WriteLine(argument);
        }
    }
}
