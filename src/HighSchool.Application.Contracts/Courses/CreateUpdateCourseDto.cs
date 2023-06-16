using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HighSchool.Courses
{
    public class CreateUpdateCourseDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }

        [Required]
        public CourseType Type { get; set; } = CourseType.Undefined;

        [Required]
        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; } = DateTime.Now;

        [Required]
        public float Price { get; set; }
    }
}
