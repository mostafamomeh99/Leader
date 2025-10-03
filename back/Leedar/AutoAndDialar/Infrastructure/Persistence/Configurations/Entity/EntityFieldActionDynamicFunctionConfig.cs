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
    public class EntityFieldActionDynamicFunctionConfig : IEntityTypeConfiguration<EntityFieldActionDynamicFunction>
    {
        public void Configure(EntityTypeBuilder<EntityFieldActionDynamicFunction> builder)
        {
            builder.ToTable(nameof(EntityFieldActionDynamicFunction), EntitySchema.Entity).HasKey(x => x.Id);

            //builder
            //.HasMany(e => e.EntityFieldActionDynamicFunctionParameters)
            //.WithOne(e => e.EntityFieldActionDynamicFunction)
            //.HasForeignKey(e => e.EntityFieldActionDynamicFunctionId);

            //builder
            //.HasMany(e => e.EntityFieldActionDynamicFunctionResults)
            //.WithOne(e => e.EntityFieldActionDynamicFunction)
            //.HasForeignKey(e => e.EntityFieldActionDynamicFunctionId);

        }
    }
}
