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

    public class EntityActionGroupConditionGroupConfig : IEntityTypeConfiguration<EntityActionGroupConditionGroup>
    {
        public void Configure(EntityTypeBuilder<EntityActionGroupConditionGroup> builder)
        {
            builder.ToTable(nameof(EntityActionGroupConditionGroup), EntitySchema.Entity).HasKey(x => x.Id);

            

            builder
               .HasMany(e => e.EntityActionConditions)
               .WithOne(e => e.EntityActionGroupConditionGroup)
               .HasForeignKey(e => e.EntityActionGroupConditionGroupId);




        }
    }
}
