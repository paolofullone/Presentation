using MediatR;
using Presentation.Application.PersonalInfos.Queries;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;

namespace Presentation.Application.PersonalInfos.Handlers
{
    public class GetPersonalInfoByIdQueryHandler : IRequestHandler<GetPersonalInfoByIdQuery, PersonalInfo>
    {
        private readonly IPersonalInfoRepository _personalInfoRepository;

        public GetPersonalInfoByIdQueryHandler(IPersonalInfoRepository personalInfoRepository)
        {
            _personalInfoRepository = personalInfoRepository;
        }

        async Task<PersonalInfo> IRequestHandler<GetPersonalInfoByIdQuery, PersonalInfo>.Handle(GetPersonalInfoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _personalInfoRepository.GetPersonalInfoByIdAsync(request.Id);
        }
    }
}
