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

        public void Log(string text, LogType type=LogType.INFO)
        {
            if (Level >= type)
            {
                string prefix = DateTime.Now + ": " + LogTypeToString(type) + ": ";
                File.AppendAllText(LogFile, prefix + text);
            }
        }

        public void LogInfo(string text) { Log(text, LogType.INFO); }
        public void LogDebug(string text) { Log(text, LogType.DEBUG); }
        public void LogWarning(string text) { Log(text, LogType.WARNING); }
        public void LogError(string text) { Log(text, LogType.ERROR); }

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
