using Sapper.Models;

namespace Sapper.FieldCreatures.Source;

public interface IFieldCreator
{
    Task<CellSymbol[][]> CreateField(uint width, uint height, uint mineCount);
}