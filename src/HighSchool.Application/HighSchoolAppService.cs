using System;
using System.Collections.Generic;
using System.Text;
using HighSchool.Localization;
using Volo.Abp.Application.Services;

namespace HighSchool;

/* Inherit your application services from this class.
 */
public abstract class HighSchoolAppService : ApplicationService
{
    protected HighSchoolAppService()
    {
        LocalizationResource = typeof(HighSchoolResource);
    }
}
