using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;

namespace Tutorial6.Controllers
{
    [ApiController]
    [Route("animals")]

    public class AnimalsController : ControllerBase
    {
        // GET /animals
        [HttpGet]
        public IActionResult Get()
        {
            var animals = Database.Animals;
            return Ok(animals);
        }

        // GET /animals/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var animal = Database.Animals.FirstOrDefault(x => x.Id == id);
            if (animal == null)
                return NotFound();
            return Ok(animal);
        }


        // POST /animals { "id": 4, "name": "Dog"... } --add new animal
        [HttpPost]
        public IActionResult Add(Animal animal)
        {
            Database.Animals.Add(animal);
            return Ok("new animal added");
        }


        // PUT /animals/{id} --edit animal
        [HttpPut("{id}")]
        public IActionResult Update(int id, Animal editedAnimal)
        {
            var existAnimal = Database.Animals.FirstOrDefault(x => x.Id == id);
            if (existAnimal == null)
                return NotFound();

            existAnimal.Name = editedAnimal.Name;
            existAnimal.Category = editedAnimal.Category;
            existAnimal.Weight = editedAnimal.Weight;
            existAnimal.FurColor = editedAnimal.FurColor;

            return Ok($"Animal {id} updated");

        }

        // DELETE /animals/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var animal = Database.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();

            Database.Animals.Remove(animal);
            return Ok($"Animal {id} deleted");
        }

        // GET /animals/search?name=Reksio
        [HttpGet("search")]
        public IActionResult SearchByName([FromQuery] string name)
        {
            var results = Database.Animals
                .Where(a => a.Name.Contains(name))
                .ToList();

            return Ok(results);
        }

    }
}