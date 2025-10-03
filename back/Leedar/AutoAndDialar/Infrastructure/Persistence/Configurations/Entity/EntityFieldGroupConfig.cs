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

    public class EntityFieldGroupConfig : IEntityTypeConfiguration<EntityFieldGroup>
    {
        public void Configure(EntityTypeBuilder<EntityFieldGroup> builder)
        {
            builder.ToTable(nameof(EntityFieldGroup), EntitySchema.Entity).HasKey(x => x.Id);



            builder
               .HasMany(e => e.EntityFields)
               .WithOne(e => e.EntityFieldGroup)
               .HasForeignKey(e => e.EntityFieldGroupId);




        }
    }
}
