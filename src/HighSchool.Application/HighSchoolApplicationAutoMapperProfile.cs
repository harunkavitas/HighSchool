using AutoMapper;
using HighSchool.Courses;
using HighSchool.Teachers;

namespace HighSchool;

public class HighSchoolApplicationAutoMapperProfile : Profile
{
    public HighSchoolApplicationAutoMapperProfile()
    {
        CreateMap<Course, CourseDto>();
        CreateMap<CreateUpdateCourseDto, Course>();
        CreateMap<Teacher, TeacherDto>();

    }
}
