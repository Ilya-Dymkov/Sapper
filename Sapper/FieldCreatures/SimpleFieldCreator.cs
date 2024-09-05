using Sapper.FieldCreatures.Source;
using Sapper.Models;
using Sapper.Models.Source;

namespace Sapper.FieldCreatures;

public class SimpleFieldCreator : IFieldCreator
{
    private static readonly Random Random = new();
    
    public Task<CellSymbol[][]> CreateField(uint width, uint height, uint mineCount) =>
        Task.Run(() =>
        {
            // Initialize the array with zeros
            var array = new CellSymbol[height][];
            for (var i = 0; i < height; i++) array[i] = new CellSymbol[width];

            // Randomly place the mines
            for (var i = 0; i < mineCount; i++)
            {
                int x, y;
                do
                {
                    x = Random.Next((int)width);
                    y = Random.Next((int)height);
                } while (array[y][x] == CellSymbol.Mine);

                array[y][x] = CellSymbol.Mine;
            }

            // Fill in the numbers
            for (var i = 0; i < height; i++)
            for (var j = 0; j < width; j++)
            {
                if (array[i][j] == CellSymbol.Mine) continue;
                uint count = 0;
                    
                for (var x = -1; x <= 1; x++)
                for (var y = -1; y <= 1; y++)
                {
                    var nx = j + x;
                    var ny = i + y;
                            
                    if (nx >= 0 && nx < width && ny >= 0 && ny < height && array[ny][nx] == CellSymbol.Mine)
                        count++;
                }
                    
                array[i][j] = FigureSymbolConverter.ToSymbol(count);
            }

            return array;
        });
}