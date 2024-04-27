using Microsoft.AspNetCore.Mvc;
using WebApplication.DTO;
using WebApplication.Services;

namespace WebApplication.Controllers
{
    public class AnimallController
    {

        [HttpGet("{id:int}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = AnimalService.GetAnimalById(id);

            if (animal == null)
            {
                return NotFound("Animal not found");
            }

            return Ok(animal);
        }

        [HttpPost]
        public ActionResult<int> CreateAnimal(AnimalCreationDTO animal)
        {
            var id = AnimalService.CreateAnimal(animal);
            return CreatedAtAction(nameof(CreateAnimal), id);
        }

        [HttpDelete]
        public ActionResult DeleteAnimal(int id)
        {
            var animal = AnimalService.GetAnimal(id);

            if (animal == null)
            {
                return NotFound("Animal not found");
            }

            _ = AnimalService.DeleteAnimal(id);

            return NoContent();
        }
    }
}
