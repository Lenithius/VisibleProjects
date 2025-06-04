using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationaltHaus1.Models;
using System;
namespace WebApplicationaltHaus1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private static List<Person> people = new List<Person>();

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            return Ok(people);
        }
        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (person == null)
            {
                return BadRequest("Person data is invalid");
            }
            people.Add(person);
            return CreatedAtAction(nameof(GetAllPeople), new { id = people.Count - 1 }, person);


        }

    }
}
