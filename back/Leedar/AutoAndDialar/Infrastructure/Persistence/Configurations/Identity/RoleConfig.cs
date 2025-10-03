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
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(nameof(Role), EntitySchema.Identity).HasKey(x => x.Id);

            builder
            .HasMany(e => e.RolePermissions)
            .WithOne(e => e.Role)
            .HasForeignKey(e => e.RoleId);

            builder
            .HasMany(x => x.UserRole)
            .WithOne()
            .HasForeignKey(ur => ur.RoleId)
            .IsRequired();
            builder.HasData(
             new Role
             {
                 Id = Shared.Struct.Roles.System,
                 Name = "System",
                 NormalizedName = "system",
                 NameAr = "النظام",
                 IsStatic = true,
                 IsDefualt = false,
                 StateCode = 0,
                 ConcurrencyStamp = "1e0a9742-eedd-4389-a1b3-5c9fd3e6ca61",
                 //RoleTypeId=Shared.Struct.RoleType.Admin
             },
             new Role
             {
                 Id = Shared.Struct.Roles.SuperAdmin,
                 Name = "SuperAdmin",
                 NormalizedName = "superadmin",
                 NameAr = "مسؤول النظام",
                 IsStatic = true,
                 IsDefualt = false,
                 StateCode = 0,
                 ConcurrencyStamp = "4f421dc4-9f03-4d54-898a-caf3ad286a2d",
               //  RoleTypeId = Shared.Struct.RoleType.Admin
             },
             new Role
             {
                 Id = Shared.Struct.Roles.Admin,
                 Name = "Admin",
                 NormalizedName = "admin",
                 NameAr = "المسؤول",
                 IsStatic = true,
                 IsDefualt = false,
                 StateCode = 1,
                 ConcurrencyStamp = "6c4191c2-5d95-40d6-bccc-006b7faf8a16",
                // RoleTypeId = Shared.Struct.RoleType.Admin
             },
             new Role
             {
                 Id = Shared.Struct.Roles.Supervisor,
                 Name = "Supervisor",
                 NormalizedName = "supervisor",
                 NameAr = "المشرف",
                 IsStatic = true,
                 IsDefualt = false,
                 StateCode = 1,
                 ConcurrencyStamp = "e3f6e940-5380-41eb-98be-601439d614e9",
                // RoleTypeId = Shared.Struct.RoleType.Admin
             },
             new Role
             {
                 Id = Shared.Struct.Roles.Leader,
                 Name = "Leader",
                 NormalizedName = "leader",
                 NameAr = "قائد الفريق",
                 IsStatic = true,
                 IsDefualt = false,
                 StateCode = 1,
                 ConcurrencyStamp = "f9cb65bf-3071-42ff-a952-a166e99077e3",
                 //RoleTypeId = Shared.Struct.RoleType.Admin
             },
             new Role
             {
                 Id = Shared.Struct.Roles.Reporter,
                 Name = "Reporter",
                 NormalizedName = "reporter",
                 NameAr = "منظم التقارير",
                 IsStatic = true,
                 IsDefualt = false,
                 StateCode = 0,
                 ConcurrencyStamp = "10a464f7-65af-4423-9325-49482bf51fed",
                 //RoleTypeId = Shared.Struct.RoleType.User
             },
             new Role
             {
                 Id = Shared.Struct.Roles.Employee,
                 Name = "Employee",
                 NormalizedName = "employee",
                 NameAr = "موظف",
                 IsStatic = true,
                 IsDefualt = true,
                 StateCode = 1,
                 ConcurrencyStamp = "2bb13d4b-8187-4420-998a-335182d1a71e",
                // RoleTypeId = Shared.Struct.RoleType.User
             }
         
             );
        }
    }
}