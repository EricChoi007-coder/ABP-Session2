using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sample.Novel.Domain;
using Sample.Novel.Domain.Data;
using Sample.Novel.EntityFrameworkCore.DbMigrations;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Sample.Novel.DbMigrator
{
    public class DbMigratorHostedService : IHostedService
    {
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly ILogger<DbMigratorHostedService> _logger;

        public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, ILogger<DbMigratorHostedService> logger)
        {
            _hostApplicationLifetime = hostApplicationLifetime;
            _logger = logger;
        }
        
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using var application = AbpApplicationFactory.Create<NovelDbMigratorModule>(options =>
            {
                options.UseAutofac();
            });

            application.Initialize();

            _logger.LogInformation("开始执行数据迁移……");
            await application
                .ServiceProvider
                .GetRequiredService<NovelDbMigrationService>()
                .MigrateAsync();

            application.Shutdown();

            _hostApplicationLifetime.StopApplication();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("数据迁移已完成。");
            return Task.CompletedTask;
        }
    }
}