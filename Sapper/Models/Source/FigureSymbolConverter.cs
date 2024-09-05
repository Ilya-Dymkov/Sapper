namespace Sapper.Models.Source;

public class FigureSymbolConverter
{
    public static uint ToFigure(CellSymbol symbol) => symbol is >= CellSymbol.Zero and <= CellSymbol.Eight ? 
        uint.Parse(((char)symbol).ToString()) : 
        throw new ArgumentException("Symbol must be between 0 and 8");
    
    public static CellSymbol ToSymbol(uint figure) => figure <= 8 ? 
        (CellSymbol)char.Parse(figure.ToString()) :
        throw new ArgumentException("Figure must be between 0 and 8");
}