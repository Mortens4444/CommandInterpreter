using System.Speech.Synthesis;

namespace CommandInterpreter.Commands
{
    public class Speak : ICommand
    {
        private readonly SpeechSynthesizer synth = new();

        public string Symbol => "🗣";

        public string Description => "Text-to-speech to read out the line.";

        public void Execute(string argument)
        {
            synth.Speak(argument.Trim());
        }
    }
}
