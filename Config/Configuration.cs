using Chemistry.Log;

namespace Chemistry.Config
{
    public class Configuration
    {
        private static Logger logger;

        public static void Load(string configPath = "F:\\Chemistry\\Chemistry\\config.cfg")
        {
            var config = ConfigReader.ReadConfig(configPath);
            var logType = config["log_type"];
            if (logType == "file")
            {
                logger = new FileLogger();
                var logPath = config["log_path"];
                ((FileLogger) logger).LogPath = logPath;
            }
            else
                logger = new ConsoleLogger();

        }
    }
}