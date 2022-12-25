using AutoMapper;
using MediatR;
using Presentation.Application.DTOs;
using Presentation.Application.Interfaces;
using Presentation.Application.Persons.Commands;
using Presentation.Application.Persons.Queries;

namespace Presentation.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public PersonService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<PersonDTO>> GetPersonsAsync()
        {
            var personsQuery = new GetPersonsQuery();

            if (personsQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var personsEntity = await _mediator.Send(personsQuery);

            return _mapper.Map<IEnumerable<PersonDTO>>(personsEntity);
        }

        public async Task<PersonDTO> GetPersonByIdAsync(int? id)
        {
            var personByIdQuery = new GetPersonByIdQuery(id!.Value);

            if (personByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var personEntity = await _mediator.Send(personByIdQuery);

            return _mapper.Map<PersonDTO>(personEntity);
        }

        public async Task AddPersonAsync(PersonDTO personDTO)
        {
            var personCreateCommand = _mapper.Map<PersonCreateCommand>(personDTO);
            await _mediator.Send(personCreateCommand);
        }
        public async Task UpdatePersonAsync(PersonDTO personDTO)
        {
            var personUpdateCommand = _mapper.Map<PersonUpdateCommand>(personDTO);
            await _mediator.Send(personUpdateCommand);
        }

        public async Task DeletePersonAsync(int? id)
        {
            var personRemoveCommand = new PersonRemoveCommand(id!.Value);
            if (personRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");
            await _mediator.Send(personRemoveCommand);
        }
    }
}