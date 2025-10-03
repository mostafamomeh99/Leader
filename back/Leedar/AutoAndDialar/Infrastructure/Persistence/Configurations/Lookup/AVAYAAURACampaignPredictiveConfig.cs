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

    public class AVAYAAURACampaignPredictiveConfig : IEntityTypeConfiguration<AVAYAAURACampaignPredictive>
    {
        public void Configure(EntityTypeBuilder<AVAYAAURACampaignPredictive> builder)
        {
            builder.ToTable(nameof(AVAYAAURACampaignPredictive), EntitySchema.Lookup).HasKey(x => x.Id);

            builder
               .HasMany(e => e.Categorys)
               .WithOne(e => e.AVAYAAURACampaignPredictive)
               .HasForeignKey(e => e.AVAYAAURACampaignPredictiveId)
               .OnDelete(DeleteBehavior.Cascade);
            
        }
    }
}
