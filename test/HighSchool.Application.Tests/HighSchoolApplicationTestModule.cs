using Volo.Abp.Modularity;

namespace HighSchool;

[DependsOn(
    typeof(HighSchoolApplicationModule),
    typeof(HighSchoolDomainTestModule)
    )]
public class HighSchoolApplicationTestModule : AbpModule
{

}
