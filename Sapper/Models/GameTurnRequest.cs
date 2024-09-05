namespace Sapper.Models;

public class GameTurnRequest(Guid game_id, uint col, uint row)
{
    public Guid Game_id { get; set; } = game_id;
    public uint Col { get; set; } = col;
    public uint Row { get; set; } = row;
}