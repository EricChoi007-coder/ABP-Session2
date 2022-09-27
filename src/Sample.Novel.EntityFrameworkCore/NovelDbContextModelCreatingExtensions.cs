using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.EntityFrameworkCore.Mappings;
using Volo.Abp;

namespace Sample.Novel.EntityFrameworkCore
{
    public static class NovelDbContextModelCreatingExtensions
    {
        public static void ConfigureNovel(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AuthorMap());
            builder.ApplyConfiguration(new CategoryMap());
            builder.ApplyConfiguration(new BookMap());
            builder.ApplyConfiguration(new ChapterMap());
            builder.ApplyConfiguration(new ChapterTextMap());
            builder.ApplyConfiguration(new VolumeMap());
        }
    }
}