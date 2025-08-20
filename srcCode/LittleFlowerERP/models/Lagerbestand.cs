namespace LittleFlowerERP.Models;

public class Lagerbestand
{
    public int LagerbestandID { get; set; }
    public int LagerortID { get; set; }
    public int ArtikelID { get; set; }
    public int Menge { get; set; }
    public DateTime LetzteInventur { get; set; } = DateTime.Now;

    // Navigation property to Artikel
    public Artikel Artikel { get; set; } = new Artikel();
}