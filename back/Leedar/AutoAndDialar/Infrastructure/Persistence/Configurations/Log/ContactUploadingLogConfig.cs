using Domain.Entities.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Log
{

    public class ContactUploadingLogConfig : IEntityTypeConfiguration<ContactUploadingLog>
    {
        public void Configure(EntityTypeBuilder<ContactUploadingLog> builder)
        {
            builder.ToTable(nameof(ContactUploadingLog), EntitySchema.Log).HasKey(x => x.Id);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.DescriptionOthers).HasMaxLength(2000);
            builder.Property(x => x.FileName).HasMaxLength(2000);
            
        }

    }
}
