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
    public class SavedPostConfig : IEntityTypeConfiguration<SavedPost>
    {
        public void Configure(EntityTypeBuilder<SavedPost> builder)
        {
            builder.HasOne<User>(s => s.User)
                   .WithMany(p => p.SavedPosts)
                   .HasForeignKey(pt => pt.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne<Post>(s => s.Post)
                    .WithMany(p => p.SavedPosts)
                    .HasForeignKey(s => s.PostId)
                   .OnDelete(DeleteBehavior.NoAction);

        }
    }
}



