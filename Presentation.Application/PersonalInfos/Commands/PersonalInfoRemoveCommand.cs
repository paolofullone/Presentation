using MediatR;
using Presentation.Domain.Entities;

namespace Presentation.Application.PersonalInfos.Commands
{
    public class PersonalInfoRemoveCommand : IRequest<PersonalInfo>
    {
        public int Id { get; set; }

        public PersonalInfoRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
