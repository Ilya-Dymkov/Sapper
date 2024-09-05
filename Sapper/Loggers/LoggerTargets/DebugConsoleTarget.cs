using System.Diagnostics;
using Sapper.Loggers.LoggerTargets.Source;

namespace Sapper.Loggers.LoggerTargets;

public class DebugConsoleTarget : ILoggerTarget
{
    public void WriteLog(LogLevel level, string message) => 
        Debug.WriteLine($"[{level}]: {message}");
}