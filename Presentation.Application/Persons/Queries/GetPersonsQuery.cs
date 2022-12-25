using MediatR;
using Presentation.Domain.Entities;

namespace Presentation.Application.Persons.Queries
{
    // fiz somente duas queries de exemplo, esta e a GetPersonById

    public class GetPersonsQuery : IRequest<IEnumerable<Person>>
    {
    }
}
