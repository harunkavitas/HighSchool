using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace HighSchool.Data;

/* This is used if database provider does't define
 * IHighSchoolDbSchemaMigrator implementation.
 */
public class NullHighSchoolDbSchemaMigrator : IHighSchoolDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
