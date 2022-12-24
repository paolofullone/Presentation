using Microsoft.EntityFrameworkCore;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;
using Presentation.Infra.Data.Context;

namespace Presentation.Infra.Data.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _personContext;

        public PersonRepository(ApplicationDbContext context)
        {
            _personContext = context;
        }

        public async Task<IEnumerable<Person>> GetPersonsAsync()
        {
            return await _personContext.Persons!.ToListAsync();
        }

        public async Task<Person> AddPersonAsync(Person person)
        {
            _personContext.Add(person);
            await _personContext.SaveChangesAsync();
            return person;
        }

        public async Task<Person> GetPersonByIdAsync(int? id)
        {
            var person = await _personContext.Persons!.FirstOrDefaultAsync(m => m.Id == id);
            return person!;
        }


        public async Task<Person> RemovePersonAsync(Person person)
        {
            _personContext.Persons!.Remove(person);
            await _personContext.SaveChangesAsync();
            return person;
        }

        public async Task<Person> UpdatePersonAsync(Person person)
        {
            _personContext.Update(person);
            await _personContext.SaveChangesAsync();
            return person;
        }

    }

}
