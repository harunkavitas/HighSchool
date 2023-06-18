using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HighSchool.Courses
{
    public class TeacherLookupDto: EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
