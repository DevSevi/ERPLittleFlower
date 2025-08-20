using LittleFlowerERP.Models;
using Microsoft.EntityFrameworkCore;
using var db = new LittleFlowerContext();

var KundenMitRechnung = db.Kunden
    .Include(k => k.Rechnungen)
    .ThenInclude(r => r.Rechnungspositionen)
    .ToList();


foreach (var k in KundenMitRechnung)
{
    Console.WriteLine($"{k.Name} hat {k.Rechnungen.Count} Rechnungen");
}