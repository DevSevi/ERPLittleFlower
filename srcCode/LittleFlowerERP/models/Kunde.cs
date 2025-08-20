using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleFlowerERP.Models;

public class Kunde
{
    public int KundeID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Telefonnummer { get; set; } = string.Empty;

    // Navigation property to Rechnungen
    public List<Rechnung> Rechnungen { get; set; } = new List<Rechnung>();
}