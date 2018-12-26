using System.Collections.Generic;
using System.IO;
using Chemistry.Log;

namespace Chemistry.Config
{
    public static class Configuration
    {
        private static Logger _logger;

        private static Dictionary<string, string> ReadConfig(string filePath)
        {
            var config = new Dictionary<string, string>();
            var lines = File.ReadLines(filePath);
            foreach (var line in lines)
            {
                var trimmedLine = line.Trim();
                if (trimmedLine.StartsWith("$")) continue;
                var split = line.Split(' ');
                config[split[0]] = split[1];
            }

            return config;
        }
        
        public static void Load(string configPath = "F:\\Chemistry\\Chemistry\\config.cfg")
        {
            var config = ReadConfig(configPath);
            var logType = config["log_type"];
            if (logType == "file")
            {
                _logger = new FileLogger();
                var logPath = config["log_path"];
                ((FileLogger) _logger).LogPath = logPath;
            }
            else
                _logger = new ConsoleLogger();

        }
    }
}