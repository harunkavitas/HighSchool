using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace HighSchool.Teachers
{
    public class TeacherAlreadyExistsException : BusinessException
    {
        public TeacherAlreadyExistsException(string name)
        : base()
        {
            WithData("name", name);
        }
    }
}
