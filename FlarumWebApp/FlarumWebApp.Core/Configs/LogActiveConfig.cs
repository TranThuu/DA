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
    public class LogActiveConfig : IEntityTypeConfiguration<LogActive>
    {
        public void Configure(EntityTypeBuilder<LogActive> builder)
        {
            builder.Property(x => x.Content).IsRequired().HasMaxLength(1024).HasColumnType("nvarchar");


            builder.HasOne<User>(x => x.UserActor)
                .WithMany(l => l.LogActiveActors)
                .HasForeignKey(x => x.UserActorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<User>(x => x.UserVictim)
                .WithMany(l => l.LogActiveVictims)
                .HasForeignKey(x => x.UserVictimId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
