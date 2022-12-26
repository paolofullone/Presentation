using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DTOs;
using Presentation.Application.Interfaces;

namespace Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Get All Persons
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetPersonsAsync()
        {
            var persons = await _personService.GetPersonsAsync();
            if (persons == null) return NotFound("No person found...");
            return Ok(persons);
        }

        /// <summary>
        /// Get a person by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetPerson")]
        public async Task<ActionResult<PersonDTO>> GetPersonByIdAsync(int? id)
        {
            if (id == null) return BadRequest("Invalid client request");
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null) return NotFound($"The person with id {id} couldn't be found");
            return Ok(person);
        }

        /// <summary>
        /// Create a new person. 
        /// </summary>
        /// <param name="personDTO"></param>
        /// <returns></returns>
        /// TODO: Create a PersonPostDTO without the ID.
        [HttpPost]
        public async Task<ActionResult> AddPersonAsync([FromBody] PersonDTO personDTO)
        {
            if (personDTO == null) return BadRequest("Invalid client request");
            await _personService.AddPersonAsync(personDTO);
            return new CreatedAtRouteResult("GetPerson", new { id = personDTO.Id }, personDTO);
        }

        /// <summary>
        /// Update a person
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdatePersonAsync(int id, [FromBody] PersonDTO personDTO)
        {
            if (id != personDTO.Id) return BadRequest("Invalid client request");

            if (personDTO == null) return BadRequest("Invalid client request");

            await _personService.UpdatePersonAsync(personDTO);
            return Ok(personDTO);

        }

        /// <summary>
        /// Deletes a person
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]    
        public async Task<ActionResult> DeletePersonAsync(int id)
        {
            var person = await _personService.GetPersonByIdAsync(id);
            if (person == null) return NotFound($"The person with id {id} couldn't be found");
            await _personService.DeletePersonAsync(id);
            return NoContent();
        }
    }
}