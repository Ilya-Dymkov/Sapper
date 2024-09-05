using Sapper.FieldCreatures;
using Sapper.FieldCreatures.Source;
using Sapper.Loggers;
using Sapper.Loggers.Source;
using Sapper.Models;

namespace Sapper.Proxies;

public class FieldCreatorProxy : IFieldCreator
{
    private readonly IFieldCreator _fieldCreator = new SimpleFieldCreator();
    private readonly IProxyLogger _logger = new ProxyLogger();
    
    public async Task<CellSymbol[][]> CreateField(uint width, uint height, uint mineCount)
    {
        try
        {
            _logger.Log(LogLevel.Information,
                $"Creating field with {width}x{height} and {mineCount} mines, created by {_fieldCreator.GetType().Name}");
            return await _fieldCreator.CreateField(width, height, mineCount);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            throw;
        }
    }
}