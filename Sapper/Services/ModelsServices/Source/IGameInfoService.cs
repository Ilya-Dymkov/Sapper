using Sapper.Models;

namespace Sapper.Services.ModelsServices.Source;

public interface IGameInfoService
{
    Task<GameInfoResponse> GetGameInfo(Guid gameId);
    Task AddGameInfo(GameInfoResponse gameInfo);
    Task UpdateGameInfo(GameInfoResponse gameInfo);
}