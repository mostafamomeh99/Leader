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

    public class EntityFieldConditionConfig : IEntityTypeConfiguration<EntityFieldCondition>
    {
        public void Configure(EntityTypeBuilder<EntityFieldCondition> builder)
        {
            builder.ToTable(nameof(EntityFieldCondition), EntitySchema.Entity).HasKey(x => x.Id);


            builder.Property(x => x.CondetionValue).HasMaxLength(int.MaxValue);




        }
    }
}
