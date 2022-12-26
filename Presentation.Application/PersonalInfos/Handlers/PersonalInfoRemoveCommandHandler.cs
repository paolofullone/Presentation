using MediatR;
using Presentation.Application.PersonalInfos.Commands;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;

namespace Presentation.Application.PersonalInfos.Handlers
{
    public class PersonalInfoRemoveCommandHandler : IRequestHandler<PersonalInfoRemoveCommand, PersonalInfo>
    {
        private readonly IPersonalInfoRepository _personalInfoRepository;

        public PersonalInfoRemoveCommandHandler(IPersonalInfoRepository personalInfoRepository)
        {
            _personalInfoRepository = personalInfoRepository ?? throw new ArgumentNullException(nameof(personalInfoRepository));
        }

        public async Task<PersonalInfo> Handle(PersonalInfoRemoveCommand request, CancellationToken cancellationToken)
        {
            var person = await _personalInfoRepository.GetPersonalInfoByIdAsync(request.Id);
            if (person == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                return await _personalInfoRepository.RemovePersonalInfoAsync(person);
            }
        }
    }
}
