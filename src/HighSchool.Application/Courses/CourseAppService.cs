using HighSchool.Permissions;
using HighSchool.Teachers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace HighSchool.Courses
{
    [Authorize(HighSchoolPermissions.Courses.Default)]
    public class CourseAppService :
    CrudAppService<
        Course, //The Course entity
        CourseDto, //Used to show Courses
        Guid, //Primary key of the Course entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCourseDto>, //Used to create/update a Course
    ICourseAppService //implement the ICourseAppService
    {
        private readonly ITeacherRepository _teacherRepository;

        public CourseAppService(
            IRepository<Course, Guid> repository,
            ITeacherRepository teacherRepository)
            : base(repository)
        {
            _teacherRepository = teacherRepository;
            GetPolicyName = HighSchoolPermissions.Courses.Default;
            GetListPolicyName = HighSchoolPermissions.Courses.Default;
            CreatePolicyName = HighSchoolPermissions.Courses.Create;
            UpdatePolicyName = HighSchoolPermissions.Courses.Edit;
            DeletePolicyName = HighSchoolPermissions.Courses.Delete;
        }

        public override async Task<CourseDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Course> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join Courses and Teachers
            var query = from course in queryable
                        join teacher in await _teacherRepository.GetQueryableAsync() on course.TeacherId equals teacher.Id
                        where course.Id == id
                        select new { course, teacher };

            //Execute the query and get the Course with Teacher
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Course), id);
            }

            var courseDto = ObjectMapper.Map<Course, CourseDto>(queryResult.course);
            courseDto.TeacherName = queryResult.teacher.Name;
            return courseDto;
        }

        public override async Task<PagedResultDto<CourseDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Course> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join Courses and teachers
            var query = from course in queryable
                        join teacher in await _teacherRepository.GetQueryableAsync() on course.TeacherId equals teacher.Id
                        select new { course, teacher };

            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of CourseDto objects
            var courseDtos = queryResult.Select(x =>
            {
                var courseDto = ObjectMapper.Map<Course, CourseDto>(x.course);
                courseDto.TeacherName = x.teacher.Name;
                return courseDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<CourseDto>(
                totalCount,
                courseDtos
            );
        }

        public async Task<ListResultDto<TeacherLookupDto>> GetTeacherLookupAsync()
        {
            var teachers = await _teacherRepository.GetListAsync();

            return new ListResultDto<TeacherLookupDto>(
                ObjectMapper.Map<List<Teacher>, List<TeacherLookupDto>>(teachers)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"course.{nameof(Course.Name)}";
            }

            if (sorting.Contains("teacherName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "teacherName",
                    "teacher.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"course.{sorting}";
        }
    }
}