using MediatR;
using Presentation.Domain.Entities;
using Presentation.Domain.Enums;

namespace Presentation.Application.PersonalInfos.Commands
{
    public abstract class PersonalInfoCommand : IRequest<PersonalInfo>
    {
        public string FullName { get; private set; } = string.Empty;
        public MaritalStatus MaritalStatus { get; private set; }
        public Children Children { get; private set; }
        public DateTime BirthDate { get; private set; }
        public string City { get; private set; } = string.Empty;
        public string State { get; private set; } = string.Empty;
        public string Animals { get; private set; } = string.Empty;
        public string FavoriteFood { get; private set; } = string.Empty;
        public string FavoriteMusic { get; private set; } = string.Empty;
        public string FavoriteMovie { get; private set; } = string.Empty;
        public string FavoriteTVShow { get; private set; } = string.Empty;
        public string FavoriteBook { get; private set; } = string.Empty;
        public string FavoriteSport { get; private set; } = string.Empty;
        public string LinkedinUrl { get; private set; } = string.Empty;
        public int PersonId { get; set; }
    }
}
