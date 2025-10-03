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

    public class FieldTypeConfig : IEntityTypeConfiguration<FieldType>
    {
        public void Configure(EntityTypeBuilder<FieldType> builder)
        {
            builder.ToTable(nameof(FieldType), EntitySchema.Lookup).HasKey(x => x.Id);

            builder
               .HasMany(e => e.EntityFields)
               .WithOne(e => e.FieldType)
               .HasForeignKey(e => e.FieldTypeId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
             .HasMany(e => e.EntityActionTypeRequiredFields)
             .WithOne(e => e.FieldType)
             .HasForeignKey(e => e.FieldTypeId);

            builder
               .HasMany(e => e.EntityFieldActionTypeRequiredFields)
               .WithOne(e => e.FieldType)
               .HasForeignKey(e => e.FieldTypeId);


            builder.HasData(
                new FieldType
                {
                    Id = Shared.Struct.FieldType.Button,
                    NameAr = "زر",
                    NameEn = "Button",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.CheckBox,
                    NameAr = "خيار اختياري (CheckBox)",
                    NameEn = "CheckBox",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.CheckBoxGroup,
                    NameAr = "خيارات متعددة (CheckBox)",
                    NameEn = "CheckBox Group",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.Date,
                    NameAr = "تاريخ",
                    NameEn = "Date",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.DateTime,
                    NameAr = "تاريخ ووقت",
                    NameEn = "DateTime",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.Label,
                    NameAr = "عنوان",
                    NameEn = "Label",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.MultibelSelect,
                    NameAr = "خيارات متعددة (Select)",
                    NameEn = "MultibelSelect",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.Number,
                    NameAr = "رقم",
                    NameEn = "Number",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.OneSelect,
                    NameAr = "اختيار واحد (Select)",
                    NameEn = "One Select",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.RadioButton,
                    NameAr = "اختيار واحد (Radio)",
                    NameEn = "Radio Button",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.Text,
                    NameAr = "نص",
                    NameEn = "Text",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.TextArea,
                    NameAr = "نص كبير",
                    NameEn = "Text Area",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.Time,
                    NameAr = "وقت",
                    NameEn = "Time",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.ViewList,
                    NameAr = "قائمة نصية",
                    NameEn = "View List",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                },
                new FieldType
                {
                    Id = Shared.Struct.FieldType.File,
                    NameAr = "ملف",
                    NameEn = "File",
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
