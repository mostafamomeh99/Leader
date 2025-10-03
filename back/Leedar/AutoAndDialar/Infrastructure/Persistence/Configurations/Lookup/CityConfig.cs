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

    public class CityConfig : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable(nameof(City), EntitySchema.Lookup).HasKey(x => x.Id);


            builder
             .HasMany(e => e.PersonalInfos)
             .WithOne(e => e.City)
            
             .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
