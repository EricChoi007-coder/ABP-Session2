using System.Threading.Tasks;

namespace Sample.Novel.Domain.Data
{
    public interface INovelDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}