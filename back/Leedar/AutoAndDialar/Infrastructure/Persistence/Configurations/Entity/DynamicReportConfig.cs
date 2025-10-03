using Domain.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Entity
{
    public class DynamicReportConfig : IEntityTypeConfiguration<DynamicReport>
    {
        public void Configure(EntityTypeBuilder<DynamicReport> builder)
        {
            builder.ToTable(nameof(DynamicReport), EntitySchema.Entity).HasKey(x => x.Id);

            builder
            .HasMany(e => e.DynamicReportFields)
            .WithOne(e => e.DynamicReport)
            .HasForeignKey(e => e.DynamicReportId);
        }
    }
}
