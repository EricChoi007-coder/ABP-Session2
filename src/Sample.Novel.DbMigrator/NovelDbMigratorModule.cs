using Microsoft.Extensions.DependencyInjection;
using Sample.Novel.Domain;
using Sample.Novel.EntityFrameworkCore.DbMigrations;
using Volo.Abp;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace Sample.Novel.DbMigrator
{
    [DependsOn(typeof(AbpAutofacModule),
        typeof(NovelEntityFrameworkCoreDbMigrationsModule),
        typeof(NovelDomainModule))]
    public class NovelDbMigratorModule : AbpModule
    {

    }
}