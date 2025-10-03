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

    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category), EntitySchema.Lookup).HasKey(x => x.Id);

            builder
               .HasMany(e => e.CallCategorys)
               .WithOne(e => e.CallCategoryMain)
               .HasForeignKey(e => e.CallCategoryMainId)
               .OnDelete(DeleteBehavior.NoAction);




           

            builder
               .HasMany(e => e.ScheduledCalls)
               .WithOne(e => e.Category)
               .HasForeignKey(e => e.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);
            builder
               .HasMany(e => e.HistoricalCalls)
               .WithOne(e => e.Category)
               .HasForeignKey(e => e.CategoryId)
               .OnDelete(DeleteBehavior.NoAction);



            builder
             .HasMany(e => e.Pim_contact_attempts_historys)
             .WithOne(e => e.Category)
             .HasForeignKey(e => e.CategoryId);


        }
    }
}
