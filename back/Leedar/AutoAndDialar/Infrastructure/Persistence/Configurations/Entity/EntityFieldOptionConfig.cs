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

    public class EntityFieldOptionConfig : IEntityTypeConfiguration<EntityFieldOption>
    {
        public void Configure(EntityTypeBuilder<EntityFieldOption> builder)
        {
            builder.ToTable(nameof(EntityFieldOption), EntitySchema.Entity).HasKey(x => x.Id);



            builder
               .HasMany(e => e.EntityFieldOptionConditionGroups)
               .WithOne(e => e.EntityFieldOption)
               .HasForeignKey(e => e.EntityFieldOptionId);




        }
    }
}
