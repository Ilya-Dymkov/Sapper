using Sapper.Models;

namespace Sapper.Services.Source;

public interface IMainGameService
{
    Task<GameInfoResponse> CreateNewGame(NewGameRequest newRequest);
    Task<GameInfoResponse> OpenCell(GameTurnRequest turnRequest);
}