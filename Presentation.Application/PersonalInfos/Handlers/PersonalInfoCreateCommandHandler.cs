using MediatR;
using Presentation.Application.PersonalInfos.Commands;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;

namespace Presentation.Application.PersonalInfos.Handlers
{
    public class PersonalInfoCreateCommandHandler : IRequestHandler<PersonalInfoCreateCommand, PersonalInfo>
    {
        private readonly IPersonalInfoRepository _personalInfoRepository;

        public PersonalInfoCreateCommandHandler(IPersonalInfoRepository personalInfoRepository)
        {
            _personalInfoRepository = personalInfoRepository;
        }

        public async Task<PersonalInfo> Handle(PersonalInfoCreateCommand request, CancellationToken cancellationToken)
        {
            var personalInfo = new PersonalInfo(request.FullName, request.City, request.State, request.BirthDate, request.MaritalStatus, request.Animals, request.FavoriteFood, request.FavoriteMusic, request.FavoriteMovie, request.FavoriteTVShow, request.FavoriteBook, request.FavoriteSport, request.LinkedinUrl, request.PersonId);

            if (personalInfo == null)
            {
                throw new ApplicationException("Error creating entity.");
            }
            else
            {
                return await _personalInfoRepository.AddPersonalInfoAsync(personalInfo);
            }
        }
    }
}
