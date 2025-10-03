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

    public class ConditionTypeConfig : IEntityTypeConfiguration<ConditionType>
    {
        public void Configure(EntityTypeBuilder<ConditionType> builder)
        {
            builder.ToTable(nameof(ConditionType), EntitySchema.Lookup).HasKey(x => x.Id);

            builder
               .HasMany(e => e.EntityActionConditions)
               .WithOne(e => e.ConditionType)
               .HasForeignKey(e => e.ConditionTypeId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasMany(e => e.EntityFieldActionConditions)
               .WithOne(e => e.ConditionType)
               .HasForeignKey(e => e.ConditionTypeId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasMany(e => e.EntityFieldConditions)
               .WithOne(e => e.ConditionType)
               .HasForeignKey(e => e.ConditionTypeId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasMany(e => e.EntityFieldOptionConditions)
               .WithOne(e => e.ConditionType)
               .HasForeignKey(e => e.ConditionTypeId)
               .OnDelete(DeleteBehavior.Cascade);





            builder.HasData(
            new ConditionType
            {
                Id = Shared.Struct.ConditionType.Contain,
                NameAr = "يحتوي",
                NameEn = "Contain",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 1,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
             new ConditionType
             {
                 Id = Shared.Struct.ConditionType.Equal,
                 NameAr = "يساوي",
                 NameEn = "Equal",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
             new ConditionType
             {
                 Id = Shared.Struct.ConditionType.In,
                 NameAr = "ضمن",
                 NameEn = "In",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
             new ConditionType
             {
                 Id = Shared.Struct.ConditionType.LessThan,
                 NameAr = "أقل من",
                 NameEn = "Less Than",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
             new ConditionType
             {
                 Id = Shared.Struct.ConditionType.LessThanOrEqual,
                 NameAr = "أقل من أو يساوي",
                 NameEn = "Less Than Or Equal",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
             new ConditionType
             {
                 Id = Shared.Struct.ConditionType.MoreThan,
                 NameAr = "أكبر من",
                 NameEn = "MoreThan",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
             new ConditionType
             {
                 Id = Shared.Struct.ConditionType.MoreThanOrEqual,
                 NameAr = "أكبر من أو يساوي",
                 NameEn = "More Than Or Equal",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
             new ConditionType
             {
                 Id = Shared.Struct.ConditionType.NotEqual,
                 NameAr = "لا يساوي",
                 NameEn = "Not Equal",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
              new ConditionType
              {
                  Id = Shared.Struct.ConditionType.NotNull,
                  NameAr = "غير فارغ",
                  NameEn = "Not Null",
                  IsStatic = true,
                  StateCode = 1,
                  ViewOrder = 1,
                  CreatedByUserId = Shared.Struct.StaticUser.System,
                  CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
              },
              new ConditionType
              {
                  Id = Shared.Struct.ConditionType.Null,
                  NameAr = "فارغ",
                  NameEn = "Null",
                  IsStatic = true,
                  StateCode = 1,
                  ViewOrder = 1,
                  CreatedByUserId = Shared.Struct.StaticUser.System,
                  CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
              }
        );

        }
    }
}
