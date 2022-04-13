using FlarumWebApp.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlarumWebApp.Core.Configs
{
    public class Postconfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Category)
               .WithMany(u => u.Posts)
               .HasForeignKey(p => p.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);


            builder.Property(p => p.Title).HasMaxLength(1024).IsRequired().HasColumnType("nvarchar");

            builder.Property(p => p.ShortDescription).HasMaxLength(1024).IsRequired().HasColumnType("nvarchar");

            builder.Property(p => p.Title).HasMaxLength(255).HasColumnType("nvarchar");

            builder.Property(p => p.UrlSlug).HasMaxLength(255).IsRequired().HasColumnType("nvarchar");

            builder.Property(p => p.Content).IsRequired().HasColumnType("ntext");

            builder.Property(p => p.LikeCount).HasDefaultValue(0);

            builder.Property(p => p.Dislikecount).HasDefaultValue(0);

        }
    }
}
