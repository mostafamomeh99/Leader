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

    public class EntityFieldConditionGroupConfig : IEntityTypeConfiguration<EntityFieldConditionGroup>
    {
        public void Configure(EntityTypeBuilder<EntityFieldConditionGroup> builder)
        {
            builder.ToTable(nameof(EntityFieldConditionGroup), EntitySchema.Entity).HasKey(x => x.Id);



            builder
               .HasMany(e => e.EntityFieldConditions)
               .WithOne(e => e.EntityFieldConditionGroup)
               .HasForeignKey(e => e.EntityFieldConditionGroupId);




        }
    }
}
