using System.Text.Json.Serialization;

namespace Sapper.Models;

public class GameInfoResponse(uint width, uint height, uint mines_count, CellSymbol[][] trueField)
{
    public Guid Game_id { get; init; } = Guid.NewGuid();
    public uint Width { get; init; } = width;
    public uint Height { get; init; } = height;
    public uint Mines_count { get; init; } = mines_count;
    public bool Completed { get; private set; }
    [JsonIgnore] public uint CountSafeCells { get; private set; } = width * height - mines_count;

    public CellSymbol[][] Field { get; init; } = new CellSymbol[height][]
        .Select(_ => new CellSymbol[width].Select(_ => CellSymbol.Space).ToArray()).ToArray();
    
    [JsonIgnore]
    public CellSymbol[][]? TrueField { get; private set; } = trueField is null ? null : width * height > mines_count ?
        trueField.Length != height ? throw new ArgumentException($"Columns count must be equal to height ({height})") :
        trueField.All(col => col.Length == width) ? trueField :
        throw new ArgumentException($"Column length must be equal to width ({width})") :
        throw new ArgumentException($"Mines count ({mines_count}) must be less than width ({width}) * height ({height})");
    
    public void OpenCellField(uint row, uint col)
    {
        if (Field[row][col] != CellSymbol.Space || TrueField[row][col] is CellSymbol.Mine or CellSymbol.Boom) return;
        
        Field[row][col] = TrueField![row][col];
        CountSafeCells--;
    }
    
    public void SetGameCompleted()
    {
        if (CountSafeCells != 0) throw new ArgumentException($"Safe cells count ({CountSafeCells}) must be zero");
        
        Completed = true;
        TrueField = null;
    }
}