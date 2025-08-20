using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleFlowerERP.Models;

public class Artikel
{
    public int ArtikelID { get; set; }
    public int LagerbestandID { get; set; }
    public string Bezeichnung { get; set; } = string.Empty;
    public string Beschreibung { get; set; } = string.Empty;
    public float Verkaufspreis { get; set; }
    public float Einkaufspreis { get; set; }
    public string Einheit { get; set; } = string.Empty;

    public List<Rechnungsposition> Rechnungspositionen { get; set; } = new List<Rechnungsposition>();
    public List<Lagerbestand> Lagerbestände { get; set; } = new List<Lagerbestand>();
}