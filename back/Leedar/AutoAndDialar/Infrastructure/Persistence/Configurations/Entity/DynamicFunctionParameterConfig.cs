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
    public class DynamicFunctionParameterConfig : IEntityTypeConfiguration<DynamicFunctionParameter>
    {
        public void Configure(EntityTypeBuilder<DynamicFunctionParameter> builder)
        {
            builder.ToTable(nameof(DynamicFunctionParameter), EntitySchema.Entity).HasKey(x => x.Id);

            builder
               .HasMany(e => e.EntityFieldActionDynamicFunctionParameters)
               .WithOne(e => e.DynamicFunctionParameter)
               .HasForeignKey(e => e.DynamicFunctionParameterId);


            builder
               .HasMany(e => e.EntityActionDynamicFunctionParameters)
               .WithOne(e => e.DynamicFunctionParameter)
               .HasForeignKey(e => e.DynamicFunctionParameterId);
            
        }
    }
}
