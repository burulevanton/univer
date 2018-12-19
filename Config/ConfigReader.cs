using System.Collections.Generic;
using System.IO;

namespace Chemistry.Config
{
    public class ConfigReader
    {
        public static Dictionary<string, string> ReadConfig(string filePath)
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
    }
}