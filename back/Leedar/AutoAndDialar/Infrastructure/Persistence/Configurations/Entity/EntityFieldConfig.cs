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

    public class EntityFieldConfig : IEntityTypeConfiguration<EntityField>
    {
        public void Configure(EntityTypeBuilder<EntityField> builder)
        {
            builder.ToTable(nameof(EntityField), EntitySchema.Entity).HasKey(x => x.Id);



            builder
               .HasMany(e => e.EntityFieldActionGroups)
               .WithOne(e => e.EntityField)
               .HasForeignKey(e => e.EntityFieldId);

            builder
              .HasMany(e => e.EntityFieldConditionGroups)
              .WithOne(e => e.EntityField)
              .HasForeignKey(e => e.EntityFieldId);

            builder
              .HasMany(e => e.EntityFieldOptions)
              .WithOne(e => e.EntityField)
              .HasForeignKey(e => e.EntityFieldId);

            builder
              .HasMany(e => e.EntityFieldValues)
              .WithOne(e => e.EntityField)
              .HasForeignKey(e => e.EntityFieldId);

            builder
              .HasMany(e => e.EntityFieldActionDynamicFunctionParameters)
              .WithOne(e => e.EntityField)
              .HasForeignKey(e => e.EntityFieldId);

            builder
              .HasMany(e => e.EntityFieldActionDynamicFunctionResults)
              .WithOne(e => e.EntityField)
              .HasForeignKey(e => e.EntityFieldId);

            builder
              .HasMany(e => e.EntityActionDynamicFunctionParameters)
              .WithOne(e => e.EntityField)
              .HasForeignKey(e => e.EntityFieldId);

            builder
              .HasMany(e => e.EntityActionDynamicFunctionResults)
              .WithOne(e => e.EntityField)
              .HasForeignKey(e => e.EntityFieldId);
            

            //builder
            //   .HasMany(e => e.EntityActionFields)
            //   .WithOne(e => e.EntityField)
            //   .HasForeignKey(e => e.EntityFieldId);

            builder
               .HasMany(e => e.EntityFieldActionFields)
               .WithOne(e => e.EntityField)
               .HasForeignKey(e => e.EntityFieldId);

            builder
               .HasMany(e => e.HistoricalCallPathResults)
               .WithOne(e => e.EntityField)
               .HasForeignKey(e => e.EntityFieldId);
            
        }
    }
}
