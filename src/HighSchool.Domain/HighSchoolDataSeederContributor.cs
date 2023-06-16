using HighSchool.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace HighSchool
{
    public class HighSchoolDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Course, Guid> _courseRepository;

        public HighSchoolDataSeederContributor(IRepository<Course, Guid> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _courseRepository.GetCountAsync() <= 0)
            {
                await _courseRepository.InsertAsync(
                    new Course
                    {
                        Name = "Algorithm",
                        Type = CourseType.Maths,
                        PublishDate = new DateTime(2023, 6, 8),
                        Price = 20
                    },
                    autoSave: true
                );

                await _courseRepository.InsertAsync(
                    new Course
                    {
                        Name = "2. World War",
                        Type = CourseType.History,
                        PublishDate = new DateTime(2023, 6, 9),
                        Price = 15
                    },
                    autoSave: true
                );
            }
        }
    }
}
