using Domain.Entities.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Lookup
{

    public class CampaignConfig : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable(nameof(Campaign), EntitySchema.Lookup).HasKey(x => x.Id);


            builder
               .HasMany(e => e.ScheduledCalls)
               .WithOne(e => e.Campaign)
               .HasForeignKey(e => e.CampaignId)
               .OnDelete(DeleteBehavior.NoAction);
            builder
               .HasMany(e => e.HistoricalCalls)
               .WithOne(e => e.Campaign)
               .HasForeignKey(e => e.CampaignId)
               .OnDelete(DeleteBehavior.NoAction);



            builder
             .HasMany(e => e.Pim_contact_attempts_historys)
             .WithOne(e => e.Campaign)
             .HasForeignKey(e => e.CampaignId);
        }
    }
}
