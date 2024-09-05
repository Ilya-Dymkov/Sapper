namespace Sapper.Loggers.LoggerTargets.Source;

public interface ILoggerTarget
{
    void WriteLog(LogLevel level, string message);
}