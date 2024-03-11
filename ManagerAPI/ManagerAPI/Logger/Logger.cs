using System;
using System.IO;

namespace ManagerAPI.Logger
{
    public class Logger : Interfaces.ILogger
    {
        private readonly string logFilePath;

        public Logger(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public void Info(string message)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    writer.WriteLine($"{DateTime.Now}: INFO - {message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el archivo de registro: {ex.Message}");
            }
        }
    }
}

