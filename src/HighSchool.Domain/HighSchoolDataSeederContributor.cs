using HighSchool.Courses;
using HighSchool.Teachers;
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
        private readonly ITeacherRepository _teacherRepository;
        private readonly TeacherManager _teacherManager;

        public HighSchoolDataSeederContributor(IRepository<Course, Guid> courseRepository, ITeacherRepository teacherRepository,
        TeacherManager teacherManager)
        {
            _courseRepository = courseRepository;
            _teacherRepository = teacherRepository;
            _teacherManager = teacherManager;
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
            // ADDED SEED DATA FOR teachers

            if (await _teacherRepository.GetCountAsync() <= 0)
            {
                await _teacherRepository.InsertAsync(
                    await _teacherManager.CreateAsync(
                        "Doc.Dr. Alex Douglas",
                        new DateTime(1975, 06, 10),
                        "Douglas produced literary criticism and poetry, fiction and polemical journalism; and is best known for the allegorical novella Animal Farm (1995) and the dystopian novel Nineteen Eighty-Four (1999)."
                    )
                );

                await _teacherRepository.InsertAsync(
                    await _teacherManager.CreateAsync(
                        "Erling Truman",
                        new DateTime(1998, 05, 15),
                        "Truman Erling was an English teachers, screenwriter, essayist, humorist, satirist and dramatist. Adams was an advocate for environmentalism and conservation, a lover of fast cars, technological innovation and the Apple Macintosh, and a self-proclaimed 'radical atheist'."
                    )
                );
            }
        }
    }
}
