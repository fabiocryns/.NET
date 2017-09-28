using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment
{
    public static class Logger
    {
        public static void LogToConsole(string message)
        {
            // write the message to the console
            Console.WriteLine(message);
        }
        public static void LogToFile(string message)
        {
            // write the message to a file 'log.txt' located on the desktop
            string filename =
           Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt");
           File.AppendAllText(filename, message + Environment.NewLine);
        }
    }
}
