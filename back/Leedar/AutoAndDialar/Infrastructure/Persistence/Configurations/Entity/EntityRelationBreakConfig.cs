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

    public class EntityRelationBreakConfig : IEntityTypeConfiguration<EntityRelationBreak>
    {
        public void Configure(EntityTypeBuilder<EntityRelationBreak> builder)
        {
            builder.ToTable(nameof(EntityRelationBreak), EntitySchema.Entity).HasKey(x => new { x.EntityId, x.Entity2Id });


        }
    }
}
