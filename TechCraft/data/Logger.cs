using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechCraft.data
{
    public enum LogType
    {
        ERROR = 0, WARNING, DEBUG, INFO
    }

    public class Logger
    {
        public static string LogFile = "game.log";
        public static LogType Level = LogType.INFO;
        public static bool ConsoleOutput = true;
        protected static Logger Instance = null;

        public static Logger GetLogger()
        {
            if (Instance == null) Instance = new Logger();
            return Instance;
        }

        public void Log(string text, LogType type=LogType.INFO)
        {
            if (Level >= type)
            {
                string prefix = DateTime.Now + ": " + LogTypeToString(type) + ": ";
                File.AppendAllText(LogFile, prefix + text + "\n");
                if (ConsoleOutput) Console.WriteLine(prefix + text);
            }
        }

        public static void LogInfo(string text) { GetLogger().Log(text, LogType.INFO); }
        public static void LogDebug(string text) { GetLogger().Log(text, LogType.DEBUG); }
        public static void LogWarning(string text) { GetLogger().Log(text, LogType.WARNING); }
        public static void LogError(string text) { GetLogger().Log(text, LogType.ERROR); }

        private static string LogTypeToString(LogType type)
        {
            switch (type)
            {
                case LogType.INFO: return "INFO";
                case LogType.DEBUG: return "DEBUG";
                case LogType.WARNING: return "WARNING";
                case LogType.ERROR: return "ERROR";
                default: return "UNKNOWN";
            }
        }
    }
}
