using Sapper.Loggers.LoggerTargets;
using Sapper.Loggers.LoggerTargets.Source;
using Sapper.Loggers.Source;

namespace Sapper.Loggers;

public class ProxyLogger : IProxyLogger
{
    private static readonly ILoggerTarget[] LoggerTargets = [new TerminalTarget(), new DebugConsoleTarget()];
    
    public void Log(LogLevel level, string message)
    {
        foreach (var loggerTarget in LoggerTargets) loggerTarget.WriteLog(level, message);
    }
}