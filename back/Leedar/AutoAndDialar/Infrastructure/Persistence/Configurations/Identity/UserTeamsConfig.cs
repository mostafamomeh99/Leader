using Domain.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Identity
{
    public class UserTeamsConfig : IEntityTypeConfiguration<UserTeams>
    {
        public void Configure(EntityTypeBuilder<UserTeams> builder)
        {
            builder.ToTable(nameof(UserTeams), EntitySchema.Identity).HasKey(x => new { x.UserId, x.TeamId});


        }
    }
}