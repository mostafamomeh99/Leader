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

    public class EntityActionGroupTriggerTypeConfig : IEntityTypeConfiguration<EntityActionGroupTriggerType>
    {
        public void Configure(EntityTypeBuilder<EntityActionGroupTriggerType> builder)
        {
            builder.ToTable(nameof(EntityActionGroupTriggerType), EntitySchema.Entity).HasKey(x => new { x.EntityActionGroupId, x.TriggerTypeId });







        }
    }
}
