using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LittleFlowerERP.Models;

public class Kunde
{
    public int KundeID { get; set; }
    [Required(ErrorMessage = "Der Name ist erforderlich.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Die Adresse ist erforderlich.")]
    public string Adresse { get; set; } = string.Empty;
    [Required(ErrorMessage = "Die Email ist erforderlich.")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Die Telefonnummer ist erforderlich.")]
    public string Telefonnummer { get; set; } = string.Empty;

    // Navigation property to Rechnungen
    public List<Rechnung> Rechnungen { get; set; } = new List<Rechnung>();


}