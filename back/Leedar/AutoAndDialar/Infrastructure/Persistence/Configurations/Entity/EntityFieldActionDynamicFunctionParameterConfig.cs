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
    public class EntityFieldActionDynamicFunctionParameterConfig : IEntityTypeConfiguration<EntityFieldActionDynamicFunctionParameter>
    {
        public void Configure(EntityTypeBuilder<EntityFieldActionDynamicFunctionParameter> builder)
        {
            builder.ToTable(nameof(EntityFieldActionDynamicFunctionParameter), EntitySchema.Entity).HasKey(x => x.Id);
        }
    }
}
