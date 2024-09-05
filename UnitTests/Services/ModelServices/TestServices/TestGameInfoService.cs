using Sapper.Models;
using Sapper.Services.ModelsServices.Source;

namespace UnitTests.Services.ModelServices.TestServices;

public class TestGameInfoService : IGameInfoService
{
    private readonly List<GameInfoResponse> GameInfos = [];
    
    public Task<GameInfoResponse> GetGameInfo(Guid gameId) => 
        Task.FromResult(GameInfos.Single(g => g.Game_id == gameId));

    public Task AddGameInfo(GameInfoResponse gameInfo)
    {
        GameInfos.Add(gameInfo);
        return Task.CompletedTask;
    }

    public Task UpdateGameInfo(GameInfoResponse gameInfo)
    {
        GameInfos.Remove(GameInfos.Single(g => g.Game_id == gameInfo.Game_id));
        GameInfos.Add(gameInfo);
        return Task.CompletedTask;
    }
}