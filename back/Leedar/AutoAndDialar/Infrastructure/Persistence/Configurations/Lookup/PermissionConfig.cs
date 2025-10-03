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

    public class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.ToTable(nameof(Permission), EntitySchema.Lookup).HasKey(x => x.Id);

            builder
               .HasMany(e => e.RolePermissions)
               .WithOne(e => e.Permission)
               .HasForeignKey(e => e.PermissionId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
              .HasMany(e => e.UserPermissions)
              .WithOne(e => e.Permission)
              .HasForeignKey(e => e.PermissionId)
              .OnDelete(DeleteBehavior.Cascade);



        }
    }
}
