using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleFlowerERP.Models;

public class Lagerbestand
{
    public int LagerbestandID { get; set; }
    public int LagerortID { get; set; }
    public int ArtikelID { get; set; }
    public int Menge { get; set; }
    public DateTime LetzteInventur { get; set; } = DateTime.Now;

    [ForeignKey("LagerortID")]
    public Lagerort Lagerort { get; set; } = new Lagerort();
    public Artikel Artikel { get; set; } = new Artikel();
}