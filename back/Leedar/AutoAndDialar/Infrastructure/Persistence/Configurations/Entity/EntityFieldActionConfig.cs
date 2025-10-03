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

    public class EntityFieldActionConfig : IEntityTypeConfiguration<EntityFieldAction>
    {
        public void Configure(EntityTypeBuilder<EntityFieldAction> builder)
        {
            builder.ToTable(nameof(EntityFieldAction), EntitySchema.Entity).HasKey(x => x.Id);



            builder
               .HasMany(e => e.EntityFieldActionFields)
               .WithOne(e => e.EntityFieldAction)
               .HasForeignKey(e => e.EntityFieldActionId);

            //builder
            //   .HasMany(e => e.EntityFieldActionDynamicFunctions)
            //   .WithOne(e => e.EntityFieldAction)
            //   .HasForeignKey(e => e.EntityFieldActionId);



            builder
            .HasMany(e => e.EntityFieldActionDynamicFunctionParameters)
            .WithOne(e => e.EntityFieldAction)
            .HasForeignKey(e => e.EntityFieldActionId);

            builder
            .HasMany(e => e.EntityFieldActionDynamicFunctionResults)
            .WithOne(e => e.EntityFieldAction)
            .HasForeignKey(e => e.EntityFieldActionId);
        }
    }
}
