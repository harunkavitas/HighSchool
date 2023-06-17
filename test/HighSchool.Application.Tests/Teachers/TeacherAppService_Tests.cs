using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace HighSchool.Teachers
{
    public class TeacherAppService_Tests : HighSchoolApplicationTestBase
    {
        private readonly ITeacherAppService _teacherAppService;

        public TeacherAppService_Tests()
        {
            _teacherAppService = GetRequiredService<ITeacherAppService>();
        }

        [Fact]
        public async Task Should_Get_All_Teachers_Without_Any_Filter()
        {
            var result = await _teacherAppService.GetListAsync(new GetTeacherListDto());

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(2);
            result.Items.ShouldContain(teacher => teacher.Name == "Doc.Dr. Alex Douglas");
            result.Items.ShouldContain(teacher => teacher.Name == "Erling Truman");
        }

        [Fact]
        public async Task Should_Get_Filtered_Teachers()
        {
            var result = await _teacherAppService.GetListAsync(
                new GetTeacherListDto { Filter = "Alex" });

            result.TotalCount.ShouldBeGreaterThanOrEqualTo(1);
            result.Items.ShouldContain(teacher => teacher.Name == "Doc.Dr. Alex Douglas");
            result.Items.ShouldNotContain(teacher => teacher.Name == "Erling Truman");
        }

        [Fact]
        public async Task Should_Create_A_New_Teacher()
        {
            var teacherDto = await _teacherAppService.CreateAsync(
                new CreateTeacherDto
                {
                    Name = "Edward Bellamy",
                    BirthDate = new DateTime(1850, 05, 22),
                    ShortBio = "Edward Bellamy was an American teacher..."
                }
            );

            teacherDto.Id.ShouldNotBe(Guid.Empty);
            teacherDto.Name.ShouldBe("Edward Bellamy");
        }

        [Fact]
        public async Task Should_Not_Allow_To_Create_Duplicate_Teacher()
        {
            await Assert.ThrowsAsync<TeacherAlreadyExistsException>(async () =>
            {
                await _teacherAppService.CreateAsync(
                    new CreateTeacherDto
                    {
                        Name = "Erling Truman",
                        BirthDate = DateTime.Now,
                        ShortBio = "..."
                    }
                );
            });
        }

        //TODO: Test other methods...
    }
}
