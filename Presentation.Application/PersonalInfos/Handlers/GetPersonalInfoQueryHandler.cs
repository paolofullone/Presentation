using MediatR;
using Presentation.Application.PersonalInfos.Queries;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;

namespace Presentation.Application.PersonalInfos.Handlers
{
    public class GetPersonalInfoQueryHandler : IRequestHandler<GetPersonalInfoQuery, IEnumerable<PersonalInfo>>
    {
        private readonly IPersonalInfoRepository _personalInfoRepository;

        public GetPersonalInfoQueryHandler(IPersonalInfoRepository personalInfoRepository)
        {
            _personalInfoRepository = personalInfoRepository;
        }

        public async Task<IEnumerable<PersonalInfo>> Handle(GetPersonalInfoQuery request, CancellationToken cancellationToken)
        {
            return await _personalInfoRepository.GetPersonalInfosAsync();
        }
    }
}
