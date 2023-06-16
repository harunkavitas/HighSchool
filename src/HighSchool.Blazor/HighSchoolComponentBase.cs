using HighSchool.Localization;
using Volo.Abp.AspNetCore.Components;

namespace HighSchool.Blazor;

public abstract class HighSchoolComponentBase : AbpComponentBase
{
    protected HighSchoolComponentBase()
    {
        LocalizationResource = typeof(HighSchoolResource);
    }
}
