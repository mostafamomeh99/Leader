namespace Infrastructure.Persistence.Extensions
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Domain.Entities.Identity;
    using Shared.Constants;
    using System;

    public static class IdentityModelBuilderExtension
    {
        public static void BuildIdentityTable(this ModelBuilder builder)
        {
            builder.Entity<User>().ToTable("User", EntitySchema.Identity);
            builder.Entity<Role>().ToTable("Role", EntitySchema.Identity);
            //builder.Entity<UserGroups>().ToTable("UserGroups", EntitySchema.IdentitySchema);
            //builder.Entity<RefreshToken>().ToTable("RefreshToken", EntitySchema.IdentitySchema);

            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles", EntitySchema.Identity);
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims", EntitySchema.Identity);
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins", EntitySchema.Identity);
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims", EntitySchema.Identity);
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens", EntitySchema.Identity);
        }
    }
}
