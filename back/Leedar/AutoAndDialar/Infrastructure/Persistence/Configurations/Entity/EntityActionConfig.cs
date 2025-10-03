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

    public class EntityActionConfig : IEntityTypeConfiguration<EntityAction>
    {
        public void Configure(EntityTypeBuilder<EntityAction> builder)
        {
            builder.ToTable(nameof(EntityAction), EntitySchema.Entity).HasKey(x => x.Id);

            builder
               .HasMany(e => e.EntityActionFields)
               .WithOne(e => e.EntityAction)
               .HasForeignKey(e => e.EntityActionId);

            builder
           .HasMany(e => e.EntityActionDynamicFunctionParameters)
           .WithOne(e => e.EntityAction)
           .HasForeignKey(e => e.EntityActionId);

            builder
           .HasMany(e => e.EntityActionDynamicFunctionResults)
           .WithOne(e => e.EntityAction)
           .HasForeignKey(e => e.EntityActionId);
            

        }
    }
}
