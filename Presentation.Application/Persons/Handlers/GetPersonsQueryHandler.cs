using MediatR;
using Presentation.Application.Persons.Queries;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;

namespace Presentation.Application.Persons.Handlers
{
    public class GetPersonsQueryHandler : IRequestHandler<GetPersonsQuery, IEnumerable<Person>>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonsQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<IEnumerable<Person>> Handle(GetPersonsQuery request, CancellationToken cancellationToken)
        {
            return await _personRepository.GetPersonsAsync();
        }
    }
}
