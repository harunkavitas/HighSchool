using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HighSchool.Data;
using Volo.Abp.DependencyInjection;

namespace HighSchool.EntityFrameworkCore;

public class EntityFrameworkCoreHighSchoolDbSchemaMigrator
    : IHighSchoolDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreHighSchoolDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the HighSchoolDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<HighSchoolDbContext>()
            .Database
            .MigrateAsync();
    }
}
