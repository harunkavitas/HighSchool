using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace HighSchool.Courses
{
    public class Course: AuditedAggregateRoot<Guid>
    {
        public string Name { get; set; }

        public CourseType Type { get; set; }

        public DateTime PublishDate { get; set; }

        public float Price { get; set; }
    }
}
