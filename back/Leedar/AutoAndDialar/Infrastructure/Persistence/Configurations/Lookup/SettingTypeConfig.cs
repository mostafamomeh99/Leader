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

    public class SettingTypeConfig : IEntityTypeConfiguration<SettingType>
    {
        public void Configure(EntityTypeBuilder<SettingType> builder)
        {
            builder.ToTable(nameof(SettingType), EntitySchema.Lookup).HasKey(x => x.Id);

            builder
               .HasMany(e => e.UserSettings)
               .WithOne(e => e.SettingType)
               .HasForeignKey(e => e.SettingTypeId)
               .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
