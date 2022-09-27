using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Sample.Novel.Domain.Data
{
    public class NovelDbMigrationService : ITransientDependency
    {
        private readonly IDataSeeder _dataSeeder;
        private readonly IEnumerable<INovelDbSchemaMigrator> _dbSchemaMigrators;

        public NovelDbMigrationService(
            IDataSeeder dataSeeder,
            IEnumerable<INovelDbSchemaMigrator> dbSchemaMigrators)
        {
            _dataSeeder = dataSeeder;
            _dbSchemaMigrators = dbSchemaMigrators;
        }

        public async Task MigrateAsync()
        {
            foreach (var migrator in _dbSchemaMigrators)
            {
                await migrator.MigrateAsync();
            }
            
            await _dataSeeder.SeedAsync();
        }
    }
}