using System;
using System.Diagnostics;
using System.Media;

namespace CommandInterpreter.Commands
{
    public class PlayAudio : ICommand
    {
        public string Symbol => "♪";

        public string Description => "Play an audio file.";

        public void Execute(string argument)
        {
            string audioFilePath = argument.Trim();
            if (File.Exists(audioFilePath))
            {
                if (Path.GetExtension(audioFilePath).Equals(".wav", StringComparison.InvariantCultureIgnoreCase))
                {
                    var player = new SoundPlayer(audioFilePath);
                    player.PlaySync();
                }
                else
                {
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {argument}") { CreateNoWindow = true });
                }
            }
            else
            {
                Console.WriteLine($"Error: Audio file not found at '{audioFilePath}'");
            }
        }
    }
}
