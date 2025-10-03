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
    public class DynamicReportFieldConfig : IEntityTypeConfiguration<DynamicReportField>
    {
        public void Configure(EntityTypeBuilder<DynamicReportField> builder)
        {
            builder.ToTable(nameof(DynamicReportField), EntitySchema.Entity).HasKey(x => x.Id);
        }
    }
}
