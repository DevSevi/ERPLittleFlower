namespace LittleFlowerERP.Models;

public class Lagerort
{
    public int LagerortID { get; set; }
    public string Bezeichnung { get; set; } = string.Empty;
    public string Standort { get; set; } = string.Empty;

    // Navigation property to Lagerbestände
    public List<Lagerbestand> Lagerbestände { get; set; } = new List<Lagerbestand>();
}