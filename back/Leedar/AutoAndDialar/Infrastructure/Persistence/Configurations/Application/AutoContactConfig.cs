using Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Application
{
    public class AutoContactConfig : IEntityTypeConfiguration<AutoContact>
    {
        public void Configure(EntityTypeBuilder<AutoContact> builder)
        {
            builder.ToTable(nameof(Contact), EntitySchema.Application).HasKey(x => x.Id);


           
            builder.Property(t => t.Description).HasMaxLength(2000);
           
        }
    }
}
