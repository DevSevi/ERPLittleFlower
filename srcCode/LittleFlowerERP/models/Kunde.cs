namespace LittleFlowerERP.Models;

public class Kunde
{
    public int KundeID { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Adresse { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}