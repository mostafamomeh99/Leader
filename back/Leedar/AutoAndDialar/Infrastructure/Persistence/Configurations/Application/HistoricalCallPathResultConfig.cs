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
    public class HistoricalCallPathResultConfig : IEntityTypeConfiguration<HistoricalCallPathResult>
    {
        public void Configure(EntityTypeBuilder<HistoricalCallPathResult> builder)
        {
            builder.ToTable(nameof(HistoricalCallPathResult), EntitySchema.Application).HasKey(x => x.Id);
            builder.Property(x => x.Value).HasMaxLength(int.MaxValue);
          

        }
    }
}
