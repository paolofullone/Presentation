using Presentation.Domain.Entities;

namespace Presentation.Domain.Interfaces
{
    public interface IPersonalInfoRepository
    {
        Task<IEnumerable<PersonalInfo>> GetPersonalInfosAsync();
        Task<PersonalInfo> GetPersonalInfoByIdAsync(int? id);
        Task<PersonalInfo> AddPersonalInfoAsync(PersonalInfo personalInfo);
        Task<PersonalInfo> UpdatePersonalInfoAsync(PersonalInfo personalInfo);
        Task<PersonalInfo> RemovePersonalInfoAsync(PersonalInfo personalInfo);
    }
}
