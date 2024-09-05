using Microsoft.EntityFrameworkCore;
using Sapper.Models;

namespace Sapper.DataContext;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<GameInfoResponse> GameInfoResponses { get; set; }

    private static readonly char[] separatorDotComma = [';'];
    private static readonly char[] separatorComma = [','];

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<GameInfoResponse>()
            .HasKey(response => response.Game_id);

        modelBuilder.Entity<GameInfoResponse>()
            .Property(response => response.Field)
            .HasConversion(
                c => string.Join(";", c.Select(a => string.Join(",", a.Select(s => (char)s)))),
                s => s.Split(separatorDotComma).Select(a => a.Split(separatorComma).Select(c =>
                        (CellSymbol)c[0]).ToArray()).ToArray());
        
        modelBuilder.Entity<GameInfoResponse>()
            .Property(response => response.TrueField)
            .HasConversion(c => string.Join(";", c.Select(a => string.Join(",", a.Select(s => (char)s)))),
                s => s.Split(separatorDotComma).Select(a => a.Split(separatorComma).Select(c =>
                    (CellSymbol)c[0]).ToArray()).ToArray());
    }
}