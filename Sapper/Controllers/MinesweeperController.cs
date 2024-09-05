using Microsoft.AspNetCore.Mvc;
using Sapper.DataContext;
using Sapper.Models;
using Sapper.Proxies;
using Sapper.Services.ModelsServices.DbServices;
using Sapper.Services.Source;

namespace Sapper.Controllers
{
    [Route("")]
    [ApiController]
    public class MinesweeperController(ApplicationDbContext dbContext) : ControllerBase
    {
        private readonly IMainGameService _mainGameService = new MainGameServiceProxy(new DbGameInfoService(dbContext));
        
        [HttpPost("new")]
        public async Task<ActionResult<GameInfoResponse>> NewGame(NewGameRequest newRequest)
        {
            try
            {
                return Ok(await _mainGameService.CreateNewGame(newRequest));
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResponse(e.Message));
            }
        }

        [HttpPost("turn")]
        public async Task<ActionResult<GameInfoResponse>> OpenCell(GameTurnRequest turnRequest)
        {
            try
            {
                return Ok(await _mainGameService.OpenCell(turnRequest));
            }
            catch (Exception e)
            {
                return BadRequest(new ErrorResponse(e.Message));
            }
        }
    }
}
