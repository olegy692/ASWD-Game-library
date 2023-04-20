using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibAssignment
{
    /// <summary>
    /// Class with method to make logs to a file with specific path and log to console
    /// Static so we can access its method directly from other classes without passing it to constructors. 
    /// </summary>
    public static class Logger
    {
        private static string _logFilePath = "C:\\Users\\olegs\\source\\repos\\TestGameLibAssign\\log.txt";

        public static void Log(string message, string? logFilePath = null)
        {
            if (logFilePath != null)
            {
                _logFilePath = logFilePath; 
            }

            Console.WriteLine(message);

            using (StreamWriter writer = new StreamWriter(_logFilePath, true))
            {
                writer.WriteLine($"{DateTime.Now}: {message}");
            }
        }
    }


    /*
        Logger.Log("Message"); // Logs to default path defined in library
        
        or

        string newPath = ....
        Logger.Log("Message", newPath); // Logs to custom path

     */

}
