using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleFlowerERP.Models;

public class Rechnung
{
    public int RechnungID { get; set; }
    public int KundeID { get; set; }
    public DateTime Rechnungsdatum { get; set; }
    public bool Bezahlt { get; set; }
    public decimal Gesamtpreis { get; set; }
    public int Mahnstufe { get; set; } = 0;

    // Navigation property to Kunde
    [ForeignKey("KundeID")]
    public Kunde Kunde { get; set; } = null!;

    public List<Rechnungsposition> Rechnungspositionen { get; set; } = new List<Rechnungsposition>();
}