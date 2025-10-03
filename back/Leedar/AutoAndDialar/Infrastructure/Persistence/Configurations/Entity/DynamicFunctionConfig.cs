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
    public class DynamicFunctionConfig : IEntityTypeConfiguration<DynamicFunction>
    {
        public void Configure(EntityTypeBuilder<DynamicFunction> builder)
        {
            builder.ToTable(nameof(DynamicFunction), EntitySchema.Entity).HasKey(x => x.Id);

            builder
               .HasMany(e => e.DynamicFunctionParameters)
               .WithOne(e => e.DynamicFunction)
               .HasForeignKey(e => e.DynamicFunctionId);

            builder
               .HasMany(e => e.DynamicFunctionResults)
               .WithOne(e => e.DynamicFunction)
               .HasForeignKey(e => e.DynamicFunctionId);

            //builder
            //   .HasMany(e => e.EntityFieldActionDynamicFunctions)
            //   .WithOne(e => e.DynamicFunction)
            //   .HasForeignKey(e => e.DynamicFunctionId);


            builder
               .HasMany(e => e.EntityFieldActions)
               .WithOne(e => e.DynamicFunction)
               .HasForeignKey(e => e.DynamicFunctionId);

            builder
               .HasMany(e => e.EntityActions)
               .WithOne(e => e.DynamicFunction)
               .HasForeignKey(e => e.DynamicFunctionId);
            
        }
    }
}
