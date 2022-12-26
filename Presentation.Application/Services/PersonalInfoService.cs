using AutoMapper;
using MediatR;
using Presentation.Application.DTOs;
using Presentation.Application.Interfaces;
using Presentation.Application.PersonalInfos.Commands;
using Presentation.Application.PersonalInfos.Queries;

namespace Presentation.Application.Services
{
    public class PersonalInfoService : IPersonalInfoService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public PersonalInfoService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<PersonalInfoDTO>> GetPersonalInfoAsync()
        {
            var personalInfoQuery = new GetPersonalInfoQuery();

            if (personalInfoQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var personalInfoEntity = await _mediator.Send(personalInfoQuery);

            return _mapper.Map<IEnumerable<PersonalInfoDTO>>(personalInfoEntity);
        }

        public async Task<PersonalInfoDTO> GetPersonalInfoByIdAsync(int? id)
        {
            var personalInfoByIdQuery = new GetPersonalInfoByIdQuery(id!.Value);

            if (personalInfoByIdQuery == null)
                throw new Exception($"Entity could not be loaded.");

            var personalInfoEntity = await _mediator.Send(personalInfoByIdQuery);

            return _mapper.Map<PersonalInfoDTO>(personalInfoEntity);
        }

        public async Task AddPersonalInfoAsync(PersonalInfoDTO personsalInfoDTO)
        {
            var personalInfoCreateCommand = _mapper.Map<PersonalInfoCreateCommand>(personsalInfoDTO);
            await _mediator.Send(personalInfoCreateCommand);
        }
        public async Task UpdatePersonalInfoAsync(PersonalInfoDTO personsalInfoDTO)
        {
            var personalInfoUpdateCommand = _mapper.Map<PersonalInfoUpdateCommand>(personsalInfoDTO);
            await _mediator.Send(personalInfoUpdateCommand);
        }

        public async Task DeletePersonalInfoAsync(int? id)
        {
            var personalInfoRemoveCommand = new PersonalInfoRemoveCommand(id!.Value);
            if (personalInfoRemoveCommand == null)
                throw new Exception($"Entity could not be loaded.");

            await _mediator.Send(personalInfoRemoveCommand);
        }

    }
}
