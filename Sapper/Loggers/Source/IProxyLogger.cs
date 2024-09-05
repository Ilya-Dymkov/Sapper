namespace Sapper.Loggers.Source;

public interface IProxyLogger
{
    void Log(LogLevel level, string message);
}