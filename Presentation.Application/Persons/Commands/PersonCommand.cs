using MediatR;
using Presentation.Domain.Entities;

namespace Presentation.Application.Persons.Commands
{
    public abstract class PersonCommand : IRequest<Person>
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int? PersonalInfoId { get; set; }
    }
}
