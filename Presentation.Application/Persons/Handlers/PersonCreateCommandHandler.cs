using MediatR;
using Presentation.Application.Persons.Commands;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;

namespace Presentation.Application.Persons.Handlers
{
    public class PersonCreateCommandHandler : IRequestHandler<PersonCreateCommand, Person>
    {
        private readonly IPersonRepository _personRepository;

        public PersonCreateCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> Handle(PersonCreateCommand request, CancellationToken cancellationToken)
        {
            var person = new Person(request.FullName, request.Email, request.Password, request.City, request.State, request.LinkedinUrl, request.BirthDate);

            if (person == null)
            {
                throw new ApplicationException("Error creating entity.");
            }
            else
            {
                return await _personRepository.AddPersonAsync(person);
            }
        }
    }

}
