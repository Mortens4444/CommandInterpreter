namespace CommandInterpreter
{
    public class CommandFactory
    {
        public Dictionary<string, ICommand> Commands = new();

        public CommandFactory()
        {
            var commandType = typeof(ICommand);
            var commandTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => commandType.IsAssignableFrom(p) && !p.IsInterface);

            foreach (var type in commandTypes)
            {
                var cmd = (ICommand)Activator.CreateInstance(type)!;
                Commands.Add(cmd.Symbol, cmd);
            }
        }

        public ICommand Get(string symbol)
        {
            if (Commands.TryGetValue(symbol.Trim(), out ICommand? command))
            {
                return command;
            }
            else
            {
                throw new ArgumentException($"No command found for symbol: {symbol}");
            }
        }
    }
}
