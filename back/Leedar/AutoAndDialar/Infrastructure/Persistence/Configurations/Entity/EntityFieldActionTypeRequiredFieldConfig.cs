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

    public class EntityFieldActionTypeRequiredFieldConfig : IEntityTypeConfiguration<EntityFieldActionTypeRequiredField>
    {
        public void Configure(EntityTypeBuilder<EntityFieldActionTypeRequiredField> builder)
        {
            builder.ToTable(nameof(EntityFieldActionTypeRequiredField), EntitySchema.Entity).HasKey(x => x.Id);

            //builder
            //   .HasMany(e => e.EntityActionOperations)
            //   .WithOne(e => e.EntityAction)
            //   .HasForeignKey(e => e.EntityActionId);

            builder
               .HasMany(e => e.EntityFieldActionFields)
               .WithOne(e => e.EntityFieldActionTypeRequiredField)
               .HasForeignKey(e => e.EntityFieldActionTypeRequiredFieldId);



        }
    }
}
