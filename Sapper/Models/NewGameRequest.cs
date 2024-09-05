namespace Sapper.Models;

public class NewGameRequest(uint width, uint height, uint mines_count)
{
    public uint Width { get; set; } = width;
    public uint Height { get; set; } = height;
    public uint Mines_count { get; set; } = mines_count;
}