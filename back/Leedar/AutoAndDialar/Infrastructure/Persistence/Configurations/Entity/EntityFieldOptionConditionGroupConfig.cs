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

    public class EntityFieldOptionConditionGroupConfig : IEntityTypeConfiguration<EntityFieldOptionConditionGroup>
    {
        public void Configure(EntityTypeBuilder<EntityFieldOptionConditionGroup> builder)
        {
            builder.ToTable(nameof(EntityFieldOptionConditionGroup), EntitySchema.Entity).HasKey(x => x.Id);



            builder
               .HasMany(e => e.EntityFieldOptionConditions)
               .WithOne(e => e.EntityFieldOptionConditionGroup)
               .HasForeignKey(e => e.EntityFieldOptionConditionGroupId);




        }
    }
}
