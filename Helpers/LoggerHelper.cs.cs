using System;
using System.IO;

namespace SmartCity.Helpers
{
    public static class LoggerHelper
    {
        private static readonly string logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Logs");

        public static void LogInfo(string message)
        {
            Log(message, "INFO");
        }

        public static void LogWarning(string message)
        {
            Log(message, "WARNING");
        }

        public static void LogError(string message)
        {
            Log(message, "ERROR");
        }

        private static void Log(string message, string level)
        {
            try
            {
                // Ensure log directory exists
                if (!Directory.Exists(logDirectory))
                    Directory.CreateDirectory(logDirectory);

                string logFileName = $"{DateTime.Now:yyyy-MM-dd}.log";
                string logFilePath = Path.Combine(logDirectory, logFileName);

                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} [{level}] - {message}");
                }
            }
            catch (Exception)
            {
                // Optional: ممكن تبعت notification لو logging فشل
            }
        }
    }
}
