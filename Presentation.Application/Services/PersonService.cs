using AutoMapper;
using Presentation.Application.DTOs;
using Presentation.Application.Interfaces;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;

namespace Presentation.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepostiory, IMapper mapper)
        {
            _personRepository = personRepostiory ?? throw new ArgumentNullException(nameof(personRepostiory));
            _mapper = mapper;
        }

        public async Task<IEnumerable<PersonDTO>> GetPersonsAsync()
        {
            var personsEntity = await _personRepository.GetPersonsAsync();
            return _mapper.Map<IEnumerable<PersonDTO>>(personsEntity);
        }

        public async Task<PersonDTO> GetPersonByIdAsync(int? id)
        {
            var personEntity = await _personRepository.GetPersonByIdAsync(id);
            return _mapper.Map<PersonDTO>(personEntity);
        }

        public async Task AddPersonAsync(PersonDTO personDTO)
        {
            var personEntity = _mapper.Map<Person>(personDTO);
            await _personRepository.AddPersonAsync(personEntity);
        }
        public async Task UpdatePersonAsync(PersonDTO personDTO)
        {
            var personEntity = _mapper.Map<Person>(personDTO);
            await _personRepository.UpdatePersonAsync(personEntity);
        }

        public async Task RemovePersonAsync(int? id)
        {
            var personEntity = _personRepository.GetPersonByIdAsync(id).Result;
            await _personRepository.RemovePersonAsync(personEntity);

        }

    }
}