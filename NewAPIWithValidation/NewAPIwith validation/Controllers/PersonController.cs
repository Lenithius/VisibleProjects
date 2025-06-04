using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewAPIWithValidation.Models;

namespace NewAPIWithValidation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        public static readonly List<Person> People = new()
        {
            new Person {Id = 1, FirstName = "John", LastName = "Doe", Dob = "01/01/2000"  },
            new Person {Id = 2, FirstName = "Jane", LastName = "Smith", Dob = "01/01/2000"  },
        };
        [HttpGet("{id}")]
        public IActionResult GetPerson(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid Id");
            }
            var person = People.FirstOrDefault(p => p.Id == id);

            return Ok(person);

        }
        [HttpPost]
        public IActionResult AddPerson([FromBody] Person newPerson)
        {
            if (newPerson == null || string.IsNullOrEmpty(newPerson.FirstName)
                || string.IsNullOrEmpty(newPerson.LastName))
            {
                return BadRequest("Invalid person data");
            }
            if (People.Any(p => p.Id == newPerson.Id))
            {
                return Conflict("Person with the given ID already exists");
            }
            People.Add(newPerson);
            return CreatedAtAction(nameof(GetPerson), new { id = newPerson.Id }, newPerson);

        }
        [HttpDelete("{Id}")]
        public IActionResult DeletePerson(int id)
        {
            var person = People.FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound();
            }
            People.Remove(person);
            return NoContent();
        }
    }
}
