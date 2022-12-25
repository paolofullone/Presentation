using MediatR;
using Presentation.Application.Persons.Commands;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;

namespace Presentation.Application.Persons.Handlers
{
    public class PersonRemoveCommandHandler : IRequestHandler<PersonRemoveCommand, Person>
    {
        private readonly IPersonRepository _personRepository;

        public PersonRemoveCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository ?? throw new ArgumentNullException(nameof(personRepository));
        }

        public async Task<Person> Handle(PersonRemoveCommand request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetPersonByIdAsync(request.Id);
            if (person == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                return await _personRepository.RemovePersonAsync(person);
            }
        }
    }
}
