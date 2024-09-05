namespace Sapper.Models;

public class ErrorResponse(string error)
{
    public string Error { get; set; } = error;
}