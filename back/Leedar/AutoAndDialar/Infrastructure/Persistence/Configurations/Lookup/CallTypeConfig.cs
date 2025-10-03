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

    public class CallTypeConfig : IEntityTypeConfiguration<CallType>
    {
        public void Configure(EntityTypeBuilder<CallType> builder)
        {
            builder.ToTable(nameof(CallType), EntitySchema.Lookup).HasKey(x => x.Id);

            builder
               .HasMany(e => e.ScheduledCalls)
               .WithOne(e => e.CallType)
               .HasForeignKey(e => e.CallTypeId)
               .OnDelete(DeleteBehavior.SetNull);

            builder
              .HasMany(e => e.HistoricalCalls)
              .WithOne(e => e.CallType)
              .HasForeignKey(e => e.CallTypeId)
              .OnDelete(DeleteBehavior.SetNull);

            builder
             .HasMany(e => e.Categorys)
             .WithOne(e => e.CallType)
             .HasForeignKey(e => e.CallTypeId)
             .OnDelete(DeleteBehavior.SetNull);
            

            builder.HasData(
            new CallType
            {
                Id = Shared.Struct.CallType.Normal,
                NameAr = "مكالمة متصل تنبؤي",
                NameEn = "Normal Call",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 1,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
            new CallType
            {
                Id = Shared.Struct.CallType.Auto,
                NameAr = "مكالمة تلقائي",
                NameEn = "Auto Call",
                IsStatic = true,
                StateCode = 1,
                ViewOrder = 1,
                CreatedByUserId = Shared.Struct.StaticUser.System,
                CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime,
            },
             new CallType
             {
                 Id = Shared.Struct.CallType.CollectingCallFollowup,
                 NameAr = "مكالمة تحصيل - متابعة",
                 NameEn = "Collecting Call Followup",
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
