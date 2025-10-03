using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Identity
{
    public class UserRealTimeConfig : IEntityTypeConfiguration<UserRealTime>
    {
        public void Configure(EntityTypeBuilder<UserRealTime> builder)
        {
            builder.ToTable(nameof(UserRealTime), EntitySchema.Identity).HasKey(x => new { x.UserId, x.SignalRId });



        }
    }
}
