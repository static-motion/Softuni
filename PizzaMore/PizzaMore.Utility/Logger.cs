using System.IO;

namespace PizzaMore.Utility
{
    public static class Logger
    {
        public static void Log(string log)
        {
            File.AppendAllText("log.txt", log+"\r\n");
        }
    }
}