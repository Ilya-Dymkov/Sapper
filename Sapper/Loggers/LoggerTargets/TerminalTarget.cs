using Sapper.Loggers.LoggerTargets.Source;

namespace Sapper.Loggers.LoggerTargets;

public class TerminalTarget : ILoggerTarget
{
    public void WriteLog(LogLevel level, string message) => 
        Console.WriteLine($"[{level}]: {message}");
}