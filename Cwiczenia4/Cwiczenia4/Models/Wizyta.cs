namespace Cwiczenia4.Models;

public class Wizyta
{
    public Animal zwierzę { get; set; }
    public DateTime data_wizyty { get; set; }
    public string opis_wizyty { get; set; }
    public double cena_wizyty { get; set; }
}