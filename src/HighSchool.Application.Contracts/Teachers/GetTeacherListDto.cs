using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace HighSchool.Teachers
{
    public class GetTeacherListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
