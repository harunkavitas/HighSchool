using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HighSchool.Courses
{
    public class CourseDto: AuditedEntityDto<Guid>
    {
        public Guid TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string Name { get; set; }

        public CourseType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}
