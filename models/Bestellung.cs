using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleFlowerERP.Models;

public class Bestellung
{
    public int BestellungID { get; set; }
    public int LieferantID { get; set; }
    public DateTime Bestelldatum { get; set; } = DateTime.Now;
    public string Status { get; set; } = "Offen";

    // Navigation property to Kunde
    [ForeignKey("LieferantID")]
    public Lieferant Lieferant { get; set; } = new Lieferant();

    // Navigation property to Bestellpositionen
    public List<Bestellposition> Bestellpositionen { get; set; } = new List<Bestellposition>();
}