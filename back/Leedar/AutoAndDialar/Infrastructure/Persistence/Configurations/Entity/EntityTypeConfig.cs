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
    public class EntityTypeConfig : IEntityTypeConfiguration<EntityType>
    {
        public void Configure(EntityTypeBuilder<EntityType> builder)
        {
            builder.ToTable(nameof(EntityType), EntitySchema.Entity).HasKey(x => x.Id);


            #region Application
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.CallBill, NameAr = "فاتورة المكالمة", NameEn = "Call Bill", SchemaName = "Application", TabelName = "CallBill", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.CallQuality, NameAr = "تقييم المكالمة", NameEn = "Call Quality", SchemaName = "Application", TabelName = "CallQuality", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.CallQualityCriteria, NameAr = "معايير تقييم المكالمة", NameEn = "Call Quality Criteria", SchemaName = "Application", TabelName = "CallQualityCriteria", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.CallQualityCriteriaPart, NameAr = "أجزاء معايير تقييم المكالمات", NameEn = "Call Quality Criteria Part", SchemaName = "Application", TabelName = "CallQualityCriteriaPart", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.Contact, NameAr = "العملاء", NameEn = "Contacts", SchemaName = "Application", TabelName = "Contact", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.Contract, NameAr = "العقود", NameEn = "Contract", SchemaName = "Application", TabelName = "Contract", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.HistoricalCall, NameAr = "المكالمات التاريخية", NameEn = "Historical Call", SchemaName = "Application", TabelName = "HistoricalCall", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.HistoricalCallComment, NameAr = "التعليقات على المكالمات التاريخية", NameEn = "Historical Call Comment", SchemaName = "Application", TabelName = "HistoricalCallComment", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.Payment, NameAr = "المدفوعات", NameEn = "Payment", SchemaName = "Application", TabelName = "Payment", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.PersonalInfo, NameAr = "المعلومات الشخصية", NameEn = "Personal Info", SchemaName = "Application", TabelName = "PersonalInfo", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.ScheduledCall, NameAr = "المكالمات المجدولة", NameEn = "Scheduled Call", SchemaName = "Application", TabelName = "ScheduledCall", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.Setting, NameAr = "الإعدادات", NameEn = "Setting", SchemaName = "Application", TabelName = "Setting", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Application.SystemProgress, NameAr = "إجراءات النظام", NameEn = "System Progress", SchemaName = "Application", TabelName = "SystemProgress", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            #endregion

            #region Entity
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Entity.EntityType, NameAr = "الكيانات", NameEn = "Entity", SchemaName = "Entity", TabelName = "Entity", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Entity.DynamicFunction, NameAr = "الدوال الديناميكية", NameEn = "Dynamic Function", SchemaName = "Entity", TabelName = "DynamicFunction", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Entity.DynamicReport, NameAr = "التقارير الديناميكية", NameEn = "Dynamic Report", SchemaName = "Entity", TabelName = "DynamicReport", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Entity.EntityActionType, NameAr = "أنواع الأحداث على الكيانات", NameEn = "Entity Action Type", SchemaName = "Entity", TabelName = "EntityActionType", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Entity.EntityFieldActionType, NameAr = "أنواع الأحداث على حقول الكيانات", NameEn = "Entity Field Action Type", SchemaName = "Entity", TabelName = "EntityFieldActionType", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });

            #endregion

            #region Identity
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Identity.Role, NameAr = "الأدوار الوظيفية", NameEn = "Role", SchemaName = "Identity", TabelName = "Role", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Identity.RolePermission, NameAr = "صلاحيات الأدوار الوظيفية", NameEn = "Role Permission", SchemaName = "Identity", TabelName = "RolePermission", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Identity.User, NameAr = "المستخدمين", NameEn = "User", SchemaName = "Identity", TabelName = "User", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Identity.UserCategoryPath, NameAr = "مسارات التصنيف للمستخدمين", NameEn = "User Category Path", SchemaName = "Identity", TabelName = "UserCategoryPath", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Identity.UserPermission, NameAr = "صلاحيات المستخدمين", NameEn = "User Permission", SchemaName = "Identity", TabelName = "UserPermission", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Identity.UserSetting, NameAr = "إعدادات المستخدمين", NameEn = "User Setting", SchemaName = "Identity", TabelName = "UserSetting", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Identity.UserTeams, NameAr = "فرق المستخدمين", NameEn = "User Teams", SchemaName = "Identity", TabelName = "UserTeams", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            #endregion

            #region Log
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Log.ContactUploadingLog, NameAr = "سجلات تحميل المستفيدين", NameEn = "Contact Uploading Log", SchemaName = "Log", TabelName = "ContactUploadingLog", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Log.ContractHistory, NameAr = "سجلات تحديثات العقود", NameEn = "Contract History", SchemaName = "Log", TabelName = "ContractHistory", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Log.PersonalInfoLog, NameAr = "سجلات تحديثات المعلومات الشخصية", NameEn = "Personal Info Log", SchemaName = "Log", TabelName = "PersonalInfoLog", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Log.SMSSentLog, NameAr = "سجلات إرسال الرسائل النصية", NameEn = "SMS Sent Log", SchemaName = "Log", TabelName = "SMSSentLog", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            #endregion

            #region Lookup
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.CallStatus, NameAr = "حالات المكالمات", NameEn = "Call Status", SchemaName = "Lookup", TabelName = "CallStatus", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.CallType, NameAr = "أنواع المكالمات", NameEn = "Call Type", SchemaName = "Lookup", TabelName = "CallType", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.Campaign, NameAr = "الحملات", NameEn = "Campaign", SchemaName = "Lookup", TabelName = "Campaign", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.Category, NameAr = "التصنيفات", NameEn = "Category", SchemaName = "Lookup", TabelName = "Category", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.CategoryPath, NameAr = "مسارات التصنيفات", NameEn = "Category Path", SchemaName = "Lookup", TabelName = "CategoryPath", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.City, NameAr = "المدن", NameEn = "City", SchemaName = "Lookup", TabelName = "City", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.ConditionFor, NameAr = "الشروط لـ", NameEn = "Condition For", SchemaName = "Lookup", TabelName = "ConditionFor", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.ConditionType, NameAr = "أنواع الشروط", NameEn = "Condition Type", SchemaName = "Lookup", TabelName = "ConditionType", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.ContractStatus, NameAr = "حالة العقد", NameEn = "Contract Status", SchemaName = "Lookup", TabelName = "ContractType", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.ContractType, NameAr = "نوع العقد", NameEn = "Contract Type", SchemaName = "Lookup", TabelName = "ContractStatus", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.Country, NameAr = "البلاد", NameEn = "Country", SchemaName = "Lookup", TabelName = "Country", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.EmployerSector, NameAr = "قطاع العمل", NameEn = "Employer Sector", SchemaName = "Lookup", TabelName = "EmployerSector", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.EmployerType, NameAr = "جهة العمل", NameEn = "Employer Type", SchemaName = "Lookup", TabelName = "EmployerType", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.FieldType, NameAr = "أنواع الحقول", NameEn = "Field Type", SchemaName = "Lookup", TabelName = "FieldType", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.Gender, NameAr = "الأجناس", NameEn = "Gender", SchemaName = "Lookup", TabelName = "Gender", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.InsuranceStatus, NameAr = "حالة التأمينات", NameEn = "Insurance Status", SchemaName = "Lookup", TabelName = "InsuranceStatus", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.LoanTimeStatus, NameAr = "حلول القرض", NameEn = "Loan Time Status", SchemaName = "Lookup", TabelName = "LoanTimeStatus", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.Nationality, NameAr = "الجنسيات", NameEn = "Nationality", SchemaName = "Lookup", TabelName = "Nationality", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.PaymentGateway, NameAr = "بوابات الدفع", NameEn = "Payment Gateway", SchemaName = "Lookup", TabelName = "PaymentGateway", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.PaymentMethod, NameAr = "طرق الدفع", NameEn = "Payment Method", SchemaName = "Lookup", TabelName = "PaymentMethod", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.Permission, NameAr = "الصلاحيات", NameEn = "Permission", SchemaName = "Lookup", TabelName = "Permission", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.Priority, NameAr = "الأولويات", NameEn = "Priority", SchemaName = "Lookup", TabelName = "Priority", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.RegistrationType, NameAr = "أنواع تسجيلات المستخدمين", NameEn = "Registration Type", SchemaName = "Lookup", TabelName = "RegistrationType", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.RetirementStatus, NameAr = "حالة التقاعد", NameEn = "Retirement Status", SchemaName = "Lookup", TabelName = "RetirementStatus", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.Satisfaction, NameAr = "أنواع الرضى", NameEn = "Satisfaction", SchemaName = "Lookup", TabelName = "Satisfaction", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.SettingType, NameAr = "أنواع الإعدادات", NameEn = "Setting Type", SchemaName = "Lookup", TabelName = "SettingType", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.StumbleType, NameAr = "أنواع التعثرات", NameEn = "Stumble Type", SchemaName = "Lookup", TabelName = "StumbleType", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.Solvency, NameAr = "الملاءة المالية", NameEn = "Solvency", SchemaName = "Lookup", TabelName = "Solvency", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.Team, NameAr = "الفرق", NameEn = "Team", SchemaName = "Lookup", TabelName = "Team", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            builder.HasData(new EntityType { Id = Shared.Struct.Entities.Lookup.TriggerType, NameAr = "أنواع الإجراءات", NameEn = "Trigger Type", SchemaName = "Lookup", TabelName = "TriggerType", CreatedByUserId = Shared.Struct.StaticUser.System, CreatedOn = Shared.Struct.Settings.EntityCreateionDateTime, StateCode = 1, IsStatic = true });
            #endregion


            builder
              .HasMany(e => e.Entitys)
              .WithOne(e => e.EntityType)
              .HasForeignKey(e => e.EntityTypeId);

            builder
              .HasMany(e => e.EntityActionTypeRequiredFields)
              .WithOne(e => e.FieldShouldRelatedToEntityType)
              .HasForeignKey(e => e.FieldShouldRelatedToEntityTypeId);


            builder
              .HasMany(e => e.EntityFields)
              .WithOne(e => e.RelatedToEntity)
              .HasForeignKey(e => e.RelatedToEntityId);

            builder
              .HasMany(e => e.EntityActionTypes)
              .WithOne(e => e.EntityType)
              .HasForeignKey(e => e.EntityTypeId);

        }
    }
}
