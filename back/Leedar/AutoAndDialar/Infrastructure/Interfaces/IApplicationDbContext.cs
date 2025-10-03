using Domain.Entities.Application;
using Domain.Entities.Entity;
using Domain.Entities.Identity;
using Domain.Entities.Log;
using Domain.Entities.Lookup;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

//using Domain.Entities.Log;

namespace Infrastructure.Interfaces
{
    public interface IApplicationDbContext
    {


        #region Application

       
        DbSet<PersonalInfo> PersonalInfo { get; set; }
        DbSet<AutoContact> AutoContact { get; set; }
        DbSet<Contact> Contact { get; set; }
        DbSet<HistoricalCall> HistoricalCall { get; set; }
        DbSet<HistoricalCallPathResult> HistoricalCallPathResult { get; set; }
        DbSet<Setting> Setting { get; set; }
        DbSet<SystemProgress> SystemProgress { get; set; }
        DbSet<ScheduledCall> ScheduledCall { get; set; }




        #endregion

        #region Entities
        DbSet<DynamicFunction> DynamicFunction { get; set; }
        DbSet<DynamicFunctionParameter> DynamicFunctionParameter { get; set; }
        DbSet<DynamicFunctionResult> DynamicFunctionResult { get; set; }
        DbSet<DynamicReport> DynamicReport { get; set; }
        DbSet<DynamicReportField> DynamicReportField { get; set; }
        DbSet<Entity> Entity { get; set; }
        DbSet<EntityAction> EntityAction { get; set; }
        DbSet<EntityActionDynamicFunctionParameter> EntityActionDynamicFunctionParameter { get; set; }
        DbSet<EntityActionDynamicFunctionResult> EntityActionDynamicFunctionResult { get; set; }

        DbSet<EntityActionField> EntityActionField { get; set; }
        DbSet<EntityActionGroup> EntityActionGroup { get; set; }
        DbSet<EntityActionGroupConditionGroup> EntityActionGroupConditionGroup { get; set; }
        DbSet<EntityActionGroupTriggerType> EntityActionGroupTriggerType { get; set; }

        DbSet<EntityActionType> EntityActionType { get; set; }
        DbSet<EntityActionTypeRequiredField> EntityActionTypeRequiredField { get; set; }
        DbSet<EntityField> EntityField { get; set; }
        DbSet<EntityFieldActionField> EntityFieldActionField { get; set; }
        DbSet<EntityFieldAction> EntityFieldAction { get; set; }
        //DbSet<EntityFieldActionDynamicFunction> EntityFieldActionDynamicFunction { get; set; }
        DbSet<EntityFieldActionDynamicFunctionParameter> EntityFieldActionDynamicFunctionParameter { get; set; }
        DbSet<EntityFieldActionDynamicFunctionResult> EntityFieldActionDynamicFunctionResult { get; set; }

        DbSet<EntityFieldActionGroupCondition> EntityFieldActionGroupCondition { get; set; }
        DbSet<EntityFieldActionGroupConditionGroup> EntityFieldActionGroupConditionGroup { get; set; }
        DbSet<EntityFieldActionGroupTriggerType> EntityFieldActionGroupTriggerType { get; set; }

        DbSet<EntityFieldActionType> EntityFieldActionType { get; set; }
        DbSet<EntityFieldActionTypeRequiredField> EntityFieldActionTypeRequiredField { get; set; }
        DbSet<EntityFieldCondition> EntityFieldCondition { get; set; }
        DbSet<EntityFieldActionGroup> EntityFieldActionGroup { get; set; }
        DbSet<EntityFieldConditionGroup> EntityFieldConditionGroup { get; set; }
        DbSet<EntityFieldGroup> EntityFieldGroup { get; set; }
        DbSet<EntityFieldOption> EntityFieldOption { get; set; }
        DbSet<EntityFieldOptionCondition> EntityFieldOptionCondition { get; set; }
        DbSet<EntityFieldOptionConditionGroup> EntityFieldOptionConditionGroup { get; set; }
        DbSet<EntityFieldValue> EntityFieldValue { get; set; }
        DbSet<EntityMap> EntityMap { get; set; }
        DbSet<EntityRelationBreak> EntityRelationBreak { get; set; }
        DbSet<EntityActionGroupCondition> EntityActionGroupCondition { get; set; }
        DbSet<EntityType> EntityType { get; set; }
        #endregion

        #region Identity
        ////DbSet<RefreshToken> RefreshToken { get; set; }

        DbSet<Role> Role { get; set; }
        DbSet<RolePermission> RolePermission { get; set; }
        DbSet<User> User { get; set; }

        DbSet<UserPermission> UserPermission { get; set; }
        DbSet<UserRealTime> UserRealTime { get; set; }

        DbSet<UserSetting> UserSettings { get; set; }
        DbSet<UserTeams> UserTeams { get; set; }
        DbSet<UserCategory> UserCategory { get; set; }
        #endregion

        #region Log
        DbSet<ContactUploadingLog> ContactUploadingLog { get; set; }
        DbSet<HistoricalCallGeneralReportSammary> HistoricalCallGeneralReportSammary { get; set; }
        DbSet<Pim_contact_attempts_history> Pim_contact_attempts_history { get; set; }
        DbSet<Pim_contact_attempts_historyLog> Pim_contact_attempts_historyLog { get; set; }
        DbSet<nhc_agentless_can> nhc_agentless_can { get; set; }
        DbSet<nhc_interest_camp> nhc_interest_camp { get; set; }
        DbSet<ScheduledCallLog> ScheduledCallLog { get; set; }


        #endregion

        #region Lookup

        DbSet<AppSetting> AppSetting { get; set; }
        DbSet<AVAYAAURACampaignPredictive> AVAYAAURACampaignPredictive { get; set; }
        DbSet<Category> Category { get; set; }
        DbSet<CallStatus> CallStatus { get; set; }
        DbSet<CallType> CallType { get; set; }
        DbSet<Campaign> Campaign { get; set; }
        DbSet<Priority> Priority { get; set; }
        DbSet<Permission> Permission { get; set; }

        DbSet<CategoryPath> CategoryPath { get; set; }
        DbSet<City> City { get; set; }
        DbSet<ConditionFor> ConditionFor { get; set; }
        DbSet<ConditionType> ConditionType { get; set; }
        DbSet<FieldType> FieldType { get; set; }
        DbSet<Team> Team { get; set; }
        DbSet<TriggerType> TriggerType { get; set; }

        #endregion

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}