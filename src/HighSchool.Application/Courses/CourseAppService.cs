using HighSchool.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace HighSchool.Courses
{
    public class CourseAppService :
        CrudAppService<
        Course, //The Book entity
        CourseDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCourseDto>, //Used to create/update a book
        ICourseAppService //implement the IBookAppService
    {
        public CourseAppService(IRepository<Course, Guid> repository) : base(repository)
        {
            GetPolicyName = HighSchoolPermissions.Courses.Default;
            GetListPolicyName = HighSchoolPermissions.Courses.Default;
            CreatePolicyName = HighSchoolPermissions.Courses.Create;
            UpdatePolicyName = HighSchoolPermissions.Courses.Edit;
            DeletePolicyName = HighSchoolPermissions.Courses.Delete;
        }
    }
}
