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
    public class HistoricalCallConfig : IEntityTypeConfiguration<HistoricalCall>
    {
        public void Configure(EntityTypeBuilder<HistoricalCall> builder)
        {
            builder.ToTable(nameof(HistoricalCall), EntitySchema.Application).HasKey(x => x.Id);
           

            builder
             .HasMany(a => a.ScheduledCalls_LatestHistoricalCall)
             .WithOne(b => b.LatestHistoricalCall)
             .HasForeignKey(b => b.LatestHistoricalCallId);

            builder
             .HasMany(a => a.HistoricalCalls_LatestHistoricalCall)
             .WithOne(b => b.LatestHistoricalCall)
             .HasForeignKey(b => b.LatestHistoricalCallId);

           

            builder
               .HasMany(e => e.HistoricalCallPathResults)
               .WithOne(e => e.HistoricalCall)
               .HasForeignKey(e => e.HistoricalCallId);

            builder
             .HasMany(e => e.Pim_contact_attempts_historys)
             .WithOne(e => e.HistoricalCall)
             .HasForeignKey(e => e.HistoricalCallId);
        }
    }
}
