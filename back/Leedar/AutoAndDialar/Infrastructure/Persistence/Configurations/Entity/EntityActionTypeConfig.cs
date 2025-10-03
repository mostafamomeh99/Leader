using Domain.Entities.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Configurations.Entity
{

    public class EntityActionTypeConfig : IEntityTypeConfiguration<EntityActionType>
    {
        public void Configure(EntityTypeBuilder<EntityActionType> builder)
        {
            builder.ToTable(nameof(EntityActionType), EntitySchema.Entity).HasKey(x => x.Id);



            builder
               .HasMany(e => e.EntityActions)
               .WithOne(e => e.EntityActionType)
               .HasForeignKey(e => e.EntityActionTypeId);


            builder
             .HasMany(e => e.EntityActionTypeRequiredFields)
             .WithOne(e => e.EntityActionType)
             .HasForeignKey(e => e.EntityActionTypeId);


            builder.HasData(
                new EntityActionType
                {
                    Id = Shared.Struct.EntityActionType.ScheduleNewCall,
                    NameAr = "جدولة مكالمة جديدة",
                    NameEn = "Schedule New Call",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                    EntityTypeId = Shared.Struct.Entities.Lookup.CategoryPath,
                });

            builder.HasData(
                new EntityActionType
                {
                    Id = Shared.Struct.EntityActionType.SaveCallInSuccessStatus,
                    NameAr = "حفظ نتيجة المكالمة بحالة ناجحة",
                    NameEn = "Save Call In Success Status",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                    EntityTypeId = Shared.Struct.Entities.Lookup.CategoryPath,
                });

            builder.HasData(
                new EntityActionType
                {
                    Id = Shared.Struct.EntityActionType.SaveCallInNotSuccessStatus,
                    NameAr = "حفظ نتيجة المكالمة بحالة غير ناجحة",
                    NameEn = "Save Call In Not Success Status",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                    EntityTypeId = Shared.Struct.Entities.Lookup.CategoryPath,
                });

            builder.HasData(
                new EntityActionType
                {
                    Id = Shared.Struct.EntityActionType.SaveCallInRecallStatus,
                    NameAr = "حفظ نتيجة المكالمة بحالة إعادة اتصال",
                    NameEn = "Save Call In Recall Status",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                    EntityTypeId = Shared.Struct.Entities.Lookup.CategoryPath,
                });

            builder.HasData(
                new EntityActionType
                {
                    Id = Shared.Struct.EntityActionType.NotifyOnBillCreated,
                    NameAr = "إشعار بإنشاء فاتورة",
                    NameEn = "Notify On Bill Created",
                    IsStatic = true,
                    StateCode = 1,
                    ViewOrder = 1,
                    CreatedByUserId = Shared.Struct.StaticUser.System,
                    CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
                    EntityTypeId = Shared.Struct.Entities.Lookup.CategoryPath,
                });
            
        }
    }
}
