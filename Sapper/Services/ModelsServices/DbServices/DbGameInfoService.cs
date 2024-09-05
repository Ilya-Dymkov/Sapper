using Microsoft.EntityFrameworkCore;
using Sapper.DataContext;
using Sapper.Models;
using Sapper.Services.ModelsServices.Source;

namespace Sapper.Services.ModelsServices.DbServices;

public class DbGameInfoService(ApplicationDbContext dbContext) : IGameInfoService
{
    public Task<GameInfoResponse> GetGameInfo(Guid gameId) => 
        dbContext.GameInfoResponses.SingleAsync(g => g.Game_id == gameId);

    public async Task AddGameInfo(GameInfoResponse gameInfo)
    {
        await dbContext.GameInfoResponses.AddAsync(gameInfo);
        await dbContext.SaveChangesAsync();
    }

    public async Task UpdateGameInfo(GameInfoResponse gameInfo)
    {
        dbContext.Update(gameInfo);
        await dbContext.SaveChangesAsync();
    }
}