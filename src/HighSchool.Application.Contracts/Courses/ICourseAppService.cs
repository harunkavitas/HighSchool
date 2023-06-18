using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace HighSchool.Courses
{
    public interface ICourseAppService:
        ICrudAppService< //Defines CRUD methods
        CourseDto, //Used to show courses
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCourseDto> //Used to create/update a course
    {
        // ADD the NEW METHOD
        Task<ListResultDto<TeacherLookupDto>> GetTeacherLookupAsync();
    }
}
