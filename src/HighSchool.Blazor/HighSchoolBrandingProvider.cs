using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace HighSchool.Blazor;

[Dependency(ReplaceServices = true)]
public class HighSchoolBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "HighSchool";
}
