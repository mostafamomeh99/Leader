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

    public class EntityFieldActionGroupConfig : IEntityTypeConfiguration<EntityFieldActionGroup>
    {
        public void Configure(EntityTypeBuilder<EntityFieldActionGroup> builder)
        {
            builder.ToTable(nameof(EntityFieldActionGroup), EntitySchema.Entity).HasKey(x => x.Id);



            builder
               .HasMany(e => e.EntityFieldActions)
               .WithOne(e => e.EntityFieldActionGroup)
               .HasForeignKey(e => e.EntityFieldActionGroupId);

            builder
               .HasMany(e => e.EntityFieldActionGroupTriggerTypes)
               .WithOne(e => e.EntityFieldActionGroup)
               .HasForeignKey(e => e.EntityFieldActionGroupId);

            builder
               .HasMany(e => e.EntityFieldActionGroupConditionGroups)
               .WithOne(e => e.EntityFieldActionGroup)
               .HasForeignKey(e => e.EntityFieldActionGroupId);
            

        }
    }
}
