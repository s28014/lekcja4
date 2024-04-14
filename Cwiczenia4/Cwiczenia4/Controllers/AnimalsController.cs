using Cwiczenia4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cwiczenia4.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    public static readonly List<Animal> _animals = new()
    {
        new Animal {id = 1, imie = "Albert", kategoria = "pies", masa = 10.5, kolor_sierści = "biały"},
        new Animal {id = 2, imie = "Belzebub", kategoria = "kot", masa = 6, kolor_sierści = "czarny"},
        new Animal {id = 3, imie = "Cerber", kategoria = "pies", masa = 20, kolor_sierści = "czarno-biały"}
    };

    [HttpGet]
    public IActionResult GetAnimals()
    {
        return Ok(_animals);
    }

    [HttpGet("{id:int}")]
    public IActionResult getAnimal(int id)
    {
        var animal = _animals.FirstOrDefault(a => a.id == id);
        if (animal == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        return Ok(animal);
    }

    [HttpPost]
    public IActionResult addAnimal(Animal animal)
    {
        _animals.Add(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult updateAnimal(int id, Animal animal)
    {
        var animalToEdit = _animals.FirstOrDefault(a => a.id == id);

        if (animalToEdit == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToEdit);
        _animals.Add(animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult deleteAnimal(int id)
    {
        var animalToDelete = _animals.FirstOrDefault(a => a.id == id);

        if (animalToDelete == null)
        {
            return NotFound($"Animal with id {id} was not found");
        }

        _animals.Remove(animalToDelete);
        return NoContent();
    }
}