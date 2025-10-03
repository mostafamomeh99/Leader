using Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class ScheduledCallConfig : IEntityTypeConfiguration<ScheduledCall>
    {
        public void Configure(EntityTypeBuilder<ScheduledCall> builder)
        {
            builder.ToTable(nameof(ScheduledCall), EntitySchema.Application).HasKey(x => x.Id);

           

        }
    }
}
