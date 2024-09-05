using System.Text.Json.Serialization;
using Sapper.Models.Source;

namespace Sapper.Models;

[JsonConverter(typeof(JsonSymbolConverter))]
public enum CellSymbol
{
    Space = ' ',
    Zero = '0',
    One = '1',
    Two = '2',
    Three = '3',
    Four = '4',
    Five = '5',
    Six = '6',
    Seven = '7',
    Eight = '8',
    Mine = 'M',
    Boom = 'X'
}