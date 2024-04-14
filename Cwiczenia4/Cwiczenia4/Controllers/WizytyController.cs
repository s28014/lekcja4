using Cwiczenia4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia4.Controllers;

[Route("api/wizyty")]
[ApiController]
public class WizytyController : ControllerBase
{
    private static readonly List<Wizyta> _wizyty = new ()
    {
        new Wizyta {zwierzę = AnimalsController._animals[0], data_wizyty = new DateTime(2024, 04, 14, 12, 30, 00), opis_wizyty = "Wizyta obejmowala szczepionke na wścieklizne", cena_wizyty = 200},
        new Wizyta {zwierzę = AnimalsController._animals[0], data_wizyty = new DateTime(2021, 02, 15, 12, 30, 00), opis_wizyty = "Wizyta obejmowala operacje łapy prawej tylnej", cena_wizyty = 4000},
        new Wizyta {zwierzę = AnimalsController._animals[2], data_wizyty = new DateTime(2023, 12, 01, 8, 45, 00), opis_wizyty = "Wizyta obejmowala badanie temperatury", cena_wizyty = 100}
    };

    [HttpGet("{id:int}")]
    public IActionResult getWizyta(int id)
    {
        List<Wizyta> list = new List<Wizyta>();

        foreach (var wizyta in _wizyty)
        {
            if (wizyta.zwierzę.id == id)
            {
                list.Add(wizyta);
            }
        }

        if (list.Count == 0)
        {
            return NotFound($"Nie ma żadnej wizyty dla tego zwierzęcia");
        }

        return Ok(list);
    }

    [HttpPost]
    public IActionResult addWizyta(Wizyta wizyta)
    {
        _wizyty.Add(wizyta);
        return StatusCode(StatusCodes.Status201Created);
    }
}