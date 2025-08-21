using Microsoft.EntityFrameworkCore;
using LittleFlowerERP.Models; // damit deine Models gefunden werden

namespace ERPLittleFlowerBlazor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSets für deine Tabellen:
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Bestellposition> Bestellpositionen { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Lagerbestand> Lagerbestaende { get; set; }
        public DbSet<Lagerort> Lagerorte { get; set; }
        public DbSet<Lieferant> Lieferanten { get; set; }
        public DbSet<Rechnung> Rechnungen { get; set; }
        public DbSet<Rechnungsposition> Rechnungspositionen
        {
            get; set;
        }
    }
}