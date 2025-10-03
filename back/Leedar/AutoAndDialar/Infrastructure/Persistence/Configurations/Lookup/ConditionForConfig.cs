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

    public class ConditionForConfig : IEntityTypeConfiguration<ConditionFor>
    {
        public void Configure(EntityTypeBuilder<ConditionFor> builder)
        {
            builder.ToTable(nameof(ConditionFor), EntitySchema.Lookup).HasKey(x => x.Id);

            builder
               .HasMany(e => e.EntityFieldConditionGroups)
               .WithOne(e => e.ConditionFor)
               .HasForeignKey(e => e.ConditionForId)
               .OnDelete(DeleteBehavior.Cascade);

            builder
               .HasMany(e => e.EntityFieldOptionConditionGroups)
               .WithOne(e => e.ConditionFor)
               .HasForeignKey(e => e.ConditionForId)
               .OnDelete(DeleteBehavior.Cascade);


            builder.HasData(
            new ConditionFor
            {
                Id = Shared.Struct.ConditionFor.Disabled,
                NameAr = "تعطيل",
                NameEn = "Disabel",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 1,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
             new ConditionFor
             {
                 Id = Shared.Struct.ConditionFor.ReadOnly,
                 NameAr = "للقراءة فقط",
                 NameEn = "ReadOnly",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
             new ConditionFor
             {
                 Id = Shared.Struct.ConditionFor.Required,
                 NameAr = "إجباري",
                 NameEn = "Required",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
             new ConditionFor
             {
                 Id = Shared.Struct.ConditionFor.Selected,
                 NameAr = "اختيار",
                 NameEn = "Select",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             },
             new ConditionFor
             {
                 Id = Shared.Struct.ConditionFor.Show,
                 NameAr = "عرض",
                 NameEn = "Show",
                 IsStatic = true,
                 StateCode = 1,
                 ViewOrder = 1,
                 CreatedByUserId = Shared.Struct.StaticUser.System,
                 CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
             }
             ,
             new ConditionFor
             {
                 Id = Shared.Struct.ConditionFor.Execute,
                 NameAr = "تنفيذ",
                 NameEn = "Execute",
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
