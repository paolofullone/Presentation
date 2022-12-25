using MediatR;
using Presentation.Application.Persons.Queries;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;

namespace Presentation.Application.Persons.Handlers
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, Person>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonByIdQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Person> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetPersonByIdAsync(request.Id);
        }
    }
}
