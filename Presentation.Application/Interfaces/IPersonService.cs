using Presentation.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Application.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonDTO>> GetPersonsAsync();
        Task<PersonDTO> GetPersonByIdAsync(int? id);
        Task AddPersonAsync(PersonDTO personDTO);
        Task UpdatePersonAsync(PersonDTO personDTO);
        Task RemovePersonAsync(int? id);
    }
}
