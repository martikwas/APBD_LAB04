using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tutorial6.Models;


namespace Tutorial6.Controllers
{
    [ApiController]
    [Route("animals/{animalId}/visits")]

    public class VisitsController : ControllerBase
    {
        //GET animals/{animalId}/visits
        [HttpGet]
        public IActionResult Get(int animalId)
        {
            var visit = Database.Visits.Where(v => v.AnimalId == animalId).ToList();
            return Ok(visit);
        }
        
        //POST animals/{animalId}/visits
        [HttpPost]
        public IActionResult Post(int animalId, Visit visit)
        {
            var existAnimal = Database.Animals.FirstOrDefault(x => x.Id == animalId);
            if (existAnimal == null)
                return NotFound();
            visit.AnimalId = animalId;
            Database.Visits.Add(visit);
            return Ok("New visit added");
        }
        
    }
}