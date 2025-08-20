namespace LittleFlowerERP.Models;

public class Lieferant
{
    public int LieferantID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string Telefonnummer { get; set; } = string.Empty;
}