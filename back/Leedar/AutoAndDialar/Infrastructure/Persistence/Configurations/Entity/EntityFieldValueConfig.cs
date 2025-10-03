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

    public class EntityFieldValueConfig : IEntityTypeConfiguration<EntityFieldValue>
    {
        public void Configure(EntityTypeBuilder<EntityFieldValue> builder)
        {
            builder.ToTable(nameof(EntityFieldValue), EntitySchema.Entity).HasKey(x => x.Id);



           



        }
    }
}
