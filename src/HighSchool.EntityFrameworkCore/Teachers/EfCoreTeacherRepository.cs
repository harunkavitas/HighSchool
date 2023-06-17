using HighSchool.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace HighSchool.Teachers
{
    public class EfCoreTeacherRepository : EfCoreRepository<HighSchoolDbContext, Teacher, Guid>,
        ITeacherRepository
    {
        public EfCoreTeacherRepository(
        IDbContextProvider<HighSchoolDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

        public async Task<Teacher> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(teacher => teacher.Name == name);
        }

        public async Task<List<Teacher>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    teacher => teacher.Name.Contains(filter)
                    )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
