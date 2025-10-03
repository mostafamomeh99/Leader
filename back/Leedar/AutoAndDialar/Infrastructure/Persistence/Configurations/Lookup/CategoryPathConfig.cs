using Domain.Entities.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Lookup
{

    public class CategoryPathConfig : IEntityTypeConfiguration<CategoryPath>
    {
        public void Configure(EntityTypeBuilder<CategoryPath> builder)
        {
            builder.ToTable(nameof(CategoryPath), EntitySchema.Lookup).HasKey(x => x.Id);

            builder
               .HasMany(e => e.Categorys)
               .WithOne(e => e.CategoryPath)
               .HasForeignKey(e => e.CategoryPathId)
               .OnDelete(DeleteBehavior.Cascade);






        }
    }
}
