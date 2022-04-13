using FlarumWebApp.Core.BaseEntities;
using FlarumWebApp.Core.Configs;
using FlarumWebApp.Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlarumWebApp.Core.DataContexts
{
    public class FlarumDbContext : IdentityDbContext<User, Role, Guid>
    {
        public FlarumDbContext()
        {

        }

        public FlarumDbContext(DbContextOptions<FlarumDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-KGKSBEN\SQLEXPRESS;Database=SuperAweSomeProjectWebApplication;Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new Categoryconfig());
            builder.ApplyConfiguration(new CommentConfig());
            builder.ApplyConfiguration(new LogActiveConfig());
            builder.ApplyConfiguration(new Postconfig());
            builder.ApplyConfiguration(new SavedPostConfig());
            builder.ApplyConfiguration(new UserConfig());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<LogActive> LogActives { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<SavedPost> SavedPosts { get; set; }

        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }

        public void BeforeSaveChanges()
        {
            var dateNow = DateTime.Now;
            foreach (var entity in ChangeTracker.Entries())
            {
                if (entity.Entity is Base baseEntity)
                    switch (entity.State)
                    {
                        case EntityState.Added:
                            baseEntity.CreateOn = dateNow;
                            break;
                        case EntityState.Modified:
                            baseEntity.ModifiedOn = dateNow;
                            break;
                    }
            }
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            BeforeSaveChanges();
            return base.SaveChangesAsync(cancellationToken);
        }

    }
}
