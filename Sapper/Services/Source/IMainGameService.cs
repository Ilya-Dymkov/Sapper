using Sapper.Models;

namespace Sapper.Services.Source;

public interface IMainGameService
{
    Task<GameInfoResponse> GetGameInfo(Guid gameId);
    Task<GameInfoResponse> CreateNewGame(NewGameRequest newRequest);
    Task<GameInfoResponse> OpenCell(GameTurnRequest turnRequest);
}