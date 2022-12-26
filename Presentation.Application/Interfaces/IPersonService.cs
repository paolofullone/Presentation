using Presentation.Application.DTOs;

namespace Presentation.Application.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTO>> GetPersonsAsync();
        Task<PersonDTO> GetPersonByIdAsync(int? id);
        Task AddPersonAsync(PersonDTO personDTO);
        Task UpdatePersonAsync(PersonDTO personDTO);
        Task DeletePersonAsync(int? id);
    }
}
