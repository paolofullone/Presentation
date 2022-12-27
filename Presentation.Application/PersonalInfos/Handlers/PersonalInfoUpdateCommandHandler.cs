using MediatR;
using Presentation.Application.PersonalInfos.Commands;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;

namespace Presentation.Application.PersonalInfos.Handlers
{
    public class PersonalInfoUpdateCommandHandler : IRequestHandler<PersonalInfoUpdateCommand, PersonalInfo>
    {
        private readonly IPersonalInfoRepository _personalInfoRepository;

        public PersonalInfoUpdateCommandHandler(IPersonalInfoRepository personalInfoRepository)
        {
            _personalInfoRepository = personalInfoRepository ?? throw new ArgumentNullException(nameof(personalInfoRepository));
        }
        public async Task<PersonalInfo> Handle(PersonalInfoUpdateCommand request, CancellationToken cancellationToken)
        {
            var personalInfo = await _personalInfoRepository.GetPersonalInfoByIdAsync(request.Id);
            if (personalInfo == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                personalInfo.Update(request.FullName, request.MaritalStatus, request.Children, request.BirthDate, request.City, request.State, request.Animals, request.FavoriteFood, request.FavoriteMusic, request.FavoriteMovie, request.FavoriteTVShow, request.FavoriteBook, request.FavoriteSport, request.LinkedinUrl, request.PersonId);
                return await _personalInfoRepository.UpdatePersonalInfoAsync(personalInfo);
            }
        }
    }
}

