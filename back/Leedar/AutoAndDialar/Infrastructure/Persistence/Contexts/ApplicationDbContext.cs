namespace Infrastructure.Persistence.Contexts
{
    using Domain.Common;
    using Domain.Entities.Application;
    using Domain.Entities.Entity;
    using Domain.Entities.Identity;
    using Domain.Entities.Log;
    using Domain.Entities.Lookup;
   
    //using Domain.Entities.Log;

    //using Application.Common.Interfaces;
    using Infrastructure.Interfaces;
    using Infrastructure.Persistence.Extensions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Shared.Extensions;
    using Shared.Globalization;
    using Shared.Interfaces;
    using Shared.Interfaces.Services;
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    //using System.Data.Entity.Infrastructure;

    public class ApplicationDbContext : IdentityDbContext<User, Role, Guid>, IApplicationDbContext
    {
        private readonly IDateTimeService _dateTime;
        private readonly IContextCurrentUserService _contextcurrentUserService;


        public ApplicationDbContext()
        {
        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            IDateTimeService dateTime,
            IContextCurrentUserService contextcurrentUserService
            ) : base(options)
        {
            _dateTime = dateTime;
            _contextcurrentUserService = contextcurrentUserService;

        }
        #region Application
        public DbSet<PersonalInfo> PersonalInfo { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<AutoContact> AutoContact { get; set; }
        public DbSet<HistoricalCall> HistoricalCall { get; set; }
        public DbSet<HistoricalCallPathResult> HistoricalCallPathResult { get; set; }
        public DbSet<Setting> Setting { get; set; }
        public DbSet<SystemProgress> SystemProgress { get; set; }
        public DbSet<ScheduledCall> ScheduledCall { get; set; }

        #endregion

        #region Log
        public DbSet<ContactUploadingLog> ContactUploadingLog { get; set; }
        public DbSet<Pim_contact_attempts_history> Pim_contact_attempts_history { get; set; }
        public DbSet<HistoricalCallGeneralReportSammary> HistoricalCallGeneralReportSammary { get; set; }
        public DbSet<Pim_contact_attempts_historyLog> Pim_contact_attempts_historyLog { get; set; }
        public DbSet<nhc_agentless_can> nhc_agentless_can { get; set; }
        public DbSet<nhc_interest_camp> nhc_interest_camp { get; set; }
        public DbSet<ScheduledCallLog> ScheduledCallLog { get; set; }



        #endregion
        #region Entity 
        public DbSet<DynamicFunction> DynamicFunction { get; set; }
        public DbSet<DynamicFunctionParameter> DynamicFunctionParameter { get; set; }
        public DbSet<DynamicFunctionResult> DynamicFunctionResult { get; set; }
        public DbSet<DynamicReport> DynamicReport { get; set; }
        public DbSet<DynamicReportField> DynamicReportField { get; set; }
        public DbSet<Entity> Entity { get; set; }
       public DbSet<EntityAction> EntityAction { get; set; }
        public DbSet<EntityActionDynamicFunctionParameter> EntityActionDynamicFunctionParameter { get; set; }
        public DbSet<EntityActionDynamicFunctionResult> EntityActionDynamicFunctionResult { get; set; }

        public DbSet<EntityActionField> EntityActionField { get; set; }
        public DbSet<EntityActionGroup> EntityActionGroup { get; set; }
        public DbSet<EntityActionGroupConditionGroup> EntityActionGroupConditionGroup { get; set; }
        public DbSet<EntityActionGroupTriggerType> EntityActionGroupTriggerType { get; set; }

        public DbSet<EntityActionType> EntityActionType { get; set; }
        public DbSet<EntityActionTypeRequiredField> EntityActionTypeRequiredField { get; set; }
        public DbSet<EntityField> EntityField { get; set; }
        public DbSet<EntityFieldActionField> EntityFieldActionField { get; set; }
        public DbSet<EntityFieldAction> EntityFieldAction { get; set; }
        //DbSet<EntityFieldActionDynamicFunction> EntityFieldActionDynamicFunction { get; set; }
        public DbSet<EntityFieldActionDynamicFunctionParameter> EntityFieldActionDynamicFunctionParameter { get; set; }
        public DbSet<EntityFieldActionDynamicFunctionResult> EntityFieldActionDynamicFunctionResult { get; set; }

        public DbSet<EntityFieldActionGroupCondition> EntityFieldActionGroupCondition { get; set; }
        public DbSet<EntityFieldActionGroupConditionGroup> EntityFieldActionGroupConditionGroup { get; set; }
        public DbSet<EntityFieldActionGroupTriggerType> EntityFieldActionGroupTriggerType { get; set; }

        public DbSet<EntityFieldActionType> EntityFieldActionType { get; set; }
        public DbSet<EntityFieldActionTypeRequiredField> EntityFieldActionTypeRequiredField { get; set; }
        public DbSet<EntityFieldCondition> EntityFieldCondition { get; set; }
        public DbSet<EntityFieldActionGroup> EntityFieldActionGroup { get; set; }
        public DbSet<EntityFieldConditionGroup> EntityFieldConditionGroup { get; set; }
        public DbSet<EntityFieldGroup> EntityFieldGroup { get; set; }
        public DbSet<EntityFieldOption> EntityFieldOption { get; set; }
        public DbSet<EntityFieldOptionCondition> EntityFieldOptionCondition { get; set; }
        public DbSet<EntityFieldOptionConditionGroup> EntityFieldOptionConditionGroup { get; set; }
        public DbSet<EntityFieldValue> EntityFieldValue { get; set; }
        public DbSet<EntityMap> EntityMap { get; set; }
        public DbSet<EntityRelationBreak> EntityRelationBreak { get; set; }
        public DbSet<EntityActionGroupCondition> EntityActionGroupCondition { get; set; }
        public DbSet<EntityType> EntityType { get; set; }
        #endregion

        #region Identity
        //DbSet<RefreshToken> RefreshToken { get; set; }

        public DbSet<Role> Role { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<User> User { get; set; }

        public DbSet<UserPermission> UserPermission { get; set; }
        public DbSet<UserRealTime> UserRealTime { get; set; }

        public DbSet<UserSetting> UserSettings { get; set; }
        public DbSet<UserTeams> UserTeams { get; set; }
        public DbSet<UserCategory> UserCategory { get; set; }

        #endregion

        #region Lookup

        public DbSet<AppSetting> AppSetting { get; set; }
        public DbSet<AVAYAAURACampaignPredictive> AVAYAAURACampaignPredictive { get; set; }
         public DbSet<Category> Category { get; set; }
        public  DbSet<CallStatus> CallStatus { get; set; }
        public DbSet<CallType> CallType { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<Priority> Priority { get; set; }
        public DbSet<Permission> Permission { get; set; }
       public DbSet<CategoryPath> CategoryPath { get; set; }
       public DbSet<City> City { get; set; }
        public DbSet<ConditionFor> ConditionFor { get; set; }
        public DbSet<ConditionType> ConditionType { get; set; }
        public DbSet<FieldType> FieldType { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TriggerType> TriggerType { get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.BuildTable();
            builder.ConfigurTable();
            builder.BuildIdentityTable();

            //
            var userIncludPersonalInfo = builder.Entity<User>().Metadata.FindNavigation(nameof(Domain.Entities.Identity.User.PersonalInfo));
            userIncludPersonalInfo.SetIsEagerLoaded(true);

        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity<Guid>>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        if (entry.Entity.Id == Guid.Empty)
                        {
                            entry.Entity.Id = Guid.NewGuid().AsSequentialGuid();
                        }
                        entry.Entity.CreatedOn = _dateTime.Now;
                        entry.Entity.CreatedByUserId = _contextcurrentUserService.UserId;
                        entry.Entity.StateCode = 1;
                        break;

                    case EntityState.Modified:
                        //if (entry.Entity.StateCode == true)
                        //{
                        //    entry.Entity.DeletedOn = _dateTime.NowUtc;
                        //    entry.Entity.DeletedBy = _authenticatedUser.UserId;
                        //}
                        entry.Entity.LastModifiedOn = _dateTime.Now;
                        entry.Entity.LastModifiedByUserId = _contextcurrentUserService.UserId;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.StateCode = 0;
                        break;
                }
            }
            foreach (var entry in ChangeTracker.Entries<AuditableEntityNoID>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:

                        entry.Entity.CreatedOn = _dateTime.Now;
                        entry.Entity.CreatedByUserId = _contextcurrentUserService.UserId;
                        entry.Entity.StateCode = 1;
                        break;

                    case EntityState.Modified:
                        //if (entry.Entity.StateCode == true)
                        //{
                        //    entry.Entity.DeletedOn = _dateTime.NowUtc;
                        //    entry.Entity.DeletedBy = _authenticatedUser.UserId;
                        //}
                        entry.Entity.LastModifiedOn = _dateTime.Now;
                        entry.Entity.LastModifiedByUserId = _contextcurrentUserService.UserId;
                        break;

                    case EntityState.Deleted:
                        entry.Entity.StateCode = 0;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }



    }
}
