using MediatR;
using Presentation.Domain.Entities;

namespace Presentation.Application.PersonalInfos.Queries
{
    // fiz somente duas queries de exemplo, esta e a GetPersons
    public class GetPersonalInfoByIdQuery : IRequest<PersonalInfo>
    {
        public int Id { get; set; }

        public GetPersonalInfoByIdQuery(int id)
        {
            Id = id;
        }
    }
}
