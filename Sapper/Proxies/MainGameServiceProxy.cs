using Sapper.Loggers;
using Sapper.Loggers.Source;
using Sapper.Models;
using Sapper.Services.GameServices;
using Sapper.Services.ModelsServices.Source;
using Sapper.Services.Source;

namespace Sapper.Proxies;

public class MainGameServiceProxy(IGameInfoService gameInfoService) : IMainGameService
{
    private readonly IMainGameService _mainGameService = new MainGameService(gameInfoService);
    private readonly IProxyLogger _logger = new ProxyLogger();

    public Task<GameInfoResponse> GetGameInfo(Guid gameId)
    {
        try
        {
            _logger.Log(LogLevel.Information, $"Getting game info with id: {gameId}");
            return _mainGameService.GetGameInfo(gameId);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            throw;
        }
    }

    public async Task<GameInfoResponse> CreateNewGame(NewGameRequest newRequest)
    {
        try
        {
            _logger.Log(LogLevel.Information,
                $"Creating new game with {newRequest.Width}x{newRequest.Height} and {newRequest.Mines_count} mines ");
            return await _mainGameService.CreateNewGame(newRequest);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            throw;
        }
    }

    public async Task<GameInfoResponse> OpenCell(GameTurnRequest turnRequest)
    {
        try
        {
            _logger.Log(LogLevel.Information, $"Opening cell with coordinates: {turnRequest.Row}x{turnRequest.Col}");
            return await _mainGameService.OpenCell(turnRequest);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, e.Message);
            throw;
        }
    }
}