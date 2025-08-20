using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleFlowerERP.Models;

public class Bestellposition
{
    public int BestellpositionID { get; set; }
    public int BestellungID { get; set; }
    public int ArtikelID { get; set; }
    public int Menge { get; set; }
    public float Preis { get; set; }

    // Navigation property to Bestellung
    [ForeignKey("BestellungID")]
    public Bestellung Bestellung { get; set; } = new Bestellung();

    // Navigation property to Artikel
    [ForeignKey("ArtikelID")]
    public Artikel Artikel { get; set; } = new Artikel();
}