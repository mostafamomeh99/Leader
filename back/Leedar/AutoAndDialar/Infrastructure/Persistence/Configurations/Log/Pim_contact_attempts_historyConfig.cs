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
    public class Pim_contact_attempts_historyConfig : IEntityTypeConfiguration<Pim_contact_attempts_history>
    {
        public void Configure(EntityTypeBuilder<Pim_contact_attempts_history> builder)
        {
            builder.ToTable(nameof(Pim_contact_attempts_history), EntitySchema.Log).HasKey(x => x.Id);

        }
    }
}
