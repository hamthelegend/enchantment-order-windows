using Microsoft.EntityFrameworkCore;

namespace Database;

internal class CombinationOrderContext : DbContext
{
    internal DbSet<CombinationOrderEntity> CombinationOrderEntities { get; set; }

    private string DbPath { get; }
    
    public CombinationOrderContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "combination_orders.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data Source={DbPath}");
    
}