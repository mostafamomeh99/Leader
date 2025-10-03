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

    public class EntityFieldActionGroupConditionGroupConfig : IEntityTypeConfiguration<EntityFieldActionGroupConditionGroup>
    {
        public void Configure(EntityTypeBuilder<EntityFieldActionGroupConditionGroup> builder)
        {
            builder.ToTable(nameof(EntityFieldActionGroupConditionGroup), EntitySchema.Entity).HasKey(x => x.Id);



            builder
               .HasMany(e => e.EntityFieldActionConditions)
               .WithOne(e => e.EntityFieldActionGroupConditionGroup)
               .HasForeignKey(e => e.EntityFieldActionGroupConditionGroupId);




        }
    }
}

