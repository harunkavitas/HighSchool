using HighSchool.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace HighSchool;

[DependsOn(
    typeof(HighSchoolEntityFrameworkCoreTestModule)
    )]
public class HighSchoolDomainTestModule : AbpModule
{

}
