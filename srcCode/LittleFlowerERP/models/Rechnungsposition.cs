namespace LittleFlowerERP.Models;

public class Rechnungsposition
{
    public int RechnungspositionID { get; set; }
    public int RechnungID { get; set; }
    public int ArtikelID { get; set; }
    public int Menge { get; set; }
    public float Einzelpreis { get; set; }
    public float Gesamtpreis => Menge * Einzelpreis;



    // Navigation property to Rechnung
    public Rechnung Rechnung { get; set; } = new Rechnung();
}