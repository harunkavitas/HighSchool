﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace HighSchool.Teachers
{
    public interface ITeacherRepository : IRepository<Teacher, Guid>
    {
        Task<Teacher> FindByNameAsync(string name);

        Task<List<Teacher>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
