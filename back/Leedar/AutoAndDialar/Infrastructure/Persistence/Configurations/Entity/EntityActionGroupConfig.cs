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

    public class EntityActionGroupConfig : IEntityTypeConfiguration<EntityActionGroup>
    {
        public void Configure(EntityTypeBuilder<EntityActionGroup> builder)
        {
            builder.ToTable(nameof(EntityActionGroup), EntitySchema.Entity).HasKey(x => x.Id);

            builder
               .HasMany(e => e.EntityActions)
               .WithOne(e => e.EntityActionGroup)
               .HasForeignKey(e => e.EntityActionGroupId);

            builder
               .HasMany(e => e.EntityActionGroupTriggerTypes)
               .WithOne(e => e.EntityActionGroup)
               .HasForeignKey(e => e.EntityActionGroupId);

            builder
               .HasMany(e => e.EntityActionGroupConditionGroups)
               .WithOne(e => e.EntityActionGroup)
               .HasForeignKey(e => e.EntityActionGroupId);
            

        }
    }
}
