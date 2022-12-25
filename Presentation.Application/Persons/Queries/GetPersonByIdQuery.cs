using MediatR;
using Presentation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Application.Persons.Queries
{
    // fiz somente duas queries de exemplo, esta e a GetPersons
    public class GetPersonByIdQuery : IRequest<Person>
    {
        public int Id { get; set; }

        public GetPersonByIdQuery(int id)
        {
            Id = id;
        }
    }
}
