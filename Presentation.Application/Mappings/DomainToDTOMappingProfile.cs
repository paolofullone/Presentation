using AutoMapper;
using Presentation.Application.DTOs;
using Presentation.Domain.Entities;

namespace Presentation.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<PersonalInfo, PersonalInfoDTO>().ReverseMap();
        }

    }
}
