using HighSchool.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace HighSchool.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class HighSchoolController : AbpControllerBase
{
    protected HighSchoolController()
    {
        LocalizationResource = typeof(HighSchoolResource);
    }
}
