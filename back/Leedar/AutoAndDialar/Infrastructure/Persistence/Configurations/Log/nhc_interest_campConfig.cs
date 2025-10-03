using Domain.Entities.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Log
{
    public class nhc_interest_campConfig : IEntityTypeConfiguration<nhc_interest_camp>
    {
        public void Configure(EntityTypeBuilder<nhc_interest_camp> builder)
        {
            builder.ToTable(nameof(nhc_interest_camp), EntitySchema.Log).HasKey(x => x.IdGu);

        }
    }
}
