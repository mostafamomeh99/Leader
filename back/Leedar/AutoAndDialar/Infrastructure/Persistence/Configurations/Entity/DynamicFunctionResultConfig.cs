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
    public class DynamicFunctionResultConfig : IEntityTypeConfiguration<DynamicFunctionResult>
    {
        public void Configure(EntityTypeBuilder<DynamicFunctionResult> builder)
        {
            builder.ToTable(nameof(DynamicFunctionResult), EntitySchema.Entity).HasKey(x => x.Id);

            builder
           .HasMany(e => e.EntityFieldActionDynamicFunctionResults)
           .WithOne(e => e.DynamicFunctionResult)
           .HasForeignKey(e => e.DynamicFunctionResultId);


            builder
           .HasMany(e => e.EntityActionDynamicFunctionResults)
           .WithOne(e => e.DynamicFunctionResult)
           .HasForeignKey(e => e.DynamicFunctionResultId);
        }
    }
}
