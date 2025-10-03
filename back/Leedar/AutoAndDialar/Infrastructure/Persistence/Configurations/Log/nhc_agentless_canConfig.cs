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
    public class nhc_agentless_canConfig : IEntityTypeConfiguration<nhc_agentless_can>
    {
        public void Configure(EntityTypeBuilder<nhc_agentless_can> builder)
        {
            builder.ToTable(nameof(nhc_agentless_can), EntitySchema.Log).HasKey(x => x.IdGu);

        }
    }
}
