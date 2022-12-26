using MediatR;
using Presentation.Domain.Entities;

namespace Presentation.Application.PersonalInfos.Queries
{
    // fiz somente duas queries de exemplo, esta e a GetPersonById

    public class GetPersonalInfoQuery : IRequest<IEnumerable<PersonalInfo>>
    {
    }
}
