using Microsoft.EntityFrameworkCore;
using LittleFlowerERP.Models;

public class LittleFlowerContext : DbContext
{
    public DbSet<Kunde> Kunden { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlServer("Server=localhost,1433;Database=LittleFlowerERP;User Id=sa;Password=hujhEv-bynnav-9capza;TrustServerCertificate=True;");
    }
}