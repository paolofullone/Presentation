using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Application.DTOs;
using Presentation.Application.Interfaces;

namespace Presentation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalInfoController : ControllerBase
    {
        private readonly IPersonalInfoService _personalInfoService;

        public PersonalInfoController(IPersonalInfoService personalInfoService)
        {
            _personalInfoService = personalInfoService;
        }

        /// <summary>
        /// Get All PersonalInfo
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalInfoDTO>>> GetPersonalInfoAsync()
        {
            var personalInfo = await _personalInfoService.GetPersonalInfoAsync();
            if (personalInfo is null) return NotFound("No personalInfo found...");
            return Ok(personalInfo);
        }

        /// <summary>
        /// Get a personalInfo by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}", Name = "GetPersonalInfo")]
        public async Task<ActionResult<PersonalInfoDTO>> GetPersonalInfoByIdAsync(int? id)
        {
            if (id is null) return BadRequest("Invalid client request");
            var personalInfo = await _personalInfoService.GetPersonalInfoByIdAsync(id);
            if (personalInfo is null) return NotFound($"The personalInfo with id {id} couldn't be found");
            return Ok(personalInfo);
        }

        /// <summary>
        /// Create a new personalInfo. 
        /// </summary>
        /// <param name="personalInfoDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> AddPersonalInfoAsync([FromBody] PersonalInfoDTO personalInfoDTO)
        {
            if (personalInfoDTO is null) return BadRequest("Invalid client request");
            await _personalInfoService.AddPersonalInfoAsync(personalInfoDTO);
            return new CreatedAtRouteResult("GetPersonalInfo", new { id = personalInfoDTO.Id }, personalInfoDTO);
        }

        /// <summary>
        /// Updateas a personal Info
        /// </summary>
        /// <param name="id"></param>
        /// <param name="personalInfoDTO"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdatePersonalInfoAsync(int id, [FromBody] PersonalInfoDTO personalInfoDTO)
        {
            if (id != personalInfoDTO.Id) return BadRequest("Invalid client request");
            if (personalInfoDTO is null) return BadRequest("Invalid client request");
            await _personalInfoService.UpdatePersonalInfoAsync(personalInfoDTO);
            return new CreatedAtRouteResult("GetPersonalInfo", new { id = personalInfoDTO.Id }, personalInfoDTO);
        }

        /// <summary>
        /// Deletes a PersonalInfo
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePersonalInfo(int id)
        {
            var personalInfo = await _personalInfoService.GetPersonalInfoByIdAsync(id);
            if (personalInfo is null) return NotFound($"The personal info with id {id} couldn't be found.");
            await _personalInfoService.DeletePersonalInfoAsync(id);
            return NoContent();
        }
    }
}
