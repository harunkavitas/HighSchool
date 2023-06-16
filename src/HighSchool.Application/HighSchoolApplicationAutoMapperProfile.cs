﻿using AutoMapper;
using HighSchool.Courses;

namespace HighSchool;

public class HighSchoolApplicationAutoMapperProfile : Profile
{
    public HighSchoolApplicationAutoMapperProfile()
    {
        CreateMap<Course, CourseDto>();
        CreateMap<CreateUpdateCourseDto, Course>();
    }
}