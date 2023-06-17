using AutoMapper;
using HighSchool.Courses;
using HighSchool.Teachers;

namespace HighSchool.Blazor
{
    public class HighSchoolBlazorAutoMapperProfile : Profile
    {
        public HighSchoolBlazorAutoMapperProfile()
        {
            CreateMap<CourseDto, CreateUpdateCourseDto>();
            CreateMap<TeacherDto, UpdateTeacherDto>();

        }
    }
}
