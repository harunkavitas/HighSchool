using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HighSchool.Courses
{
    public class CourseDto: AuditedEntityDto<Guid>
    {
        public string Name { get; set; }

        public CourseType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}
