using Domain.Entities.Application;
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
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User), EntitySchema.Identity).HasKey(x => x.Id);

            builder.HasData(
              new User
              {
                  Id = Shared.Struct.StaticUser.System,
                  CreatedByUserId = Shared.Struct.StaticUser.System,
                
                  Email = "System@System",
                  EmployeeNumber = "1",
                  IsLoggedIn = false,
                  NormalizedUserName = "System",
                  PersonalInfoId = Shared.Struct.StaticUser.System,
                  
                  UserName = "System",
                  StateCode = 1,
                  CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                  IsStatic = true,
                  IsHasSpecialPermissions = false,
                  ConcurrencyStamp = "76c52b9b-21df-4f45-8220-d2755f39860c"
              }
              //new User
              //{
              //    Id = Shared.Struct.StaticUser.Contact,
              //    PersonalInfoId = Shared.Struct.StaticUser.Contact,
              //    CreatedByUserId = Shared.Struct.StaticUser.System,
                 
              //    Email = "Contact@Contact",
              //    IsLoggedIn = false,
              //    NormalizedUserName = "Contact",
              //    UserName = "Contact",
              //    StateCode = 1,
              //    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
              //    IsStatic = true,
              //    IsHasSpecialPermissions = false,
              //    ConcurrencyStamp = "76c52b9b-21df-4f45-8220-d2755f39860c"
              //}
              );

            builder
            .HasOne(e => e.PersonalInfo)
            .WithOne(e => e.User)
            .HasForeignKey<User>(e => e.Id);

           



            builder
            .HasMany(e => e.UserPermissions)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);

            





            builder
               .HasMany(e => e.UserSettings)
               .WithOne(e => e.User)
               .HasForeignKey(e => e.UserId)
               .OnDelete(DeleteBehavior.Cascade);



            builder
            .HasMany(x => x.Roles)
            .WithOne()
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();


            builder
           .HasMany(e => e.UserRealTimes)
           .WithOne(e => e.User)
           .HasForeignKey(e => e.UserId)
           .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.CreatedByUser)
    .WithMany()
    .HasForeignKey(u => u.CreatedByUserId)
    .OnDelete(DeleteBehavior.Restrict);

        }
    }
}