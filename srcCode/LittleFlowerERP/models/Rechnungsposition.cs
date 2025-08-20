using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleFlowerERP.Models;

public class Rechnungsposition
{
    public int RechnungspositionID { get; set; }
    public int RechnungID { get; set; }
    public int ArtikelID { get; set; }
    public int Menge { get; set; }
    public float Einzelpreis { get; set; }



    // Navigation property to Rechnung
    [ForeignKey("RechnungID")]
    public Rechnung Rechnung { get; set; } = new Rechnung();

    [ForeignKey("ArtikelID")]
    public Artikel Artikel { get; set; } = new Artikel();
}