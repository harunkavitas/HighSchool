using System.Threading.Tasks;

namespace HighSchool.Data;

public interface IHighSchoolDbSchemaMigrator
{
    Task MigrateAsync();
}
