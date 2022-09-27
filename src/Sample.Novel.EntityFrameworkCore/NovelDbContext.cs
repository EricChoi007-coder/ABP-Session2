using System;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Sample.Novel.Domain.Author.Entities;
using Sample.Novel.Domain.Book.Entities;
using Sample.Novel.Domain.Category.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Sample.Novel.EntityFrameworkCore
{
    [ConnectionStringName("Novel")]
    public class NovelDbContext : AbpDbContext<NovelDbContext>
    {
        public DbSet<Chapter> Chapters { get; set; }

        public NovelDbContext(DbContextOptions<NovelDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ConfigureNovel();
        } 
    }
}
