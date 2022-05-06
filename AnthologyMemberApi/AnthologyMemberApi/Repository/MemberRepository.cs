using AnthologyMemberApi.Models;

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnthologyMemberApi.Repository
{
    public class MemberRepository : IRepository<MemberDemographic>
    {
        MemberStoreContext memberDbContext;
        public MemberRepository(MemberStoreContext _memberDbContext)
        {
            memberDbContext = _memberDbContext;
        }

        public async Task<MemberDemographic> Create(MemberDemographic _object)
        {
            var obj  = await memberDbContext.MemberDemographics.AddAsync(_object);
            await memberDbContext.SaveChangesAsync();
            return obj.Entity;
        }

        public async Task<int> Delete(MemberDemographic _object)
        {
            int result = 0;
            var deleteObj = await memberDbContext.MemberDemographics.FirstOrDefaultAsync(x => x.Id == _object.Id);

            if (deleteObj != null)
            {
               
                memberDbContext.MemberDemographics.Remove(deleteObj);
                result = await memberDbContext.SaveChangesAsync();
                return result;
            }
            return result;
        }

        public async Task<List<MemberDemographic>> GetAll()
        {
            return await memberDbContext.MemberDemographics.ToListAsync();
        }

        public async Task<MemberDemographic> GetById(int Id)
        {
            return await memberDbContext.MemberDemographics.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task Update(MemberDemographic _object)
        {
            memberDbContext.MemberDemographics.Update(_object);

            //Commit the transaction
            await memberDbContext.SaveChangesAsync();
        }
    }
}
