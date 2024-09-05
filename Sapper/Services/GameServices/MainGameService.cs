using Sapper.FieldCreatures.Source;
using Sapper.Models;
using Sapper.Proxies;
using Sapper.Services.ModelsServices.Source;
using Sapper.Services.Source;

namespace Sapper.Services.GameServices;

public class MainGameService(IGameInfoService gameInfoService) : IMainGameService
{
    private readonly IFieldCreator _fieldCreator = new FieldCreatorProxy();
    
    public async Task<GameInfoResponse> CreateNewGame(NewGameRequest newRequest)
    {
        var gameInfo = new GameInfoResponse(newRequest.Width, newRequest.Height, newRequest.Mines_count,
            await _fieldCreator.CreateField(newRequest.Width, newRequest.Height, newRequest.Mines_count));

        await gameInfoService.AddGameInfo(gameInfo);
        return gameInfo;
    }
    
    private void ZeroOpenCells(GameInfoResponse gameInfo, uint row, uint col)
    {
        gameInfo.OpenCellField(row, col);

        if (gameInfo.Field[row][col] != CellSymbol.Zero) return;
        
        for (var i = row == 0 ? 0 : -1; i <= (row + 1 == gameInfo.Height ? 0 : 1); i++)
        for (var j = col == 0 ? 0 : -1; j <= (col + 1 == gameInfo.Width ? 0 : 1); j++)
            if (gameInfo.Field[row + i][col + j] == CellSymbol.Space) 
                ZeroOpenCells(gameInfo, (uint)(row + i), (uint)(col + j));
    }

    private void CompleteGame(GameInfoResponse gameInfo)
    {
        for (uint i = 0; i < gameInfo.Height; i++)
        for (uint j = 0; j < gameInfo.Width; j++)
            if (gameInfo.TrueField[i][j] == CellSymbol.Mine)
                gameInfo.Field[i][j] = CellSymbol.Boom;
            else gameInfo.OpenCellField(i, j);
        
        gameInfo.SetGameCompleted();
    }

    public async Task<GameInfoResponse> OpenCell(GameTurnRequest turnRequest)
    {
        var gameInfo = await gameInfoService.GetGameInfo(turnRequest.Game_id);
        
        if (gameInfo.Completed) throw new AggregateException("Game is already completed");

        if (gameInfo.Field[turnRequest.Row][turnRequest.Col] != CellSymbol.Space) 
            throw new ArgumentException("Cell is already opened");

        if (gameInfo.TrueField![turnRequest.Row][turnRequest.Col] == CellSymbol.Mine)
            CompleteGame(gameInfo);
        else ZeroOpenCells(gameInfo, turnRequest.Row, turnRequest.Col);

        if (gameInfo is { CountSafeCells: 0, Completed: false })
        {
            for (var i = 0; i < gameInfo.Height; i++)
            for (var j = 0; j < gameInfo.Width; j++)
                if (gameInfo.Field[i][j] == CellSymbol.Space)
                    gameInfo.Field[i][j] = CellSymbol.Mine;
            
            gameInfo.SetGameCompleted();
        }

        await gameInfoService.UpdateGameInfo(gameInfo);
        return gameInfo;
    }
}