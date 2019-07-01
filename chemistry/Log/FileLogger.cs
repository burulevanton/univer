using System.IO;

namespace Chemistry.Log
{
    public class FileLogger:Logger
    {
        public string LogPath { get; set; }

        public override void Log(string content)
        {
            using (StreamWriter writer = File.AppendText(LogPath))
            {
                writer.WriteLine(content);
            }
        }
    }
}