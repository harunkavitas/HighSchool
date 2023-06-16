using AutoMapper;
using HighSchool.Courses;

namespace HighSchool.Blazor
{
    public class HighSchoolBlazorAutoMapperProfile : Profile
    {
        public HighSchoolBlazorAutoMapperProfile()
        {
            CreateMap<CourseDto, CreateUpdateCourseDto>();
        }
    }
}
