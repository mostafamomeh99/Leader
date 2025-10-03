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

    public class AppSettingConfig : IEntityTypeConfiguration<AppSetting>
    {
        public void Configure(EntityTypeBuilder<AppSetting> builder)
        {
            builder.ToTable(nameof(AppSetting), EntitySchema.Lookup).HasKey(x => x.Id);


           



        }
    }
}
