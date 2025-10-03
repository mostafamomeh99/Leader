using Domain.Entities.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Log
{

    public class HistoricalCallGeneralReportSammaryConfig : IEntityTypeConfiguration<HistoricalCallGeneralReportSammary>
    {
        public void Configure(EntityTypeBuilder<HistoricalCallGeneralReportSammary> builder)
        {
            builder.ToTable(nameof(HistoricalCallGeneralReportSammary), EntitySchema.Log).HasKey(x => x.Id);
            builder.Property(x => x.CallStatusOtherNote).HasMaxLength(int.MaxValue);

        }
    }
}
