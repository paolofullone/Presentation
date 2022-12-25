using MediatR;
using Presentation.Domain.Entities;

namespace Presentation.Application.Persons.Commands
{
    public abstract class PersonCommand : IRequest<Person>
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string LinkedinUrl { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
    }
}
