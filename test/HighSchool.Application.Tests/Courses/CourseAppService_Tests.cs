using HighSchool.Teachers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Validation;
using Xunit;

namespace HighSchool.Courses
{
    public class CourseAppService_Tests :HighSchoolApplicationTestBase
    {
        private readonly ICourseAppService _courseAppService;
        private readonly ITeacherAppService _teacherAppService;

        public CourseAppService_Tests()
        {
            _courseAppService = GetRequiredService<ICourseAppService>();
            _teacherAppService = GetRequiredService<ITeacherAppService>();
        }

        [Fact]
        public async Task Should_Get_List_Of_Course()
        {
            //Act
            var result = await _courseAppService.GetListAsync(
                new PagedAndSortedResultRequestDto()
            );

            //Assert
            result.TotalCount.ShouldBeGreaterThan(0);
            result.Items.ShouldContain(b => b.Name == "Static" &&
                                    b.TeacherName == "alexander Geller");
        }
        [Fact]
        public async Task Should_Create_A_Valid_Course()
        {
            var teachers = await _teacherAppService.GetListAsync(new GetTeacherListDto());
            var firstTeacher = teachers.Items.First();
            //Act
            var result = await _courseAppService.CreateAsync(
                new CreateUpdateCourseDto
                {
                    TeacherId = firstTeacher.Id,
                    Name = "New test Course #1",
                    Price = 10,
                    PublishDate = System.DateTime.Now,
                    Type = CourseType.Physics
                }
            );

            //Assert
            result.Id.ShouldNotBe(Guid.Empty);
            result.Name.ShouldBe("New test Course #1");
        }
        [Fact]
        public async Task Should_Not_Create_A_Course_Without_Name()
        {
            var exception = await Assert.ThrowsAsync<AbpValidationException>(async () =>
            {
                await _courseAppService.CreateAsync(
                    new CreateUpdateCourseDto
                    {
                        Name = "",
                        Price = 10,
                        PublishDate = DateTime.Now,
                        Type = CourseType.Deutsch
                    }
                );
            });

            exception.ValidationErrors
                .ShouldContain(err => err.MemberNames.Any(m => m == "Name"));
        }

    }
}
