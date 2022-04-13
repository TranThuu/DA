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
    internal class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.FullName)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.UrlSlug)
                .HasMaxLength(255)
                .IsRequired();

            builder.Property(u => u.Introduce)
                .HasColumnType("ntext");

            builder.Property(u => u.AvatarImage)
                .HasMaxLength(255);

            builder.Property(u => u.BackgroundImage)
                .HasMaxLength(255);

        }
    }
}
