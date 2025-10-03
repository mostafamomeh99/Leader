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

    public class EntityFieldActionGroupTriggerTypeConfig : IEntityTypeConfiguration<EntityFieldActionGroupTriggerType>
    {
        public void Configure(EntityTypeBuilder<EntityFieldActionGroupTriggerType> builder)
        {
            builder.ToTable(nameof(EntityFieldActionGroupTriggerType), EntitySchema.Entity).HasKey(x => new { x.EntityFieldActionGroupId, x.TriggerTypeId });



           




        }
    }
}
