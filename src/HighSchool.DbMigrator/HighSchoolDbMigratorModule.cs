using HighSchool.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace HighSchool.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(HighSchoolEntityFrameworkCoreModule),
    typeof(HighSchoolApplicationContractsModule)
    )]
public class HighSchoolDbMigratorModule : AbpModule
{

}
