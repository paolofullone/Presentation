using Presentation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Domain.Interfaces
{
    public interface IPerson
    {
        Task<IEnumerable<Person>> GetPersonsAsync();
        Task<Person> GetPersonAsync(int id);
        Task<Person> AddPersonAsync(Person person);
        Task<Person> UpdatePersonAsync(Person person);
        Task<Person> RemovePersonAsync(int id);
    }
}
