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

    public class TeamConfig : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable(nameof(Team), EntitySchema.Lookup).HasKey(x => x.Id);

            builder
               .HasMany(e => e.UserTeams)
               .WithOne(e => e.Team)
               .HasForeignKey(e => e.TeamId)
               .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
