using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.Domain;
using Sample.Novel.Domain.Data;
using Volo.Abp.DependencyInjection;

namespace Sample.Novel.EntityFrameworkCore.DbMigrations
{
    [ExposeServices(typeof(INovelDbSchemaMigrator))]
    public class NovelEntityFrameworkCoreDbSchemaMigrator : INovelDbSchemaMigrator, ITransientDependency
    {
        private readonly IServiceProvider _serviceProvider;

        public NovelEntityFrameworkCoreDbSchemaMigrator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public async Task MigrateAsync()
        {
            await _serviceProvider
                .GetRequiredService<NovelMigrationsDbContext>()
                .Database.MigrateAsync();
        }
    }
}