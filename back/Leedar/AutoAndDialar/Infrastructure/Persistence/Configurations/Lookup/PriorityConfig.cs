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

    public class PriorityConfig : IEntityTypeConfiguration<Priority>
    {
        public void Configure(EntityTypeBuilder<Priority> builder)
        {
            builder.ToTable(nameof(Priority), EntitySchema.Lookup).HasKey(x => x.Id);
            builder
                    .HasMany(e => e.Campaigns)
                    .WithOne(e => e.Priority)
                    .HasForeignKey(e => e.PriorityId)
                    .OnDelete(DeleteBehavior.SetNull);

            builder
                .HasMany(e => e.Categorys)
                .WithOne(e => e.Priority)
                .HasForeignKey(e => e.PriorityId)
                .OnDelete(DeleteBehavior.SetNull);
            

            builder.HasData(
                 new Priority
                 {
                     Id = Shared.Struct.Priority.VerySpecial,
                     NameAr = "استثنائي جداً",
                     NameEn = "Very Special",
                     IsStatic = true,
                     StateCode = 1,
                     ViewOrder = 1,
                     Number = 1,
                     CreatedByUserId = Shared.Struct.StaticUser.System,
                     CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                 },
            new Priority
            {
                Id = Shared.Struct.Priority.Special,
                NameAr = "استثنائي",
                NameEn = "Special",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 2,
                Number = 2,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
             new Priority
             {
                 Id = Shared.Struct.Priority.VeryImportant,
                 NameAr = "مهم جداً",
                 NameEn = "Important",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 3,
                 Number = 3,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
            new Priority
            {
                Id = Shared.Struct.Priority.Important,
                NameAr = "مهم",
                NameEn = "Important",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 4,
                Number = 4,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
            new Priority
            {
                Id = Shared.Struct.Priority.Normal,
                NameAr = "عادي",
                NameEn = "Normal",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 5,
                Number = 5,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
            new Priority
            {
                Id = Shared.Struct.Priority.Low,
                NameAr = "غير مهم",
                NameEn = "Low",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 6,
                Number = 6,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
            new Priority
            {
                Id = Shared.Struct.Priority.VeryLow,
                NameAr = "غير مهم أبداً",
                NameEn = "Very Low",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 7,
                Number = 7,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            });

        }
    }
}
