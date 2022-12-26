using Presentation.Application.DTOs;

namespace Presentation.Application.Interfaces
{
    public interface IPersonalInfoService
    {
        Task<IEnumerable<PersonalInfoDTO>> GetPersonalInfoAsync();
        Task<PersonalInfoDTO> GetPersonalInfoByIdAsync(int? id);
        Task AddPersonalInfoAsync(PersonalInfoDTO personalInfoDTO);
        Task UpdatePersonalInfoAsync(PersonalInfoDTO personalInfoDTO);
        Task DeletePersonalInfoAsync(int? id);
    }
}
