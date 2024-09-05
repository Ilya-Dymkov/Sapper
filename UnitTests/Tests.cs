using Sapper.Models;
using Sapper.Services.GameServices;
using Sapper.Services.Source;
using UnitTests.Services.ModelServices.TestServices;

namespace UnitTests;

public class Tests
{
    private IMainGameService _gameService;
    
    [SetUp]
    public void Setup()
    {
        _gameService = new MainGameService(new TestGameInfoService());
    }

    [TestCase(0u, 0u, 0u)]
    [TestCase(3u, 4u, 5u)]
    [TestCase(100u, 100u, 2000u)]
    public async Task TestForAddNewGame(uint width, uint height, uint mines)
    {
        if (width * height <= mines)
            Assert.ThrowsAsync<ArgumentException>(async () => await _gameService.CreateNewGame(new(width, height, mines)));
        else
        {
            var game = await _gameService.CreateNewGame(new(width, height, mines));
            Assert.Multiple(async () =>
            {
                Assert.That((await _gameService.GetGameInfo(game.Game_id)).Field, Has.Length.EqualTo(game.Height));
                Assert.That((await _gameService.GetGameInfo(game.Game_id)).TrueField!.All(a => a.Length == game.Width), Is.True);
            });
        }
    }

    [Test]
    public async Task TestForMultipleNewGame()
    {
        for (uint i = 0; i < 20; i++)
        for (uint j = 0; j < 20; j++) 
        for (uint k = 0; k < i * j / 2; k++)
            await TestForAddNewGame(i, j, k);
    }

    [Test]
    public async Task TestForOpenCell()
    {
        for (var i = 0; i < 10; i++)
        {
            var game = await _gameService.CreateNewGame(new(2, 2, 3));
            var isGoodEnd = game.TrueField[0][0] == CellSymbol.Mine ? false : true;
            await _gameService.OpenCell(new(game.Game_id, 0, 0));
            
            Assert.Multiple(async () =>
            {
                Assert.That((await _gameService.GetGameInfo(game.Game_id)).CountSafeCells, Is.EqualTo(0));
                Assert.That((await _gameService.GetGameInfo(game.Game_id)).Completed, Is.True);
                Assert.That((await _gameService.GetGameInfo(game.Game_id)).TrueField, Is.EqualTo(null));
            });
            
            if (isGoodEnd) Assert.That((await _gameService.GetGameInfo(game.Game_id)).Field[0][1], Is.EqualTo(CellSymbol.Mine));
            else Assert.That((await _gameService.GetGameInfo(game.Game_id)).Field[0][0], Is.EqualTo(CellSymbol.Boom));
        }
    }
}