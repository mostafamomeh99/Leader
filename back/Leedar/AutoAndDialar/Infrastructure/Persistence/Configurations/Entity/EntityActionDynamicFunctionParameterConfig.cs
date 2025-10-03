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
    public class EntityActionDynamicFunctionParameterConfig : IEntityTypeConfiguration<EntityActionDynamicFunctionParameter>
    {
        public void Configure(EntityTypeBuilder<EntityActionDynamicFunctionParameter> builder)
        {
            builder.ToTable(nameof(EntityActionDynamicFunctionParameter), EntitySchema.Entity).HasKey(x => x.Id);
        }
    }
}
