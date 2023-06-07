using CommandInterpreter;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;

        Console.OutputEncoding = Encoding.UTF8;
        var commandFactory = new CommandFactory();

        if (args.Length == 0)
        {
            args = new string[] { "CommandsSample.txt" };
            //var commandDescriptions = string.Join(Environment.NewLine, commandFactory.Commands.Select(command => $"{command.Key} {command.Value.Description}"));
            //Console.WriteLine("This is a command-line application which accepts a text file.\n" +
            //    "The lines are parsed from the file.\n" +
            //    "The first character will decide what command should be executed.\n\n" + commandDescriptions);
            //return;
        }

        var lines = File.ReadAllLines(args[0]);
        foreach (string line in lines)
        {
            if (line.Length > 0)
            {
                string commandSymbol = line[..2];
                string argument = line[2..];

                var command = commandFactory.Get(commandSymbol);
                command?.Execute(argument);
            }
        }
    }

    private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
        Console.Error.WriteLine($"An unhandled exception occurred: {((Exception)e.ExceptionObject).Message}\n{((Exception)e.ExceptionObject).StackTrace}");
    }
}