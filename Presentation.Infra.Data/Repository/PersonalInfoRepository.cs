using Microsoft.EntityFrameworkCore;
using Presentation.Domain.Entities;
using Presentation.Domain.Interfaces;
using Presentation.Infra.Data.Context;

namespace Presentation.Infra.Data.Repository
{
    public class PersonalInfoRepository : IPersonalInfoRepository
    {
        private readonly ApplicationDbContext _personalInfoContext;

        public PersonalInfoRepository(ApplicationDbContext context)
        {
            _personalInfoContext = context;
        }

        public async Task<IEnumerable<PersonalInfo>> GetPersonalInfosAsync()
        {
            return await _personalInfoContext.PersonalInfos!.ToListAsync();
        }

        public async Task<PersonalInfo> AddPersonalInfoAsync(PersonalInfo personalInfo)
        {
            _personalInfoContext.Add(personalInfo);
            await _personalInfoContext.SaveChangesAsync();
            return personalInfo;
        }

        public async Task<PersonalInfo> GetPersonalInfoByIdAsync(int? id)
        {
            var personalInfo = await _personalInfoContext.PersonalInfos!.FirstOrDefaultAsync(m => m.Id == id);
            return personalInfo!;
        }

        public async Task<PersonalInfo> RemovePersonalInfoAsync(PersonalInfo personalInfo)
        {
            _personalInfoContext.PersonalInfos!.Remove(personalInfo);
            await _personalInfoContext.SaveChangesAsync();
            return personalInfo;
        }

        public async Task<PersonalInfo> UpdatePersonalInfoAsync(PersonalInfo personalInfo)
        {
            _personalInfoContext.Update(personalInfo);
            await _personalInfoContext.SaveChangesAsync();
            return personalInfo;
        }
    }
}
