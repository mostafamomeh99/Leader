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

    public class EntityMapConfig : IEntityTypeConfiguration<EntityMap>
    {
        public void Configure(EntityTypeBuilder<EntityMap> builder)
        {
            builder.ToTable(nameof(EntityMap), EntitySchema.Entity).HasKey(x => x.Id);

            builder
               .HasMany(e => e.DynamicReportFields)
               .WithOne(e => e.EntityMap)
               .HasForeignKey(e => e.EntityMapId);


        }
    }
}
