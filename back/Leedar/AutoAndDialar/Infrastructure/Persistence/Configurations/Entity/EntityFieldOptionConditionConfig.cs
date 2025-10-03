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

    public class EntityFieldOptionConditionConfig : IEntityTypeConfiguration<EntityFieldOptionCondition>
    {
        public void Configure(EntityTypeBuilder<EntityFieldOptionCondition> builder)
        {
            builder.ToTable(nameof(EntityFieldOptionCondition), EntitySchema.Entity).HasKey(x => x.Id);

            builder.Property(x => x.CondetionValue).HasMaxLength(int.MaxValue);





        }
    }
}
