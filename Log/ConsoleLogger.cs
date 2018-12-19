using System;

namespace Chemistry.Log
{
    public class ConsoleLogger : Logger
    {
        public override void Log(string content)
        {
            Console.WriteLine(content);
        }
    }
}