using HighSchool.TeacherConstsTeachers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HighSchool.Teachers
{
    public class CreateTeacherDto
    {
        [Required]
        [StringLength(TeacherConsts.MaxNameLength)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public string ShortBio { get; set; }
    }
}
