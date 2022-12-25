using MediatR;
using Presentation.Domain.Entities;

namespace Presentation.Application.Persons.Commands
{
    public class PersonRemoveCommand : IRequest<Person>
    {
        public int Id { get; set; }

        public PersonRemoveCommand(int id)
        {
            Id = id;
        }
    }
}
