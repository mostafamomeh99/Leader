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

    public class TriggerTypeConfig : IEntityTypeConfiguration<TriggerType>
    {
        public void Configure(EntityTypeBuilder<TriggerType> builder)
        {
            builder.ToTable(nameof(TriggerType), EntitySchema.Lookup).HasKey(x => x.Id);



            builder
              .HasMany(e => e.EntityActionGroupTriggerTypes)
              .WithOne(e => e.TriggerType)
              .HasForeignKey(e => e.TriggerTypeId);


            builder
              .HasMany(e => e.EntityFieldActionGroupTriggerTypes)
              .WithOne(e => e.TriggerType)
              .HasForeignKey(e => e.TriggerTypeId);

            builder.HasData(new TriggerType
            {
                Id = Shared.Struct.TriggerType.OnCreate,
                NameAr = "عند الإنشاء",
                NameEn = "On Create",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 1,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
new TriggerType
{
    Id = Shared.Struct.TriggerType.OnUpdate,
    NameAr = "عند التحديث",
    NameEn = "On Update",
    IsStatic = true,
    StateCode = 1,
    ViewOrder = 1,
    CreatedByUserId = Shared.Struct.StaticUser.System,
    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
},
new TriggerType
{
    Id = Shared.Struct.TriggerType.OnDelete,
    NameAr = "عند الحذف",
    NameEn = "On Delete",
    IsStatic = true,
    StateCode = 1,
    ViewOrder = 1,
    CreatedByUserId = Shared.Struct.StaticUser.System,
    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
},
new TriggerType
{
    Id = Shared.Struct.TriggerType.OnView,
    NameAr = "عند الاستعراض",
    NameEn = "On View",
    IsStatic = true,
    StateCode = 1,
    ViewOrder = 1,
    CreatedByUserId = Shared.Struct.StaticUser.System,
    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
},
new TriggerType
{
    Id = Shared.Struct.TriggerType.OnActivate,
    NameAr = "عند التفعيل",
    NameEn = "On Activate",
    IsStatic = true,
    StateCode = 1,
    ViewOrder = 1,
    CreatedByUserId = Shared.Struct.StaticUser.System,
    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
}
,
new TriggerType
{
    Id = Shared.Struct.TriggerType.DeActivate,
    NameAr = "عند التعطيل",
    NameEn = "On DeActivate",
    IsStatic = true,
    StateCode = 1,
    ViewOrder = 1,
    CreatedByUserId = Shared.Struct.StaticUser.System,
    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
}
,
new TriggerType
{
    Id = Shared.Struct.TriggerType.OnClick,
    NameAr = "عند الضغط على",
    NameEn = "On Click",
    IsStatic = true,
    StateCode = 1,
    ViewOrder = 1,
    CreatedByUserId = Shared.Struct.StaticUser.System,
    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
}
,
new TriggerType
{
    Id = Shared.Struct.TriggerType.OnSubmit,
    NameAr = "عند الإرسال",
    NameEn = "On Submit",
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
