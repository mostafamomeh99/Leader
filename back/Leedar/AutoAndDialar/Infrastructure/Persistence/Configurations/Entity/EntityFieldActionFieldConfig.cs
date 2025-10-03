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

    public class EntityFieldActionFieldConfig : IEntityTypeConfiguration<EntityFieldActionField>
    {
        public void Configure(EntityTypeBuilder<EntityFieldActionField> builder)
        {
            builder.ToTable(nameof(EntityFieldActionField), EntitySchema.Entity).HasKey(x => x.Id);

            //builder
            //   .HasMany(e => e.EntityActionOperations)
            //   .WithOne(e => e.EntityAction)
            //   .HasForeignKey(e => e.EntityActionId);
               



        }
    }
}
