IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
IF SCHEMA_ID(N'Lookup') IS NULL EXEC(N'CREATE SCHEMA [Lookup];');

IF SCHEMA_ID(N'Application') IS NULL EXEC(N'CREATE SCHEMA [Application];');

IF SCHEMA_ID(N'Log') IS NULL EXEC(N'CREATE SCHEMA [Log];');

IF SCHEMA_ID(N'Entity') IS NULL EXEC(N'CREATE SCHEMA [Entity];');

IF SCHEMA_ID(N'Identity') IS NULL EXEC(N'CREATE SCHEMA [Identity];');

CREATE TABLE [Lookup].[AppSetting] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [SectionName] nvarchar(256) NULL,
    [KeyName] nvarchar(256) NULL,
    [Value] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_AppSetting] PRIMARY KEY ([Id])
);

CREATE TABLE [Lookup].[AVAYAAURACampaignPredictive] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [NameInAvayaSystem] nvarchar(256) NULL,
    [IsPredictive] bit NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_AVAYAAURACampaignPredictive] PRIMARY KEY ([Id])
);

CREATE TABLE [Lookup].[CallStatus] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_CallStatus] PRIMARY KEY ([Id])
);

CREATE TABLE [Lookup].[CallType] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_CallType] PRIMARY KEY ([Id])
);

CREATE TABLE [Lookup].[CategoryPath] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_CategoryPath] PRIMARY KEY ([Id])
);

CREATE TABLE [Lookup].[City] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_City] PRIMARY KEY ([Id])
);

CREATE TABLE [Lookup].[ConditionFor] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_ConditionFor] PRIMARY KEY ([Id])
);

CREATE TABLE [Lookup].[ConditionType] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_ConditionType] PRIMARY KEY ([Id])
);

CREATE TABLE [ContactCategory] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_ContactCategory] PRIMARY KEY ([Id])
);

CREATE TABLE [Entity].[DynamicFunction] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [FunctionIdentifire] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_DynamicFunction] PRIMARY KEY ([Id])
);

CREATE TABLE [Entity].[EntityType] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [SchemaName] nvarchar(256) NULL,
    [TabelName] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_EntityType] PRIMARY KEY ([Id])
);

CREATE TABLE [Lookup].[FieldType] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_FieldType] PRIMARY KEY ([Id])
);

CREATE TABLE [Log].[nhc_agentless_can] (
    [IdGu] uniqueidentifier NOT NULL,
    [id] bigint NOT NULL,
    [UCID] nvarchar(256) NULL,
    [agentid] nvarchar(256) NULL,
    [callernumber] nvarchar(256) NULL,
    [evalresult1] nvarchar(256) NULL,
    [submitdate] datetime2 NULL,
    [evalresult2] nvarchar(256) NULL,
    [channel] nvarchar(256) NULL,
    CONSTRAINT [PK_nhc_agentless_can] PRIMARY KEY ([IdGu])
);

CREATE TABLE [Log].[nhc_interest_camp] (
    [IdGu] uniqueidentifier NOT NULL,
    [id] bigint NOT NULL,
    [UCID] nvarchar(256) NULL,
    [agentid] nvarchar(256) NULL,
    [callernumber] nvarchar(256) NULL,
    [Visited_Note] nvarchar(256) NULL,
    [submitdate] datetime2 NULL,
    CONSTRAINT [PK_nhc_interest_camp] PRIMARY KEY ([IdGu])
);

CREATE TABLE [Lookup].[Permission] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_Permission] PRIMARY KEY ([Id])
);

CREATE TABLE [Lookup].[Priority] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Number] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_Priority] PRIMARY KEY ([Id])
);

CREATE TABLE [Identity].[Role] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [NameAr] nvarchar(256) NULL,
    [IsDefualt] bit NOT NULL,
    [IsStatic] bit NOT NULL,
    [StateCode] tinyint NOT NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(256) NULL,
    CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
);

CREATE TABLE [Application].[Setting] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [NameForSystem] nvarchar(256) NULL,
    [Value] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_Setting] PRIMARY KEY ([Id])
);

CREATE TABLE [Lookup].[SettingType] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_SettingType] PRIMARY KEY ([Id])
);

CREATE TABLE [Lookup].[TriggerType] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_TriggerType] PRIMARY KEY ([Id])
);

CREATE TABLE [Application].[PersonalInfo] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [IdentityNumber] nvarchar(256) NULL,
    [FullNameAr] nvarchar(256) NULL,
    [PhoneNumber] nvarchar(256) NULL,
    [PhoneNumber2] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [Notes] nvarchar(256) NULL,
    [CityId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_PersonalInfo] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PersonalInfo_City_CityId] FOREIGN KEY ([CityId]) REFERENCES [Lookup].[City] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[DynamicFunctionParameter] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [DynamicFunctionId] uniqueidentifier NOT NULL,
    [FunctionIdentifire] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_DynamicFunctionParameter] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DynamicFunctionParameter_DynamicFunction_DynamicFunctionId] FOREIGN KEY ([DynamicFunctionId]) REFERENCES [Entity].[DynamicFunction] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[DynamicFunctionResult] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [DynamicFunctionId] uniqueidentifier NOT NULL,
    [OutputIdentifire] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_DynamicFunctionResult] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DynamicFunctionResult_DynamicFunction_DynamicFunctionId] FOREIGN KEY ([DynamicFunctionId]) REFERENCES [Entity].[DynamicFunction] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[Entity] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityTypeId] uniqueidentifier NOT NULL,
    [RelatedEntityPK] uniqueidentifier NULL,
    [CallStatusFieldId] uniqueidentifier NULL,
    [SubCallStatusFieldId] uniqueidentifier NULL,
    [NoteId] uniqueidentifier NULL,
    [SubNoteId] uniqueidentifier NULL,
    [OtherNoteId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_Entity] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Entity_EntityType_EntityTypeId] FOREIGN KEY ([EntityTypeId]) REFERENCES [Entity].[EntityType] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityActionType] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityTypeId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_EntityActionType] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityActionType_EntityType_EntityTypeId] FOREIGN KEY ([EntityTypeId]) REFERENCES [Entity].[EntityType] ([Id])
);

CREATE TABLE [Lookup].[Campaign] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [PriorityId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_Campaign] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Campaign_Priority_PriorityId] FOREIGN KEY ([PriorityId]) REFERENCES [Lookup].[Priority] ([Id]) ON DELETE SET NULL
);

CREATE TABLE [Lookup].[Category] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [CallCategoryMainId] uniqueidentifier NULL,
    [CategoryPathId] uniqueidentifier NULL,
    [AVAYAAURACampaignPredictiveId] uniqueidentifier NULL,
    [CallTypeId] uniqueidentifier NULL,
    [PriorityId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_Category] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Category_AVAYAAURACampaignPredictive_AVAYAAURACampaignPredictiveId] FOREIGN KEY ([AVAYAAURACampaignPredictiveId]) REFERENCES [Lookup].[AVAYAAURACampaignPredictive] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Category_CallType_CallTypeId] FOREIGN KEY ([CallTypeId]) REFERENCES [Lookup].[CallType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_Category_CategoryPath_CategoryPathId] FOREIGN KEY ([CategoryPathId]) REFERENCES [Lookup].[CategoryPath] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Category_Category_CallCategoryMainId] FOREIGN KEY ([CallCategoryMainId]) REFERENCES [Lookup].[Category] ([Id]),
    CONSTRAINT [FK_Category_Priority_PriorityId] FOREIGN KEY ([PriorityId]) REFERENCES [Lookup].[Priority] ([Id]) ON DELETE SET NULL
);

CREATE TABLE [Identity].[RoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [RoleId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(256) NULL,
    [ClaimValue] nvarchar(256) NULL,
    CONSTRAINT [PK_RoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_RoleClaims_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Identity].[Role] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Identity].[RolePermission] (
    [RoleId] uniqueidentifier NOT NULL,
    [PermissionId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_RolePermission] PRIMARY KEY ([RoleId], [PermissionId]),
    CONSTRAINT [FK_RolePermission_Permission_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [Lookup].[Permission] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_RolePermission_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Identity].[Role] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Application].[Contact] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [PersonalInfoId] uniqueidentifier NOT NULL,
    [Notes] nvarchar(256) NULL,
    [FullName] nvarchar(256) NULL,
    [PhoneNumber] nvarchar(256) NULL,
    [IdentityNumber] nvarchar(256) NULL,
    [ContactCategoryId] uniqueidentifier NULL,
    [IsDesable] bit NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contact_ContactCategory_ContactCategoryId] FOREIGN KEY ([ContactCategoryId]) REFERENCES [ContactCategory] ([Id]),
    CONSTRAINT [FK_Contact_PersonalInfo_Id] FOREIGN KEY ([Id]) REFERENCES [Application].[PersonalInfo] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Identity].[User] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EmployeeNumber] nvarchar(256) NULL,
    [IsStatic] bit NOT NULL,
    [IsLoggedIn] bit NOT NULL,
    [IsHasSpecialPermissions] bit NOT NULL,
    [LatestLoggedInDateTime] datetime2 NULL,
    [LatestPasswordChangedDateTime] datetime2 NULL,
    [PasswordHint] nvarchar(256) NULL,
    [Extension] nvarchar(256) NULL,
    [WrongPassTry] int NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [PersonalInfoId] uniqueidentifier NOT NULL,
    [UserName] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [Email] nvarchar(256) NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [PasswordHash] nvarchar(256) NULL,
    [SecurityStamp] nvarchar(256) NULL,
    [ConcurrencyStamp] nvarchar(256) NULL,
    [PhoneNumber] nvarchar(256) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [LockoutEnabled] bit NOT NULL,
    [AccessFailedCount] int NOT NULL,
    CONSTRAINT [PK_User] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_User_PersonalInfo_Id] FOREIGN KEY ([Id]) REFERENCES [Application].[PersonalInfo] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_User_User_CreatedByUserId] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_User_User_LastModifiedByUserId] FOREIGN KEY ([LastModifiedByUserId]) REFERENCES [Identity].[User] ([Id])
);

CREATE TABLE [Entity].[DynamicReport] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_DynamicReport] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DynamicReport_Entity_EntityId] FOREIGN KEY ([EntityId]) REFERENCES [Entity].[Entity] ([Id])
);

CREATE TABLE [Entity].[EntityActionGroup] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityId] uniqueidentifier NOT NULL,
    [ANDorOR] bit NULL,
    [ProcessOrder] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_EntityActionGroup] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityActionGroup_Entity_EntityId] FOREIGN KEY ([EntityId]) REFERENCES [Entity].[Entity] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityFieldActionType] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_EntityFieldActionType] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldActionType_Entity_EntityId] FOREIGN KEY ([EntityId]) REFERENCES [Entity].[Entity] ([Id])
);

CREATE TABLE [Entity].[EntityFieldGroup] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityId] uniqueidentifier NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_EntityFieldGroup] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldGroup_Entity_EntityId] FOREIGN KEY ([EntityId]) REFERENCES [Entity].[Entity] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityMap] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [RelationName] nvarchar(256) NULL,
    [EntityId] uniqueidentifier NOT NULL,
    [MappedEntityId] uniqueidentifier NOT NULL,
    [IsNullable] bit NOT NULL,
    CONSTRAINT [PK_EntityMap] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityMap_Entity_EntityId] FOREIGN KEY ([EntityId]) REFERENCES [Entity].[Entity] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityMap_Entity_MappedEntityId] FOREIGN KEY ([MappedEntityId]) REFERENCES [Entity].[Entity] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityRelationBreak] (
    [EntityId] uniqueidentifier NOT NULL,
    [Entity2Id] uniqueidentifier NOT NULL,
    [EntityPK] uniqueidentifier NOT NULL,
    [Entity2PK] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_EntityRelationBreak] PRIMARY KEY ([EntityId], [Entity2Id]),
    CONSTRAINT [FK_EntityRelationBreak_Entity_Entity2Id] FOREIGN KEY ([Entity2Id]) REFERENCES [Entity].[Entity] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityRelationBreak_Entity_EntityId] FOREIGN KEY ([EntityId]) REFERENCES [Entity].[Entity] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Application].[SystemProgress] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityId] uniqueidentifier NULL,
    [Description] nvarchar(2000) NULL,
    [Title] nvarchar(1000) NULL,
    [Max] int NOT NULL,
    [Currant] int NOT NULL,
    [FilePath] nvarchar(1000) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_SystemProgress] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SystemProgress_Entity_EntityId] FOREIGN KEY ([EntityId]) REFERENCES [Entity].[Entity] ([Id])
);

CREATE TABLE [Entity].[EntityActionTypeRequiredField] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityActionTypeId] uniqueidentifier NOT NULL,
    [FieldName] nvarchar(256) NULL,
    [FieldTypeId] uniqueidentifier NOT NULL,
    [FieldShouldRelatedToEntityTypeId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityActionTypeRequiredField] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityActionTypeRequiredField_EntityActionType_EntityActionTypeId] FOREIGN KEY ([EntityActionTypeId]) REFERENCES [Entity].[EntityActionType] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityActionTypeRequiredField_EntityType_FieldShouldRelatedToEntityTypeId] FOREIGN KEY ([FieldShouldRelatedToEntityTypeId]) REFERENCES [Entity].[EntityType] ([Id]),
    CONSTRAINT [FK_EntityActionTypeRequiredField_FieldType_FieldTypeId] FOREIGN KEY ([FieldTypeId]) REFERENCES [Lookup].[FieldType] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Log].[ContactUploadingLog] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [ContactId] uniqueidentifier NULL,
    [CampaignId] uniqueidentifier NULL,
    [CategoryId] uniqueidentifier NULL,
    [PriorityId] uniqueidentifier NULL,
    [IsUploadedSuccessfully] bit NOT NULL,
    [FileRow] int NOT NULL,
    [FileName] nvarchar(2000) NULL,
    [Description] nvarchar(2000) NULL,
    [DescriptionOthers] nvarchar(2000) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_ContactUploadingLog] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ContactUploadingLog_Campaign_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [Lookup].[Campaign] ([Id]),
    CONSTRAINT [FK_ContactUploadingLog_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Lookup].[Category] ([Id]),
    CONSTRAINT [FK_ContactUploadingLog_Contact_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Application].[Contact] ([Id]),
    CONSTRAINT [FK_ContactUploadingLog_Priority_PriorityId] FOREIGN KEY ([PriorityId]) REFERENCES [Lookup].[Priority] ([Id])
);

CREATE TABLE [Application].[HistoricalCall] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [ContactId] uniqueidentifier NOT NULL,
    [CallStatusId] uniqueidentifier NOT NULL,
    [SubCallStatusId] uniqueidentifier NULL,
    [CallTypeId] uniqueidentifier NULL,
    [AssignToUserId] uniqueidentifier NULL,
    [AssignFromUserId] uniqueidentifier NULL,
    [AssignToUserAt] datetime2 NULL,
    [ScheduledToUserId] uniqueidentifier NULL,
    [ScheduledByUserId] uniqueidentifier NULL,
    [ScheduledToUserAt] datetime2 NULL,
    [ScheduledCallDate] datetime2 NULL,
    [CallDuration] float NULL,
    [IsLatestCall] bit NOT NULL,
    [LatestHistoricalCallId] uniqueidentifier NULL,
    [CampaignId] uniqueidentifier NULL,
    [CategoryId] uniqueidentifier NULL,
    [ScheduledCallId] uniqueidentifier NULL,
    [CallDate] datetime2 NOT NULL,
    [PriorityId] uniqueidentifier NULL,
    [GetResultFromAvayaAt] datetime2 NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_HistoricalCall] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HistoricalCall_CallStatus_CallStatusId] FOREIGN KEY ([CallStatusId]) REFERENCES [Lookup].[CallStatus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HistoricalCall_CallType_CallTypeId] FOREIGN KEY ([CallTypeId]) REFERENCES [Lookup].[CallType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_HistoricalCall_Campaign_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [Lookup].[Campaign] ([Id]),
    CONSTRAINT [FK_HistoricalCall_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Lookup].[Category] ([Id]),
    CONSTRAINT [FK_HistoricalCall_Contact_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Application].[Contact] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HistoricalCall_HistoricalCall_LatestHistoricalCallId] FOREIGN KEY ([LatestHistoricalCallId]) REFERENCES [Application].[HistoricalCall] ([Id]),
    CONSTRAINT [FK_HistoricalCall_Priority_PriorityId] FOREIGN KEY ([PriorityId]) REFERENCES [Lookup].[Priority] ([Id]),
    CONSTRAINT [FK_HistoricalCall_User_AssignFromUserId] FOREIGN KEY ([AssignFromUserId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_HistoricalCall_User_AssignToUserId] FOREIGN KEY ([AssignToUserId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_HistoricalCall_User_ScheduledByUserId] FOREIGN KEY ([ScheduledByUserId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_HistoricalCall_User_ScheduledToUserId] FOREIGN KEY ([ScheduledToUserId]) REFERENCES [Identity].[User] ([Id])
);

CREATE TABLE [Lookup].[Team] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [LeaderId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_Team] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Team_User_LeaderId] FOREIGN KEY ([LeaderId]) REFERENCES [Identity].[User] ([Id])
);

CREATE TABLE [Identity].[UserClaims] (
    [Id] int NOT NULL IDENTITY,
    [UserId] uniqueidentifier NOT NULL,
    [ClaimType] nvarchar(256) NULL,
    [ClaimValue] nvarchar(256) NULL,
    CONSTRAINT [PK_UserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_UserClaims_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Identity].[UserLogins] (
    [LoginProvider] nvarchar(256) NOT NULL,
    [ProviderKey] nvarchar(256) NOT NULL,
    [ProviderDisplayName] nvarchar(256) NULL,
    [UserId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_UserLogins_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Identity].[UserPermission] (
    [UserId] uniqueidentifier NOT NULL,
    [PermissionId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserPermission] PRIMARY KEY ([UserId], [PermissionId]),
    CONSTRAINT [FK_UserPermission_Permission_PermissionId] FOREIGN KEY ([PermissionId]) REFERENCES [Lookup].[Permission] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserPermission_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Identity].[UserRealTime] (
    [UserId] uniqueidentifier NOT NULL,
    [SignalRId] nvarchar(256) NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_UserRealTime] PRIMARY KEY ([UserId], [SignalRId]),
    CONSTRAINT [FK_UserRealTime_User_CreatedByUserId] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_UserRealTime_User_LastModifiedByUserId] FOREIGN KEY ([LastModifiedByUserId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_UserRealTime_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Identity].[UserRoles] (
    [UserId] uniqueidentifier NOT NULL,
    [RoleId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_UserRoles_Role_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Identity].[Role] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserRoles_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Identity].[UserSetting] (
    [UserId] uniqueidentifier NOT NULL,
    [SettingTypeId] uniqueidentifier NOT NULL,
    [Value] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_UserSetting] PRIMARY KEY ([UserId], [SettingTypeId]),
    CONSTRAINT [FK_UserSetting_SettingType_SettingTypeId] FOREIGN KEY ([SettingTypeId]) REFERENCES [Lookup].[SettingType] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserSetting_User_CreatedByUserId] FOREIGN KEY ([CreatedByUserId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_UserSetting_User_LastModifiedByUserId] FOREIGN KEY ([LastModifiedByUserId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_UserSetting_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Identity].[UserTokens] (
    [UserId] uniqueidentifier NOT NULL,
    [LoginProvider] nvarchar(256) NOT NULL,
    [Name] nvarchar(256) NOT NULL,
    [Value] nvarchar(256) NULL,
    CONSTRAINT [PK_UserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_UserTokens_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityAction] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityActionGroupId] uniqueidentifier NOT NULL,
    [EntityActionTypeId] uniqueidentifier NOT NULL,
    [ProcessOrder] int NOT NULL,
    [DynamicFunctionId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_EntityAction] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityAction_DynamicFunction_DynamicFunctionId] FOREIGN KEY ([DynamicFunctionId]) REFERENCES [Entity].[DynamicFunction] ([Id]),
    CONSTRAINT [FK_EntityAction_EntityActionGroup_EntityActionGroupId] FOREIGN KEY ([EntityActionGroupId]) REFERENCES [Entity].[EntityActionGroup] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityAction_EntityActionType_EntityActionTypeId] FOREIGN KEY ([EntityActionTypeId]) REFERENCES [Entity].[EntityActionType] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityActionGroupConditionGroup] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityActionGroupId] uniqueidentifier NOT NULL,
    [ANDorOR] bit NULL,
    [ViewOrder] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityActionGroupConditionGroup] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityActionGroupConditionGroup_EntityActionGroup_EntityActionGroupId] FOREIGN KEY ([EntityActionGroupId]) REFERENCES [Entity].[EntityActionGroup] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityActionGroupTriggerType] (
    [EntityActionGroupId] uniqueidentifier NOT NULL,
    [TriggerTypeId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_EntityActionGroupTriggerType] PRIMARY KEY ([EntityActionGroupId], [TriggerTypeId]),
    CONSTRAINT [FK_EntityActionGroupTriggerType_EntityActionGroup_EntityActionGroupId] FOREIGN KEY ([EntityActionGroupId]) REFERENCES [Entity].[EntityActionGroup] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityActionGroupTriggerType_TriggerType_TriggerTypeId] FOREIGN KEY ([TriggerTypeId]) REFERENCES [Lookup].[TriggerType] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityFieldActionTypeRequiredField] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldActionTypeId] uniqueidentifier NOT NULL,
    [FieldName] nvarchar(256) NULL,
    [FieldTypeId] uniqueidentifier NOT NULL,
    [FieldShouldRelatedToEntityId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityFieldActionTypeRequiredField] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldActionTypeRequiredField_EntityFieldActionType_EntityFieldActionTypeId] FOREIGN KEY ([EntityFieldActionTypeId]) REFERENCES [Entity].[EntityFieldActionType] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionTypeRequiredField_Entity_FieldShouldRelatedToEntityId] FOREIGN KEY ([FieldShouldRelatedToEntityId]) REFERENCES [Entity].[Entity] ([Id]),
    CONSTRAINT [FK_EntityFieldActionTypeRequiredField_FieldType_FieldTypeId] FOREIGN KEY ([FieldTypeId]) REFERENCES [Lookup].[FieldType] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityField] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldGroupId] uniqueidentifier NOT NULL,
    [FieldTypeId] uniqueidentifier NOT NULL,
    [RelatedToEntityId] uniqueidentifier NULL,
    [IsRequired] bit NULL,
    [IsReadOnly] bit NULL,
    [IsReportExportable] bit NULL,
    [IsForVisitReport] bit NULL,
    [IsForSpecialSammaryReport] bit NULL,
    [Unified] int NOT NULL,
    [Row] int NOT NULL,
    [Column] int NOT NULL,
    [Width] int NOT NULL,
    [Height] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_EntityField] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityField_EntityFieldGroup_EntityFieldGroupId] FOREIGN KEY ([EntityFieldGroupId]) REFERENCES [Entity].[EntityFieldGroup] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityField_EntityType_RelatedToEntityId] FOREIGN KEY ([RelatedToEntityId]) REFERENCES [Entity].[EntityType] ([Id]),
    CONSTRAINT [FK_EntityField_FieldType_FieldTypeId] FOREIGN KEY ([FieldTypeId]) REFERENCES [Lookup].[FieldType] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[DynamicReportField] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [DynamicReportId] uniqueidentifier NOT NULL,
    [EntityMapId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_DynamicReportField] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_DynamicReportField_DynamicReport_DynamicReportId] FOREIGN KEY ([DynamicReportId]) REFERENCES [Entity].[DynamicReport] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_DynamicReportField_EntityMap_EntityMapId] FOREIGN KEY ([EntityMapId]) REFERENCES [Entity].[EntityMap] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Log].[HistoricalCallGeneralReportSammary] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [HistoricalCallId] uniqueidentifier NOT NULL,
    [ContactId] uniqueidentifier NOT NULL,
    [CallStatusId] uniqueidentifier NOT NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    [CampaignId] uniqueidentifier NOT NULL,
    [UserId] uniqueidentifier NULL,
    [LeaderId] uniqueidentifier NULL,
    [ContactIdentity] nvarchar(256) NULL,
    [ContactName] nvarchar(256) NULL,
    [ContactPhone1] nvarchar(256) NULL,
    [ContactPhone2] nvarchar(256) NULL,
    [CallTypeId] uniqueidentifier NULL,
    [CallDate] datetime2 NOT NULL,
    [CallDuration] float NULL,
    [CallDurationString] nvarchar(256) NULL,
    [CallStatusName] nvarchar(256) NULL,
    [SubCallStatusName] nvarchar(256) NULL,
    [CallStatusResult] nvarchar(256) NULL,
    [CallStatusResultSub] nvarchar(256) NULL,
    [CallStatusOtherNote] nvarchar(max) NULL,
    [CategoryName] nvarchar(256) NULL,
    [CampaignName] nvarchar(256) NULL,
    [EmployeeName] nvarchar(256) NULL,
    [EmployeeNumber] nvarchar(256) NULL,
    [LeaderName] nvarchar(256) NULL,
    [CallUpload] datetime2 NULL,
    [CallStartAt] datetime2 NULL,
    [CallEndAt] datetime2 NULL,
    [PriorityName] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_HistoricalCallGeneralReportSammary] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HistoricalCallGeneralReportSammary_CallStatus_CallStatusId] FOREIGN KEY ([CallStatusId]) REFERENCES [Lookup].[CallStatus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HistoricalCallGeneralReportSammary_CallType_CallTypeId] FOREIGN KEY ([CallTypeId]) REFERENCES [Lookup].[CallType] ([Id]),
    CONSTRAINT [FK_HistoricalCallGeneralReportSammary_Campaign_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [Lookup].[Campaign] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HistoricalCallGeneralReportSammary_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Lookup].[Category] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HistoricalCallGeneralReportSammary_Contact_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Application].[Contact] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HistoricalCallGeneralReportSammary_HistoricalCall_HistoricalCallId] FOREIGN KEY ([HistoricalCallId]) REFERENCES [Application].[HistoricalCall] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HistoricalCallGeneralReportSammary_User_LeaderId] FOREIGN KEY ([LeaderId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_HistoricalCallGeneralReportSammary_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id])
);

CREATE TABLE [Log].[Pim_contact_attempts_historyLog] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Pim_session_id] bigint NOT NULL,
    [Completion_Code_id] int NOT NULL,
    [Completion_Code_Name] nvarchar(256) NULL,
    [Completion_Code_Name_Ar] nvarchar(256) NULL,
    [Sys_completion_code_id] int NULL,
    [Contact_attempt_time] datetime2 NULL,
    [Last_nw_disposition_time] datetime2 NULL,
    [Call_start_time] datetime2 NULL,
    [Call_completion_time] datetime2 NULL,
    [Ucid] nvarchar(256) NULL,
    [Address] nvarchar(256) NULL,
    [Agent_id] nvarchar(256) NULL,
    [Campaign_id] int NULL,
    [Campaign_list_id] int NULL,
    [CallDuration] float NOT NULL,
    [IsSuccess] bit NOT NULL,
    [ContactId] uniqueidentifier NULL,
    [UserId] uniqueidentifier NULL,
    [CategoryId] uniqueidentifier NULL,
    [CampaignId] uniqueidentifier NULL,
    [ScheduledCallId] uniqueidentifier NULL,
    [HistoricalCallId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_Pim_contact_attempts_historyLog] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pim_contact_attempts_historyLog_Campaign_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [Lookup].[Campaign] ([Id]),
    CONSTRAINT [FK_Pim_contact_attempts_historyLog_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Lookup].[Category] ([Id]),
    CONSTRAINT [FK_Pim_contact_attempts_historyLog_Contact_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Application].[Contact] ([Id]),
    CONSTRAINT [FK_Pim_contact_attempts_historyLog_HistoricalCall_HistoricalCallId] FOREIGN KEY ([HistoricalCallId]) REFERENCES [Application].[HistoricalCall] ([Id]),
    CONSTRAINT [FK_Pim_contact_attempts_historyLog_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id])
);

CREATE TABLE [Application].[ScheduledCall] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [ContactId] uniqueidentifier NOT NULL,
    [CallStatusId] uniqueidentifier NULL,
    [CallTypeId] uniqueidentifier NULL,
    [AssignToUserId] uniqueidentifier NULL,
    [AssignFromUserId] uniqueidentifier NULL,
    [AssignToUserAt] datetime2 NULL,
    [ScheduledToUserId] uniqueidentifier NULL,
    [ScheduledByUserId] uniqueidentifier NULL,
    [ScheduledToUserAt] datetime2 NULL,
    [ScheduledCallDate] datetime2 NULL,
    [CampaignId] uniqueidentifier NULL,
    [CategoryId] uniqueidentifier NULL,
    [PriorityId] uniqueidentifier NULL,
    [LatestHistoricalCallId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_ScheduledCall] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_ScheduledCall_CallStatus_CallStatusId] FOREIGN KEY ([CallStatusId]) REFERENCES [Lookup].[CallStatus] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ScheduledCall_CallType_CallTypeId] FOREIGN KEY ([CallTypeId]) REFERENCES [Lookup].[CallType] ([Id]) ON DELETE SET NULL,
    CONSTRAINT [FK_ScheduledCall_Campaign_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [Lookup].[Campaign] ([Id]),
    CONSTRAINT [FK_ScheduledCall_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Lookup].[Category] ([Id]),
    CONSTRAINT [FK_ScheduledCall_Contact_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Application].[Contact] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_ScheduledCall_HistoricalCall_LatestHistoricalCallId] FOREIGN KEY ([LatestHistoricalCallId]) REFERENCES [Application].[HistoricalCall] ([Id]),
    CONSTRAINT [FK_ScheduledCall_Priority_PriorityId] FOREIGN KEY ([PriorityId]) REFERENCES [Lookup].[Priority] ([Id]),
    CONSTRAINT [FK_ScheduledCall_User_AssignFromUserId] FOREIGN KEY ([AssignFromUserId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_ScheduledCall_User_AssignToUserId] FOREIGN KEY ([AssignToUserId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_ScheduledCall_User_ScheduledByUserId] FOREIGN KEY ([ScheduledByUserId]) REFERENCES [Identity].[User] ([Id]),
    CONSTRAINT [FK_ScheduledCall_User_ScheduledToUserId] FOREIGN KEY ([ScheduledToUserId]) REFERENCES [Identity].[User] ([Id])
);

CREATE TABLE [Identity].[UserTeams] (
    [UserId] uniqueidentifier NOT NULL,
    [TeamId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_UserTeams] PRIMARY KEY ([UserId], [TeamId]),
    CONSTRAINT [FK_UserTeams_Team_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Lookup].[Team] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_UserTeams_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityActionGroupCondition] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityActionGroupConditionGroupId] uniqueidentifier NOT NULL,
    [FirstSideRelatedToEntityId] uniqueidentifier NULL,
    [FirstSideFieldId] uniqueidentifier NOT NULL,
    [ConditionTypeId] uniqueidentifier NOT NULL,
    [SecondSideRelatedToEntityId] uniqueidentifier NULL,
    [CondetionValue] nvarchar(256) NULL,
    [ANDorOR] bit NULL,
    [ViewOrder] int NOT NULL,
    [ProcessOrder] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityActionGroupCondition] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityActionGroupCondition_ConditionType_ConditionTypeId] FOREIGN KEY ([ConditionTypeId]) REFERENCES [Lookup].[ConditionType] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityActionGroupCondition_EntityActionGroupConditionGroup_EntityActionGroupConditionGroupId] FOREIGN KEY ([EntityActionGroupConditionGroupId]) REFERENCES [Entity].[EntityActionGroupConditionGroup] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityActionGroupCondition_Entity_FirstSideRelatedToEntityId] FOREIGN KEY ([FirstSideRelatedToEntityId]) REFERENCES [Entity].[Entity] ([Id]),
    CONSTRAINT [FK_EntityActionGroupCondition_Entity_SecondSideRelatedToEntityId] FOREIGN KEY ([SecondSideRelatedToEntityId]) REFERENCES [Entity].[Entity] ([Id])
);

CREATE TABLE [Entity].[EntityActionDynamicFunctionParameter] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityActionId] uniqueidentifier NOT NULL,
    [DynamicFunctionParameterId] uniqueidentifier NOT NULL,
    [EntityFieldId] uniqueidentifier NULL,
    [Value] nvarchar(256) NULL,
    [FieldShouldRelatedToEntityTypeId] uniqueidentifier NULL,
    CONSTRAINT [PK_EntityActionDynamicFunctionParameter] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityActionDynamicFunctionParameter_DynamicFunctionParameter_DynamicFunctionParameterId] FOREIGN KEY ([DynamicFunctionParameterId]) REFERENCES [Entity].[DynamicFunctionParameter] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityActionDynamicFunctionParameter_EntityAction_EntityActionId] FOREIGN KEY ([EntityActionId]) REFERENCES [Entity].[EntityAction] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityActionDynamicFunctionParameter_EntityField_EntityFieldId] FOREIGN KEY ([EntityFieldId]) REFERENCES [Entity].[EntityField] ([Id])
);

CREATE TABLE [Entity].[EntityActionDynamicFunctionResult] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityActionId] uniqueidentifier NOT NULL,
    [DynamicFunctionResultId] uniqueidentifier NOT NULL,
    [EntityFieldId] uniqueidentifier NOT NULL,
    [IsResultToNotification] bit NULL,
    CONSTRAINT [PK_EntityActionDynamicFunctionResult] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityActionDynamicFunctionResult_DynamicFunctionResult_DynamicFunctionResultId] FOREIGN KEY ([DynamicFunctionResultId]) REFERENCES [Entity].[DynamicFunctionResult] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityActionDynamicFunctionResult_EntityAction_EntityActionId] FOREIGN KEY ([EntityActionId]) REFERENCES [Entity].[EntityAction] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityActionDynamicFunctionResult_EntityField_EntityFieldId] FOREIGN KEY ([EntityFieldId]) REFERENCES [Entity].[EntityField] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityActionField] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityActionId] uniqueidentifier NOT NULL,
    [EntityActionTypeRequiredFieldId] uniqueidentifier NOT NULL,
    [EntityFieldId] uniqueidentifier NULL,
    [Value] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityActionField] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityActionField_EntityActionTypeRequiredField_EntityActionTypeRequiredFieldId] FOREIGN KEY ([EntityActionTypeRequiredFieldId]) REFERENCES [Entity].[EntityActionTypeRequiredField] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityActionField_EntityAction_EntityActionId] FOREIGN KEY ([EntityActionId]) REFERENCES [Entity].[EntityAction] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityActionField_EntityField_EntityFieldId] FOREIGN KEY ([EntityFieldId]) REFERENCES [Entity].[EntityField] ([Id])
);

CREATE TABLE [Entity].[EntityFieldActionGroup] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldId] uniqueidentifier NOT NULL,
    [ANDorOR] bit NULL,
    [ProcessOrder] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_EntityFieldActionGroup] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldActionGroup_EntityField_EntityFieldId] FOREIGN KEY ([EntityFieldId]) REFERENCES [Entity].[EntityField] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityFieldConditionGroup] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldId] uniqueidentifier NOT NULL,
    [ConditionForId] uniqueidentifier NOT NULL,
    [ANDorOR] bit NULL,
    [ViewOrder] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityFieldConditionGroup] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldConditionGroup_ConditionFor_ConditionForId] FOREIGN KEY ([ConditionForId]) REFERENCES [Lookup].[ConditionFor] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldConditionGroup_EntityField_EntityFieldId] FOREIGN KEY ([EntityFieldId]) REFERENCES [Entity].[EntityField] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityFieldOption] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldId] uniqueidentifier NOT NULL,
    [IsActive] tinyint NOT NULL,
    [RelatedEntityOptionId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_EntityFieldOption] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldOption_EntityField_EntityFieldId] FOREIGN KEY ([EntityFieldId]) REFERENCES [Entity].[EntityField] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityFieldValue] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldId] uniqueidentifier NOT NULL,
    [EntityPK] uniqueidentifier NOT NULL,
    [Value] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityFieldValue] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldValue_EntityField_EntityFieldId] FOREIGN KEY ([EntityFieldId]) REFERENCES [Entity].[EntityField] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Application].[HistoricalCallPathResult] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [HistoricalCallId] uniqueidentifier NOT NULL,
    [EntityFieldId] uniqueidentifier NOT NULL,
    [Value] nvarchar(max) NULL,
    [ValueString] nvarchar(256) NULL,
    CONSTRAINT [PK_HistoricalCallPathResult] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_HistoricalCallPathResult_EntityField_EntityFieldId] FOREIGN KEY ([EntityFieldId]) REFERENCES [Entity].[EntityField] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_HistoricalCallPathResult_HistoricalCall_HistoricalCallId] FOREIGN KEY ([HistoricalCallId]) REFERENCES [Application].[HistoricalCall] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Application].[AutoContact] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Notes] nvarchar(256) NULL,
    [FullName] nvarchar(256) NULL,
    [PhoneNumber] nvarchar(256) NULL,
    [IdentityNumber] nvarchar(256) NULL,
    [IsSendToAvaya] bit NULL,
    [CategoryId] uniqueidentifier NOT NULL,
    [CampaignId] uniqueidentifier NOT NULL,
    [ScheduledCallId] uniqueidentifier NULL,
    [IsDesable] bit NULL,
    [IsUploadedSuccessfully] bit NOT NULL,
    [FileRow] int NOT NULL,
    [FileName] nvarchar(256) NOT NULL,
    [Description] nvarchar(2000) NULL,
    [DescriptionOthers] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_AutoContact] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AutoContact_Campaign_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [Lookup].[Campaign] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AutoContact_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Lookup].[Category] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AutoContact_ScheduledCall_ScheduledCallId] FOREIGN KEY ([ScheduledCallId]) REFERENCES [Application].[ScheduledCall] ([Id])
);

CREATE TABLE [Entity].[EntityFieldAction] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldActionGroupId] uniqueidentifier NOT NULL,
    [EntityFieldActionTypeId] uniqueidentifier NOT NULL,
    [DynamicFunctionId] uniqueidentifier NULL,
    [ProcessOrder] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    [NameAr] nvarchar(256) NOT NULL,
    [NameEn] nvarchar(256) NOT NULL,
    [ViewOrder] int NOT NULL,
    [IsStatic] bit NOT NULL,
    CONSTRAINT [PK_EntityFieldAction] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldAction_DynamicFunction_DynamicFunctionId] FOREIGN KEY ([DynamicFunctionId]) REFERENCES [Entity].[DynamicFunction] ([Id]),
    CONSTRAINT [FK_EntityFieldAction_EntityFieldActionGroup_EntityFieldActionGroupId] FOREIGN KEY ([EntityFieldActionGroupId]) REFERENCES [Entity].[EntityFieldActionGroup] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldAction_EntityFieldActionType_EntityFieldActionTypeId] FOREIGN KEY ([EntityFieldActionTypeId]) REFERENCES [Entity].[EntityFieldActionType] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityFieldActionGroupConditionGroup] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldActionGroupId] uniqueidentifier NOT NULL,
    [ANDorOR] bit NULL,
    [ViewOrder] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityFieldActionGroupConditionGroup] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldActionGroupConditionGroup_EntityFieldActionGroup_EntityFieldActionGroupId] FOREIGN KEY ([EntityFieldActionGroupId]) REFERENCES [Entity].[EntityFieldActionGroup] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityFieldActionGroupTriggerType] (
    [EntityFieldActionGroupId] uniqueidentifier NOT NULL,
    [TriggerTypeId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_EntityFieldActionGroupTriggerType] PRIMARY KEY ([EntityFieldActionGroupId], [TriggerTypeId]),
    CONSTRAINT [FK_EntityFieldActionGroupTriggerType_EntityFieldActionGroup_EntityFieldActionGroupId] FOREIGN KEY ([EntityFieldActionGroupId]) REFERENCES [Entity].[EntityFieldActionGroup] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionGroupTriggerType_TriggerType_TriggerTypeId] FOREIGN KEY ([TriggerTypeId]) REFERENCES [Lookup].[TriggerType] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityFieldCondition] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldConditionGroupId] uniqueidentifier NOT NULL,
    [FirstSideRelatedToEntityId] uniqueidentifier NOT NULL,
    [FirstSideFieldId] uniqueidentifier NOT NULL,
    [ConditionTypeId] uniqueidentifier NOT NULL,
    [SecondSideRelatedToEntityId] uniqueidentifier NULL,
    [CondetionValue] nvarchar(max) NULL,
    [ANDorOR] bit NULL,
    [ViewOrder] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityFieldCondition] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldCondition_ConditionType_ConditionTypeId] FOREIGN KEY ([ConditionTypeId]) REFERENCES [Lookup].[ConditionType] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldCondition_EntityFieldConditionGroup_EntityFieldConditionGroupId] FOREIGN KEY ([EntityFieldConditionGroupId]) REFERENCES [Entity].[EntityFieldConditionGroup] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldCondition_Entity_FirstSideRelatedToEntityId] FOREIGN KEY ([FirstSideRelatedToEntityId]) REFERENCES [Entity].[Entity] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldCondition_Entity_SecondSideRelatedToEntityId] FOREIGN KEY ([SecondSideRelatedToEntityId]) REFERENCES [Entity].[Entity] ([Id])
);

CREATE TABLE [Entity].[EntityFieldOptionConditionGroup] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldOptionId] uniqueidentifier NOT NULL,
    [ConditionForId] uniqueidentifier NOT NULL,
    [ANDorOR] bit NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityFieldOptionConditionGroup] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldOptionConditionGroup_ConditionFor_ConditionForId] FOREIGN KEY ([ConditionForId]) REFERENCES [Lookup].[ConditionFor] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldOptionConditionGroup_EntityFieldOption_EntityFieldOptionId] FOREIGN KEY ([EntityFieldOptionId]) REFERENCES [Entity].[EntityFieldOption] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Log].[Pim_contact_attempts_history] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [Pim_session_id] bigint NOT NULL,
    [Completion_Code_id] int NOT NULL,
    [Completion_Code_Name] nvarchar(256) NULL,
    [Completion_Code_Name_Ar] nvarchar(256) NULL,
    [Sys_completion_code_id] int NULL,
    [Contact_attempt_time] datetime2 NULL,
    [Last_nw_disposition_time] datetime2 NULL,
    [Call_start_time] datetime2 NULL,
    [Call_completion_time] datetime2 NULL,
    [Address] nvarchar(256) NULL,
    [Agent_id] nvarchar(256) NULL,
    [Campaign_id] int NULL,
    [Campaign_list_id] int NULL,
    [CallDuration] float NOT NULL,
    [IsSuccess] bit NOT NULL,
    [ContactId] uniqueidentifier NULL,
    [UserId] uniqueidentifier NULL,
    [CategoryId] uniqueidentifier NULL,
    [CampaignId] uniqueidentifier NULL,
    [ScheduledCallId] uniqueidentifier NULL,
    [HistoricalCallId] uniqueidentifier NULL,
    [AutoContactId] uniqueidentifier NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_Pim_contact_attempts_history] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Pim_contact_attempts_history_AutoContact_AutoContactId] FOREIGN KEY ([AutoContactId]) REFERENCES [Application].[AutoContact] ([Id]),
    CONSTRAINT [FK_Pim_contact_attempts_history_Campaign_CampaignId] FOREIGN KEY ([CampaignId]) REFERENCES [Lookup].[Campaign] ([Id]),
    CONSTRAINT [FK_Pim_contact_attempts_history_Category_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [Lookup].[Category] ([Id]),
    CONSTRAINT [FK_Pim_contact_attempts_history_Contact_ContactId] FOREIGN KEY ([ContactId]) REFERENCES [Application].[Contact] ([Id]),
    CONSTRAINT [FK_Pim_contact_attempts_history_HistoricalCall_HistoricalCallId] FOREIGN KEY ([HistoricalCallId]) REFERENCES [Application].[HistoricalCall] ([Id]),
    CONSTRAINT [FK_Pim_contact_attempts_history_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [Identity].[User] ([Id])
);

CREATE TABLE [Entity].[EntityFieldActionDynamicFunction] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldActionId] uniqueidentifier NOT NULL,
    [DynamicFunctionId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_EntityFieldActionDynamicFunction] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldActionDynamicFunction_DynamicFunction_DynamicFunctionId] FOREIGN KEY ([DynamicFunctionId]) REFERENCES [Entity].[DynamicFunction] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionDynamicFunction_EntityFieldAction_EntityFieldActionId] FOREIGN KEY ([EntityFieldActionId]) REFERENCES [Entity].[EntityFieldAction] ([Id]) ON DELETE NO ACTION
);

CREATE TABLE [Entity].[EntityFieldActionField] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldActionId] uniqueidentifier NOT NULL,
    [EntityFieldActionTypeRequiredFieldId] uniqueidentifier NOT NULL,
    [EntityFieldId] uniqueidentifier NULL,
    [Value] nvarchar(256) NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityFieldActionField] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldActionField_EntityFieldActionTypeRequiredField_EntityFieldActionTypeRequiredFieldId] FOREIGN KEY ([EntityFieldActionTypeRequiredFieldId]) REFERENCES [Entity].[EntityFieldActionTypeRequiredField] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionField_EntityFieldAction_EntityFieldActionId] FOREIGN KEY ([EntityFieldActionId]) REFERENCES [Entity].[EntityFieldAction] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionField_EntityField_EntityFieldId] FOREIGN KEY ([EntityFieldId]) REFERENCES [Entity].[EntityField] ([Id])
);

CREATE TABLE [Entity].[EntityFieldActionGroupCondition] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldActionGroupConditionGroupId] uniqueidentifier NOT NULL,
    [FirstSideRelatedToEntityId] uniqueidentifier NOT NULL,
    [FirstSideFieldId] uniqueidentifier NOT NULL,
    [ConditionTypeId] uniqueidentifier NOT NULL,
    [SecondSideRelatedToEntityId] uniqueidentifier NULL,
    [CondetionValue] nvarchar(256) NULL,
    [ANDorOR] bit NULL,
    [ViewOrder] int NOT NULL,
    [ProcessOrder] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityFieldActionGroupCondition] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldActionGroupCondition_ConditionType_ConditionTypeId] FOREIGN KEY ([ConditionTypeId]) REFERENCES [Lookup].[ConditionType] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionGroupCondition_EntityFieldActionGroupConditionGroup_EntityFieldActionGroupConditionGroupId] FOREIGN KEY ([EntityFieldActionGroupConditionGroupId]) REFERENCES [Entity].[EntityFieldActionGroupConditionGroup] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionGroupCondition_Entity_FirstSideRelatedToEntityId] FOREIGN KEY ([FirstSideRelatedToEntityId]) REFERENCES [Entity].[Entity] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionGroupCondition_Entity_SecondSideRelatedToEntityId] FOREIGN KEY ([SecondSideRelatedToEntityId]) REFERENCES [Entity].[Entity] ([Id])
);

CREATE TABLE [Entity].[EntityFieldOptionCondition] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldOptionConditionGroupId] uniqueidentifier NOT NULL,
    [FirstSideRelatedToEntityId] uniqueidentifier NOT NULL,
    [FirstSideFieldId] uniqueidentifier NOT NULL,
    [ConditionTypeId] uniqueidentifier NOT NULL,
    [SecondSideRelatedToEntityId] uniqueidentifier NULL,
    [CondetionValue] nvarchar(max) NULL,
    [ANDorOR] bit NULL,
    [ViewOrder] int NOT NULL,
    [CreatedOn] datetime2 NOT NULL DEFAULT (getDate()),
    [CreatedByUserId] uniqueidentifier NULL,
    [LastModifiedOn] datetime2 NULL,
    [LastModifiedByUserId] uniqueidentifier NULL,
    [StateCode] tinyint NOT NULL,
    CONSTRAINT [PK_EntityFieldOptionCondition] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldOptionCondition_ConditionType_ConditionTypeId] FOREIGN KEY ([ConditionTypeId]) REFERENCES [Lookup].[ConditionType] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldOptionCondition_EntityFieldOptionConditionGroup_EntityFieldOptionConditionGroupId] FOREIGN KEY ([EntityFieldOptionConditionGroupId]) REFERENCES [Entity].[EntityFieldOptionConditionGroup] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldOptionCondition_Entity_FirstSideRelatedToEntityId] FOREIGN KEY ([FirstSideRelatedToEntityId]) REFERENCES [Entity].[Entity] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldOptionCondition_Entity_SecondSideRelatedToEntityId] FOREIGN KEY ([SecondSideRelatedToEntityId]) REFERENCES [Entity].[Entity] ([Id])
);

CREATE TABLE [Entity].[EntityFieldActionDynamicFunctionParameter] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldActionId] uniqueidentifier NOT NULL,
    [DynamicFunctionParameterId] uniqueidentifier NOT NULL,
    [EntityFieldId] uniqueidentifier NULL,
    [Value] nvarchar(256) NULL,
    [EntityFieldActionDynamicFunctionId] uniqueidentifier NULL,
    CONSTRAINT [PK_EntityFieldActionDynamicFunctionParameter] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldActionDynamicFunctionParameter_DynamicFunctionParameter_DynamicFunctionParameterId] FOREIGN KEY ([DynamicFunctionParameterId]) REFERENCES [Entity].[DynamicFunctionParameter] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionDynamicFunctionParameter_EntityFieldActionDynamicFunction_EntityFieldActionDynamicFunctionId] FOREIGN KEY ([EntityFieldActionDynamicFunctionId]) REFERENCES [Entity].[EntityFieldActionDynamicFunction] ([Id]),
    CONSTRAINT [FK_EntityFieldActionDynamicFunctionParameter_EntityFieldAction_EntityFieldActionId] FOREIGN KEY ([EntityFieldActionId]) REFERENCES [Entity].[EntityFieldAction] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionDynamicFunctionParameter_EntityField_EntityFieldId] FOREIGN KEY ([EntityFieldId]) REFERENCES [Entity].[EntityField] ([Id])
);

CREATE TABLE [Entity].[EntityFieldActionDynamicFunctionResult] (
    [Id] uniqueidentifier NOT NULL DEFAULT (newsequentialid()),
    [EntityFieldActionId] uniqueidentifier NOT NULL,
    [DynamicFunctionResultId] uniqueidentifier NOT NULL,
    [EntityFieldId] uniqueidentifier NULL,
    [IsResultToNotification] bit NULL,
    [IsPathResult] bit NULL,
    [IsPathValue] bit NULL,
    [EntityFieldActionDynamicFunctionId] uniqueidentifier NULL,
    CONSTRAINT [PK_EntityFieldActionDynamicFunctionResult] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_EntityFieldActionDynamicFunctionResult_DynamicFunctionResult_DynamicFunctionResultId] FOREIGN KEY ([DynamicFunctionResultId]) REFERENCES [Entity].[DynamicFunctionResult] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionDynamicFunctionResult_EntityFieldActionDynamicFunction_EntityFieldActionDynamicFunctionId] FOREIGN KEY ([EntityFieldActionDynamicFunctionId]) REFERENCES [Entity].[EntityFieldActionDynamicFunction] ([Id]),
    CONSTRAINT [FK_EntityFieldActionDynamicFunctionResult_EntityFieldAction_EntityFieldActionId] FOREIGN KEY ([EntityFieldActionId]) REFERENCES [Entity].[EntityFieldAction] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_EntityFieldActionDynamicFunctionResult_EntityField_EntityFieldId] FOREIGN KEY ([EntityFieldId]) REFERENCES [Entity].[EntityField] ([Id])
);

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[CallStatus]'))
    SET IDENTITY_INSERT [Lookup].[CallStatus] ON;
INSERT INTO [Lookup].[CallStatus] ([Id], [CreatedByUserId], [CreatedOn], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [NameAr], [NameEn], [StateCode], [ViewOrder])
VALUES ('0c027c7d-59a2-4319-a876-b22015611f97', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مجدولة الآن', N'Queued In System', CAST(1 AS tinyint), 1),
('123c61d3-de6b-4385-bb40-0ce35ecb4625', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'غير ناجحة (التنبؤي)', N'Scheduled In Dialer', CAST(1 AS tinyint), 1),
('29dc61d3-de6b-4385-bb40-0ce35ecb4625', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مجدولة تاريخياً (التنبؤي)', N'Scheduled In Dialer', CAST(1 AS tinyint), 1),
('2cd4cc0e-afbd-4a72-b930-8911662a4fcf', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'إعادة اتصال', N'Recall', CAST(1 AS tinyint), 1),
('75bad3f5-23cb-47e7-8485-a83e14e325d3', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مسندة', N'Assigned', CAST(1 AS tinyint), 1),
('9d7064b9-a41a-4b76-9889-d26750f3eca6', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مجدولة الآن (التنبؤي)', N'Queued In Dialer', CAST(1 AS tinyint), 1),
('b8151e6f-6415-4b46-9b74-5dae2e47d072', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'ناجحة', N'Success', CAST(1 AS tinyint), 1),
('d252adcd-cb7c-45bb-a1f7-d7905a14e348', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مجدولة تاريخياً', N'Scheduled In System', CAST(1 AS tinyint), 1),
('df1523df-5fc3-41fc-a2d0-b3937ca4228f', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'غير ناجحة', N'Not Success', CAST(1 AS tinyint), 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[CallStatus]'))
    SET IDENTITY_INSERT [Lookup].[CallStatus] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[CallType]'))
    SET IDENTITY_INSERT [Lookup].[CallType] ON;
INSERT INTO [Lookup].[CallType] ([Id], [CreatedByUserId], [CreatedOn], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [NameAr], [NameEn], [StateCode], [ViewOrder])
VALUES ('331c1515-23d2-452b-82f5-5f2999582f8d', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مكالمة تحصيل - متابعة', N'Collecting Call Followup', CAST(1 AS tinyint), 1),
('3ac144c5-5ea4-4ca3-a8a3-0b2f173dd6db', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مكالمة تحصيل', N'Collecting Call', CAST(1 AS tinyint), 1),
('b22c1515-23d2-452b-82f5-5f2999582f8d', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مكالمة تبليغ', N'Notification Call', CAST(1 AS tinyint), 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[CallType]'))
    SET IDENTITY_INSERT [Lookup].[CallType] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[ConditionFor]'))
    SET IDENTITY_INSERT [Lookup].[ConditionFor] ON;
INSERT INTO [Lookup].[ConditionFor] ([Id], [CreatedByUserId], [CreatedOn], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [NameAr], [NameEn], [StateCode], [ViewOrder])
VALUES ('32ce529a-107e-4242-bd48-00d87d85e68c', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'عرض', N'Show', CAST(1 AS tinyint), 1),
('5e6a7ddf-d4a2-49d8-81b1-195bc9eb63b6', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'تعطيل', N'Disabel', CAST(1 AS tinyint), 1),
('8ce24129-c34f-4ed2-94ae-1a8d8fb81182', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'إجباري', N'Required', CAST(1 AS tinyint), 1),
('b1d9a26b-745a-4a5e-bfb7-b3519a7c0e47', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'اختيار', N'Select', CAST(1 AS tinyint), 1),
('ce8d37c5-66c8-41e9-ade0-cb8d6d13ffa9', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'تنفيذ', N'Execute', CAST(1 AS tinyint), 1),
('df704671-910c-4625-8ce7-577aa2ca95ad', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'للقراءة فقط', N'ReadOnly', CAST(1 AS tinyint), 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[ConditionFor]'))
    SET IDENTITY_INSERT [Lookup].[ConditionFor] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[ConditionType]'))
    SET IDENTITY_INSERT [Lookup].[ConditionType] ON;
INSERT INTO [Lookup].[ConditionType] ([Id], [CreatedByUserId], [CreatedOn], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [NameAr], [NameEn], [StateCode], [ViewOrder])
VALUES ('059f4279-53da-4d31-bac3-cf75092b9e44', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'يحتوي', N'Contain', CAST(1 AS tinyint), 1),
('0f979f1c-4419-420e-81d2-0ce99048049f', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'غير فارغ', N'Not Null', CAST(1 AS tinyint), 1),
('45fa4a17-8a36-4a2b-a5fb-c389f65c6bf9', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'ضمن', N'In', CAST(1 AS tinyint), 1),
('47d75e03-d7a1-467f-a870-5cf451b552a6', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'فارغ', N'Null', CAST(1 AS tinyint), 1),
('55899e39-2eb5-42c4-a090-f719457b865f', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أكبر من أو يساوي', N'More Than Or Equal', CAST(1 AS tinyint), 1),
('7cbdb20f-8790-4193-8bca-4adb1ea743a9', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'يساوي', N'Equal', CAST(1 AS tinyint), 1),
('b47b64a4-da48-4d66-9972-532c8f23eec3', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أقل من', N'Less Than', CAST(1 AS tinyint), 1),
('c03cfa6a-8125-458b-85dc-babc046417bf', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أكبر من', N'MoreThan', CAST(1 AS tinyint), 1),
('df540314-dfa9-4a2d-bc82-863bbb77b271', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'لا يساوي', N'Not Equal', CAST(1 AS tinyint), 1),
('f29b0cea-10f5-4a62-90e2-6377f644b2a3', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أقل من أو يساوي', N'Less Than Or Equal', CAST(1 AS tinyint), 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[ConditionType]'))
    SET IDENTITY_INSERT [Lookup].[ConditionType] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'EntityId', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Entity].[EntityFieldActionType]'))
    SET IDENTITY_INSERT [Entity].[EntityFieldActionType] ON;
INSERT INTO [Entity].[EntityFieldActionType] ([Id], [CreatedByUserId], [CreatedOn], [EntityId], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [NameAr], [NameEn], [StateCode], [ViewOrder])
VALUES ('1f4398fe-7940-4310-8149-40f71b5bb97b', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', NULL, CAST(1 AS bit), NULL, NULL, N'تنفيذ إجراء ديناميكي', N'Execute Dynamic Function', CAST(1 AS tinyint), 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'EntityId', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Entity].[EntityFieldActionType]'))
    SET IDENTITY_INSERT [Entity].[EntityFieldActionType] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'SchemaName', N'StateCode', N'TabelName', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Entity].[EntityType]'))
    SET IDENTITY_INSERT [Entity].[EntityType] ON;
INSERT INTO [Entity].[EntityType] ([Id], [CreatedByUserId], [CreatedOn], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [NameAr], [NameEn], [SchemaName], [StateCode], [TabelName], [ViewOrder])
VALUES ('04e4943a-0d56-4ea9-b878-926d05c435f9', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'صلاحيات المستخدمين', N'User Permission', N'Identity', CAST(1 AS tinyint), N'UserPermission', 0),
('1a9b70a2-1d02-49bc-9aeb-64cee6cb9b09', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'حلول القرض', N'Loan Time Status', N'Lookup', CAST(1 AS tinyint), N'LoanTimeStatus', 0),
('1c28bc30-d216-4812-a292-8e8e2c02c5e1', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'التصنيفات', N'Category', N'Lookup', CAST(1 AS tinyint), N'Category', 0),
('1e648ce3-267c-44ad-940a-9aa3148a8519', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الحملات', N'Campaign', N'Lookup', CAST(1 AS tinyint), N'Campaign', 0),
('1fcc2bfb-bb08-44f3-b99e-804c6ab5df8d', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'سجلات تحديثات العقود', N'Contract History', N'Log', CAST(1 AS tinyint), N'ContractHistory', 0),
('25254ee1-f98c-4800-a3be-bff0f306b6bf', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أنواع التعثرات', N'Stumble Type', N'Lookup', CAST(1 AS tinyint), N'StumbleType', 0),
('2632b95e-2ff7-4b4f-9422-3ecebd856fc9', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أنواع الحقول', N'Field Type', N'Lookup', CAST(1 AS tinyint), N'FieldType', 0),
('296f3487-44a7-4237-96d0-c2aeaa7ecaeb', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'المستخدمين', N'User', N'Identity', CAST(1 AS tinyint), N'User', 0),
('316168b0-dd10-457a-9689-a9ce82be9073', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أجزاء معايير تقييم المكالمات', N'Call Quality Criteria Part', N'Application', CAST(1 AS tinyint), N'CallQualityCriteriaPart', 0),
('357ab406-6e13-48f1-be88-6c1cbd97654d', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الأجناس', N'Gender', N'Lookup', CAST(1 AS tinyint), N'Gender', 0),
('357d1ce2-3631-4021-9f49-ddb8be7fbd0f', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مسارات التصنيفات', N'Category Path', N'Lookup', CAST(1 AS tinyint), N'CategoryPath', 0),
('376ccb5d-408f-4c15-b0f6-289f5b4c2f99', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الفرق', N'Team', N'Lookup', CAST(1 AS tinyint), N'Team', 0),
('38920507-73c0-4035-8639-d4f66bee9952', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'صلاحيات الأدوار الوظيفية', N'Role Permission', N'Identity', CAST(1 AS tinyint), N'RolePermission', 0),
('38a84837-16ce-4fbb-99b2-5a595c95ecf0', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'المعلومات الشخصية', N'Personal Info', N'Application', CAST(1 AS tinyint), N'PersonalInfo', 0),
('38ae3821-99b4-4167-813f-a51c9a36af92', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'التعليقات على المكالمات التاريخية', N'Historical Call Comment', N'Application', CAST(1 AS tinyint), N'HistoricalCallComment', 0),
('4605c6b9-afdc-4baa-bac9-2ed38a16cf8e', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'قطاع العمل', N'Employer Sector', N'Lookup', CAST(1 AS tinyint), N'EmployerSector', 0),
('48564202-568f-4e84-94d0-518cc61631cd', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أنواع الرضى', N'Satisfaction', N'Lookup', CAST(1 AS tinyint), N'Satisfaction', 0),
('50e6cef1-da4e-4bb3-8e26-c8d80ce41e20', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الجنسيات', N'Nationality', N'Lookup', CAST(1 AS tinyint), N'Nationality', 0),
('60c47180-b24f-47ca-bd37-77edfaf257f0', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أنواع تسجيلات المستخدمين', N'Registration Type', N'Lookup', CAST(1 AS tinyint), N'RegistrationType', 0),
('63e0a8a6-43e3-4718-b08a-e0f80f7f7f56', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'المكالمات التاريخية', N'Historical Call', N'Application', CAST(1 AS tinyint), N'HistoricalCall', 0),
('6509294e-df52-4524-826c-10e58e5b67d5', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الإعدادات', N'Setting', N'Application', CAST(1 AS tinyint), N'Setting', 0),
('6fc1c72c-780a-4877-bf65-803f913d5190', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'حالات المكالمات', N'Call Status', N'Lookup', CAST(1 AS tinyint), N'CallStatus', 0),
('6ffe76fa-7c3b-4ff9-9fb5-e9851beb5327', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الشروط لـ', N'Condition For', N'Lookup', CAST(1 AS tinyint), N'ConditionFor', 0),
('708593c8-baca-409c-b9be-325e05f48123', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أنواع الأحداث على حقول الكيانات', N'Entity Field Action Type', N'Entity', CAST(1 AS tinyint), N'EntityFieldActionType', 0),
('70ebe78c-f361-46e6-be83-faf7affd693e', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'نوع العقد', N'Contract Type', N'Lookup', CAST(1 AS tinyint), N'ContractStatus', 0),
('73218b82-b075-4b0d-a3f0-fcb4a456e96e', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'معايير تقييم المكالمة', N'Call Quality Criteria', N'Application', CAST(1 AS tinyint), N'CallQualityCriteria', 0),
('77527367-7cfd-416c-be58-9780bdad879b', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'سجلات تحديثات المعلومات الشخصية', N'Personal Info Log', N'Log', CAST(1 AS tinyint), N'PersonalInfoLog', 0),
('7c535ca0-56c0-4b53-a3b3-c66ef12d389e', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أنواع المكالمات', N'Call Type', N'Lookup', CAST(1 AS tinyint), N'CallType', 0),
('7e532c9d-8101-4294-8c73-cf04f0c64c95', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'فرق المستخدمين', N'User Teams', N'Identity', CAST(1 AS tinyint), N'UserTeams', 0),
('83f6c13b-64c4-4ad1-af46-f55a7118e2c0', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'المكالمات المجدولة', N'Scheduled Call', N'Application', CAST(1 AS tinyint), N'ScheduledCall', 0),
('872fb63a-a1ab-4031-ac30-5653b356fde9', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'العقود', N'Contract', N'Application', CAST(1 AS tinyint), N'Contract', 0),
('90431599-2fbf-4c2c-98ee-d20c469551bc', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'سجلات تحميل المستفيدين', N'Contact Uploading Log', N'Log', CAST(1 AS tinyint), N'ContactUploadingLog', 0),
('90e20a39-b72b-418b-beff-658ad0fbd7b5', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مسارات التصنيف للمستخدمين', N'User Category Path', N'Identity', CAST(1 AS tinyint), N'UserCategoryPath', 0),
('91b2ee8a-4126-4589-901b-993688d9efda', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'فاتورة المكالمة', N'Call Bill', N'Application', CAST(1 AS tinyint), N'CallBill', 0),
('92aabbd9-b890-4118-9ce8-c8e6862dc11e', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الصلاحيات', N'Permission', N'Lookup', CAST(1 AS tinyint), N'Permission', 0),
('96bd359e-5060-41b7-b15c-041245df0a92', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'العملاء', N'Contacts', N'Application', CAST(1 AS tinyint), N'Contact', 0),
('a56cec1b-44e5-4fa3-b42d-485ec5eb37aa', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الدوال الديناميكية', N'Dynamic Function', N'Entity', CAST(1 AS tinyint), N'DynamicFunction', 0),
('a596f09b-e63f-42d8-86ca-875fd6eaf6d3', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'التقارير الديناميكية', N'Dynamic Report', N'Entity', CAST(1 AS tinyint), N'DynamicReport', 0),
('b3918956-0106-4c6a-8e79-b02a5d9759c5', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أنواع الإعدادات', N'Setting Type', N'Lookup', CAST(1 AS tinyint), N'SettingType', 0),
('b67c5548-7098-48de-a86c-2ced19a40471', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الأدوار الوظيفية', N'Role', N'Identity', CAST(1 AS tinyint), N'Role', 0),
('b730380a-8f15-423a-884f-c2249eb2d58d', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الكيانات', N'Entity', N'Entity', CAST(1 AS tinyint), N'Entity', 0),
('ba4c4a9e-7a21-4183-ae97-4bc322581b20', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'إجراءات النظام', N'System Progress', N'Application', CAST(1 AS tinyint), N'SystemProgress', 0);
INSERT INTO [Entity].[EntityType] ([Id], [CreatedByUserId], [CreatedOn], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [NameAr], [NameEn], [SchemaName], [StateCode], [TabelName], [ViewOrder])
VALUES ('bc800b0e-8743-4e3d-86a3-7ce3946bc76b', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'بوابات الدفع', N'Payment Gateway', N'Lookup', CAST(1 AS tinyint), N'PaymentGateway', 0),
('bec9374f-79bd-4b85-a476-5ac32f5e7e2f', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'المدفوعات', N'Payment', N'Application', CAST(1 AS tinyint), N'Payment', 0),
('c32068b2-e391-460d-9e08-1d92bc33746b', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الأولويات', N'Priority', N'Lookup', CAST(1 AS tinyint), N'Priority', 0),
('cad78edc-6da3-4b03-8cfc-13ddcc229440', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'تقييم المكالمة', N'Call Quality', N'Application', CAST(1 AS tinyint), N'CallQuality', 0),
('caec39b5-2bfe-43d7-8fb8-ccd455f66312', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'المدن', N'City', N'Lookup', CAST(1 AS tinyint), N'City', 0),
('caecbb8c-a116-49c8-8d05-1e75ca9b573f', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أنواع الشروط', N'Condition Type', N'Lookup', CAST(1 AS tinyint), N'ConditionType', 0),
('cb444b0b-2c22-41bd-86db-131e401e5f71', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'طرق الدفع', N'Payment Method', N'Lookup', CAST(1 AS tinyint), N'PaymentMethod', 0),
('cb4ef3ce-fae8-4828-881c-f4b02f96f855', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أنواع الأحداث على الكيانات', N'Entity Action Type', N'Entity', CAST(1 AS tinyint), N'EntityActionType', 0),
('d1fded5f-88ca-4537-80f8-ddb6bf5b6ed5', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'إعدادات المستخدمين', N'User Setting', N'Identity', CAST(1 AS tinyint), N'UserSetting', 0),
('dacf4e52-019e-4bda-ae72-f22b135cc9b8', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'حالة العقد', N'Contract Status', N'Lookup', CAST(1 AS tinyint), N'ContractType', 0),
('dd6a0c1a-9c1b-4f8b-af33-1907c0e6e024', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'أنواع الإجراءات', N'Trigger Type', N'Lookup', CAST(1 AS tinyint), N'TriggerType', 0),
('e857c3ca-be15-41af-8f93-306b94c85cfc', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'جهة العمل', N'Employer Type', N'Lookup', CAST(1 AS tinyint), N'EmployerType', 0),
('e8aa01af-6578-4912-b9cb-6601779ec1b8', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'الملاءة المالية', N'Solvency', N'Lookup', CAST(1 AS tinyint), N'Solvency', 0),
('f0a695d9-a73c-4e2c-992d-c23c85853e70', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'البلاد', N'Country', N'Lookup', CAST(1 AS tinyint), N'Country', 0),
('f7a5b0cb-b0c7-4744-81c3-d9b3f67a6612', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'حالة التقاعد', N'Retirement Status', N'Lookup', CAST(1 AS tinyint), N'RetirementStatus', 0),
('f91ccfaf-9260-4baf-b9df-9f27715ac092', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'سجلات إرسال الرسائل النصية', N'SMS Sent Log', N'Log', CAST(1 AS tinyint), N'SMSSentLog', 0),
('f9ffd0b6-1223-43a9-b214-d5d0b9498902', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'حالة التأمينات', N'Insurance Status', N'Lookup', CAST(1 AS tinyint), N'InsuranceStatus', 0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'SchemaName', N'StateCode', N'TabelName', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Entity].[EntityType]'))
    SET IDENTITY_INSERT [Entity].[EntityType] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[FieldType]'))
    SET IDENTITY_INSERT [Lookup].[FieldType] ON;
INSERT INTO [Lookup].[FieldType] ([Id], [CreatedByUserId], [CreatedOn], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [NameAr], [NameEn], [StateCode], [ViewOrder])
VALUES ('061beaca-01b1-443a-a5f9-bd636b8ee9b1', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'ملف', N'File', CAST(1 AS tinyint), 1),
('0caa25d9-befb-4096-9041-c05e7b4da188', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'خيارات متعددة (CheckBox)', N'CheckBox Group', CAST(1 AS tinyint), 1),
('24a3e2ce-c8d2-485d-9bfb-028ad5ae5444', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'وقت', N'Time', CAST(1 AS tinyint), 1),
('2bccee4a-8236-486e-9691-da019d679600', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'رقم', N'Number', CAST(1 AS tinyint), 1),
('45de289b-67b3-406f-aa95-b01a857fdf74', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'عنوان', N'Label', CAST(1 AS tinyint), 1),
('61e80126-233e-4143-94bc-e906c1e64b03', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'نص كبير', N'Text Area', CAST(1 AS tinyint), 1),
('66326b14-7fa5-45f4-b3df-92f364b146d8', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'خيار اختياري (CheckBox)', N'CheckBox', CAST(1 AS tinyint), 1),
('92a1f535-6c86-4489-a494-afcd1165334a', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'زر', N'Button', CAST(1 AS tinyint), 1),
('9eaed8a2-517b-48c8-bfb8-eb2344a79804', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'خيارات متعددة (Select)', N'MultibelSelect', CAST(1 AS tinyint), 1),
('b040939f-d7eb-47cc-9a5a-f063db7fdd8e', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'قائمة نصية', N'View List', CAST(1 AS tinyint), 1),
('bc557ce6-adb6-4a98-9214-639534862014', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'نص', N'Text', CAST(1 AS tinyint), 1),
('d448dd89-168e-47eb-9425-36a4074cd853', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'اختيار واحد (Select)', N'One Select', CAST(1 AS tinyint), 1),
('d4730e56-dcc3-42e8-af4a-a6b66edbb728', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'تاريخ ووقت', N'DateTime', CAST(1 AS tinyint), 1),
('f9e4efb5-f7c4-44d5-9c35-febfbfc7f834', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'تاريخ', N'Date', CAST(1 AS tinyint), 1),
('fb14e732-8d25-4ffb-bd63-b5e6e09cf231', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'اختيار واحد (Radio)', N'Radio Button', CAST(1 AS tinyint), 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[FieldType]'))
    SET IDENTITY_INSERT [Lookup].[FieldType] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'CreatedByUserId', N'CreatedOn', N'Email', N'FullNameAr', N'IdentityNumber', N'LastModifiedByUserId', N'LastModifiedOn', N'Notes', N'PhoneNumber', N'PhoneNumber2', N'StateCode') AND [object_id] = OBJECT_ID(N'[Application].[PersonalInfo]'))
    SET IDENTITY_INSERT [Application].[PersonalInfo] ON;
INSERT INTO [Application].[PersonalInfo] ([Id], [CityId], [CreatedByUserId], [CreatedOn], [Email], [FullNameAr], [IdentityNumber], [LastModifiedByUserId], [LastModifiedOn], [Notes], [PhoneNumber], [PhoneNumber2], [StateCode])
VALUES ('3abfa071-e941-48e6-a492-b6cad5debf61', NULL, NULL, '2021-09-10T00:00:00.0000000', N'System@System', N'النظام', NULL, NULL, NULL, NULL, NULL, NULL, CAST(1 AS tinyint)),
('d741da85-bd74-42cc-8d22-8176f49580e6', NULL, NULL, '2021-09-10T00:00:00.0000000', N'POMApplicationUser@System', N'نظام الاتصال التنبؤي', NULL, NULL, NULL, NULL, NULL, NULL, CAST(1 AS tinyint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CityId', N'CreatedByUserId', N'CreatedOn', N'Email', N'FullNameAr', N'IdentityNumber', N'LastModifiedByUserId', N'LastModifiedOn', N'Notes', N'PhoneNumber', N'PhoneNumber2', N'StateCode') AND [object_id] = OBJECT_ID(N'[Application].[PersonalInfo]'))
    SET IDENTITY_INSERT [Application].[PersonalInfo] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'Number', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[Priority]'))
    SET IDENTITY_INSERT [Lookup].[Priority] ON;
INSERT INTO [Lookup].[Priority] ([Id], [CreatedByUserId], [CreatedOn], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [NameAr], [NameEn], [Number], [StateCode], [ViewOrder])
VALUES ('5f2c9033-4842-4797-8da8-c3dffb331609', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مهم جداً', N'Important', 3, CAST(1 AS tinyint), 3),
('5f2c90ee-4842-4797-8da8-c3dffb331609', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'استثنائي جداً', N'Very Special', 1, CAST(1 AS tinyint), 1),
('5f2ca633-4842-4797-8da8-c3dffb331609', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'استثنائي', N'Special', 2, CAST(1 AS tinyint), 2),
('64cd40dd-747a-46c7-a91d-123febad6d44', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'غير مهم', N'Low', 6, CAST(1 AS tinyint), 6),
('6aeb7f2a-5a60-4086-8320-55120317806e', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'عادي', N'Normal', 5, CAST(1 AS tinyint), 5),
('71bd4bae-361c-41a9-bd54-22c29eea602a', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'غير مهم أبداً', N'Very Low', 7, CAST(1 AS tinyint), 7),
('b44b633e-a94a-4dac-a093-5650aa8184eb', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'مهم', N'Important', 4, CAST(1 AS tinyint), 4);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'Number', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[Priority]'))
    SET IDENTITY_INSERT [Lookup].[Priority] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'IsDefualt', N'IsStatic', N'Name', N'NameAr', N'NormalizedName', N'StateCode') AND [object_id] = OBJECT_ID(N'[Identity].[Role]'))
    SET IDENTITY_INSERT [Identity].[Role] ON;
INSERT INTO [Identity].[Role] ([Id], [ConcurrencyStamp], [IsDefualt], [IsStatic], [Name], [NameAr], [NormalizedName], [StateCode])
VALUES ('24e65b31-a815-4fb0-a5fa-4b78aab03c72', N'4f421dc4-9f03-4d54-898a-caf3ad286a2d', CAST(0 AS bit), CAST(1 AS bit), N'SuperAdmin', N'مسؤول النظام', N'superadmin', CAST(0 AS tinyint)),
('5918287c-140d-4938-a8ee-d3a3099ec957', N'6c4191c2-5d95-40d6-bccc-006b7faf8a16', CAST(0 AS bit), CAST(1 AS bit), N'Admin', N'المسؤول', N'admin', CAST(1 AS tinyint)),
('6fdd3e8a-ebfc-4fe5-8a48-ed2bde9fb2ad', N'f9cb65bf-3071-42ff-a952-a166e99077e3', CAST(0 AS bit), CAST(1 AS bit), N'Leader', N'قائد الفريق', N'leader', CAST(1 AS tinyint)),
('746f79ee-bc4a-4e58-95d2-01c73cf3a868', N'10a464f7-65af-4423-9325-49482bf51fed', CAST(0 AS bit), CAST(1 AS bit), N'Reporter', N'منظم التقارير', N'reporter', CAST(0 AS tinyint)),
('93b91e52-5850-4190-9e87-2a1bfbd81910', N'e3f6e940-5380-41eb-98be-601439d614e9', CAST(0 AS bit), CAST(1 AS bit), N'Supervisor', N'المشرف', N'supervisor', CAST(1 AS tinyint)),
('ad0b3b57-295f-4312-bba1-b09a11865237', N'2bb13d4b-8187-4420-998a-335182d1a71e', CAST(1 AS bit), CAST(1 AS bit), N'Employee', N'موظف', N'employee', CAST(1 AS tinyint)),
('b57d5da1-98e7-4c98-ac00-104919cb8e8d', N'1e0a9742-eedd-4389-a1b3-5c9fd3e6ca61', CAST(0 AS bit), CAST(1 AS bit), N'System', N'النظام', N'system', CAST(0 AS tinyint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'ConcurrencyStamp', N'IsDefualt', N'IsStatic', N'Name', N'NameAr', N'NormalizedName', N'StateCode') AND [object_id] = OBJECT_ID(N'[Identity].[Role]'))
    SET IDENTITY_INSERT [Identity].[Role] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[TriggerType]'))
    SET IDENTITY_INSERT [Lookup].[TriggerType] ON;
INSERT INTO [Lookup].[TriggerType] ([Id], [CreatedByUserId], [CreatedOn], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [NameAr], [NameEn], [StateCode], [ViewOrder])
VALUES ('125572ee-3743-4d03-b4f8-f003fa3d22ad', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'عند التحديث', N'On Update', CAST(1 AS tinyint), 1),
('2bab8ff2-8ddf-4691-b704-7c29526605f2', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'عند الإنشاء', N'On Create', CAST(1 AS tinyint), 1),
('2fdd7ad8-a254-490e-ba65-cd4971811658', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'عند الحذف', N'On Delete', CAST(1 AS tinyint), 1),
('4ea813d4-a0c6-4ee2-97d6-8f5756e23896', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'عند التعطيل', N'On DeActivate', CAST(1 AS tinyint), 1),
('51a7be15-439d-4300-aea3-0b6c9dd91b57', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'عند التفعيل', N'On Activate', CAST(1 AS tinyint), 1),
('78055fed-079a-43b2-a0b3-69fc7f38744d', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'عند الإرسال', N'On Submit', CAST(1 AS tinyint), 1),
('817e4b7f-c425-4774-ba93-ca4aedea160d', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'عند الضغط على', N'On Click', CAST(1 AS tinyint), 1),
('8e40406e-7ab8-405c-b6c8-3e4cd7db5ef3', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', CAST(1 AS bit), NULL, NULL, N'عند الاستعراض', N'On View', CAST(1 AS tinyint), 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Lookup].[TriggerType]'))
    SET IDENTITY_INSERT [Lookup].[TriggerType] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'EntityTypeId', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Entity].[EntityActionType]'))
    SET IDENTITY_INSERT [Entity].[EntityActionType] ON;
INSERT INTO [Entity].[EntityActionType] ([Id], [CreatedByUserId], [CreatedOn], [EntityTypeId], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [NameAr], [NameEn], [StateCode], [ViewOrder])
VALUES ('0280d3e4-0b91-4a09-af6c-9493365722e9', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', '357d1ce2-3631-4021-9f49-ddb8be7fbd0f', CAST(1 AS bit), NULL, NULL, N'حفظ نتيجة المكالمة بحالة ناجحة', N'Save Call In Success Status', CAST(1 AS tinyint), 1),
('090e1ae7-3878-489a-ab85-8c9affb4a913', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', '357d1ce2-3631-4021-9f49-ddb8be7fbd0f', CAST(1 AS bit), NULL, NULL, N'جدولة مكالمة جديدة', N'Schedule New Call', CAST(1 AS tinyint), 1),
('12121212-1212-42d1-a92a-aa3e93867f79', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', '357d1ce2-3631-4021-9f49-ddb8be7fbd0f', CAST(1 AS bit), NULL, NULL, N'إشعار بإنشاء فاتورة', N'Notify On Bill Created', CAST(1 AS tinyint), 1),
('63a13eb8-3949-42d1-a92a-aa3e93867f79', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', '357d1ce2-3631-4021-9f49-ddb8be7fbd0f', CAST(1 AS bit), NULL, NULL, N'حفظ نتيجة المكالمة بحالة إعادة اتصال', N'Save Call In Recall Status', CAST(1 AS tinyint), 1),
('d8ee0ba8-5f2a-4691-a388-8616dbdf39ba', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', '357d1ce2-3631-4021-9f49-ddb8be7fbd0f', CAST(1 AS bit), NULL, NULL, N'حفظ نتيجة المكالمة بحالة غير ناجحة', N'Save Call In Not Success Status', CAST(1 AS tinyint), 1);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'EntityTypeId', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'NameAr', N'NameEn', N'StateCode', N'ViewOrder') AND [object_id] = OBJECT_ID(N'[Entity].[EntityActionType]'))
    SET IDENTITY_INSERT [Entity].[EntityActionType] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'CreatedByUserId', N'CreatedOn', N'Email', N'EmailConfirmed', N'EmployeeNumber', N'Extension', N'IsHasSpecialPermissions', N'IsLoggedIn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'LatestLoggedInDateTime', N'LatestPasswordChangedDateTime', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PasswordHint', N'PersonalInfoId', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'StateCode', N'TwoFactorEnabled', N'UserName', N'WrongPassTry') AND [object_id] = OBJECT_ID(N'[Identity].[User]'))
    SET IDENTITY_INSERT [Identity].[User] ON;
INSERT INTO [Identity].[User] ([Id], [AccessFailedCount], [ConcurrencyStamp], [CreatedByUserId], [CreatedOn], [Email], [EmailConfirmed], [EmployeeNumber], [Extension], [IsHasSpecialPermissions], [IsLoggedIn], [IsStatic], [LastModifiedByUserId], [LastModifiedOn], [LatestLoggedInDateTime], [LatestPasswordChangedDateTime], [LockoutEnabled], [LockoutEnd], [NormalizedEmail], [NormalizedUserName], [PasswordHash], [PasswordHint], [PersonalInfoId], [PhoneNumber], [PhoneNumberConfirmed], [SecurityStamp], [StateCode], [TwoFactorEnabled], [UserName], [WrongPassTry])
VALUES ('3abfa071-e941-48e6-a492-b6cad5debf61', 0, N'76c52b9b-21df-4f45-8220-d2755f39860c', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', N'System@System', CAST(0 AS bit), N'1', NULL, CAST(0 AS bit), CAST(0 AS bit), CAST(1 AS bit), NULL, NULL, NULL, NULL, CAST(0 AS bit), NULL, NULL, N'System', NULL, NULL, '3abfa071-e941-48e6-a492-b6cad5debf61', NULL, CAST(0 AS bit), NULL, CAST(1 AS tinyint), CAST(0 AS bit), N'System', NULL);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'AccessFailedCount', N'ConcurrencyStamp', N'CreatedByUserId', N'CreatedOn', N'Email', N'EmailConfirmed', N'EmployeeNumber', N'Extension', N'IsHasSpecialPermissions', N'IsLoggedIn', N'IsStatic', N'LastModifiedByUserId', N'LastModifiedOn', N'LatestLoggedInDateTime', N'LatestPasswordChangedDateTime', N'LockoutEnabled', N'LockoutEnd', N'NormalizedEmail', N'NormalizedUserName', N'PasswordHash', N'PasswordHint', N'PersonalInfoId', N'PhoneNumber', N'PhoneNumberConfirmed', N'SecurityStamp', N'StateCode', N'TwoFactorEnabled', N'UserName', N'WrongPassTry') AND [object_id] = OBJECT_ID(N'[Identity].[User]'))
    SET IDENTITY_INSERT [Identity].[User] OFF;

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'EntityActionTypeId', N'FieldName', N'FieldShouldRelatedToEntityTypeId', N'FieldTypeId', N'LastModifiedByUserId', N'LastModifiedOn', N'StateCode') AND [object_id] = OBJECT_ID(N'[Entity].[EntityActionTypeRequiredField]'))
    SET IDENTITY_INSERT [Entity].[EntityActionTypeRequiredField] ON;
INSERT INTO [Entity].[EntityActionTypeRequiredField] ([Id], [CreatedByUserId], [CreatedOn], [EntityActionTypeId], [FieldName], [FieldShouldRelatedToEntityTypeId], [FieldTypeId], [LastModifiedByUserId], [LastModifiedOn], [StateCode])
VALUES ('17b7dc0b-afe2-4ff5-b3d7-29cb93e04b74', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', '090e1ae7-3878-489a-ab85-8c9affb4a913', N'حقل تاريخ جدولة المكالمة الجديدة', NULL, 'd4730e56-dcc3-42e8-af4a-a6b66edbb728', NULL, NULL, CAST(1 AS tinyint)),
('dfbd996e-4e65-4261-b4d2-d5fd584035c6', '3abfa071-e941-48e6-a492-b6cad5debf61', '2021-09-10T00:00:00.0000000', '090e1ae7-3878-489a-ab85-8c9affb4a913', N'حقل نوع المسار المراد إعادة الجدولة عليه', '357d1ce2-3631-4021-9f49-ddb8be7fbd0f', 'd4730e56-dcc3-42e8-af4a-a6b66edbb728', NULL, NULL, CAST(1 AS tinyint));
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'CreatedByUserId', N'CreatedOn', N'EntityActionTypeId', N'FieldName', N'FieldShouldRelatedToEntityTypeId', N'FieldTypeId', N'LastModifiedByUserId', N'LastModifiedOn', N'StateCode') AND [object_id] = OBJECT_ID(N'[Entity].[EntityActionTypeRequiredField]'))
    SET IDENTITY_INSERT [Entity].[EntityActionTypeRequiredField] OFF;

CREATE INDEX [IX_AutoContact_CampaignId] ON [Application].[AutoContact] ([CampaignId]);

CREATE INDEX [IX_AutoContact_CategoryId] ON [Application].[AutoContact] ([CategoryId]);

CREATE INDEX [IX_AutoContact_ScheduledCallId] ON [Application].[AutoContact] ([ScheduledCallId]);

CREATE INDEX [IX_Campaign_PriorityId] ON [Lookup].[Campaign] ([PriorityId]);

CREATE INDEX [IX_Category_AVAYAAURACampaignPredictiveId] ON [Lookup].[Category] ([AVAYAAURACampaignPredictiveId]);

CREATE INDEX [IX_Category_CallCategoryMainId] ON [Lookup].[Category] ([CallCategoryMainId]);

CREATE INDEX [IX_Category_CallTypeId] ON [Lookup].[Category] ([CallTypeId]);

CREATE INDEX [IX_Category_CategoryPathId] ON [Lookup].[Category] ([CategoryPathId]);

CREATE INDEX [IX_Category_PriorityId] ON [Lookup].[Category] ([PriorityId]);

CREATE INDEX [IX_Contact_ContactCategoryId] ON [Application].[Contact] ([ContactCategoryId]);

CREATE INDEX [IX_ContactUploadingLog_CampaignId] ON [Log].[ContactUploadingLog] ([CampaignId]);

CREATE INDEX [IX_ContactUploadingLog_CategoryId] ON [Log].[ContactUploadingLog] ([CategoryId]);

CREATE INDEX [IX_ContactUploadingLog_ContactId] ON [Log].[ContactUploadingLog] ([ContactId]);

CREATE INDEX [IX_ContactUploadingLog_PriorityId] ON [Log].[ContactUploadingLog] ([PriorityId]);

CREATE INDEX [IX_DynamicFunctionParameter_DynamicFunctionId] ON [Entity].[DynamicFunctionParameter] ([DynamicFunctionId]);

CREATE INDEX [IX_DynamicFunctionResult_DynamicFunctionId] ON [Entity].[DynamicFunctionResult] ([DynamicFunctionId]);

CREATE INDEX [IX_DynamicReport_EntityId] ON [Entity].[DynamicReport] ([EntityId]);

CREATE INDEX [IX_DynamicReportField_DynamicReportId] ON [Entity].[DynamicReportField] ([DynamicReportId]);

CREATE INDEX [IX_DynamicReportField_EntityMapId] ON [Entity].[DynamicReportField] ([EntityMapId]);

CREATE INDEX [IX_Entity_EntityTypeId] ON [Entity].[Entity] ([EntityTypeId]);

CREATE INDEX [IX_EntityAction_DynamicFunctionId] ON [Entity].[EntityAction] ([DynamicFunctionId]);

CREATE INDEX [IX_EntityAction_EntityActionGroupId] ON [Entity].[EntityAction] ([EntityActionGroupId]);

CREATE INDEX [IX_EntityAction_EntityActionTypeId] ON [Entity].[EntityAction] ([EntityActionTypeId]);

CREATE INDEX [IX_EntityActionDynamicFunctionParameter_DynamicFunctionParameterId] ON [Entity].[EntityActionDynamicFunctionParameter] ([DynamicFunctionParameterId]);

CREATE INDEX [IX_EntityActionDynamicFunctionParameter_EntityActionId] ON [Entity].[EntityActionDynamicFunctionParameter] ([EntityActionId]);

CREATE INDEX [IX_EntityActionDynamicFunctionParameter_EntityFieldId] ON [Entity].[EntityActionDynamicFunctionParameter] ([EntityFieldId]);

CREATE INDEX [IX_EntityActionDynamicFunctionResult_DynamicFunctionResultId] ON [Entity].[EntityActionDynamicFunctionResult] ([DynamicFunctionResultId]);

CREATE INDEX [IX_EntityActionDynamicFunctionResult_EntityActionId] ON [Entity].[EntityActionDynamicFunctionResult] ([EntityActionId]);

CREATE INDEX [IX_EntityActionDynamicFunctionResult_EntityFieldId] ON [Entity].[EntityActionDynamicFunctionResult] ([EntityFieldId]);

CREATE INDEX [IX_EntityActionField_EntityActionId] ON [Entity].[EntityActionField] ([EntityActionId]);

CREATE INDEX [IX_EntityActionField_EntityActionTypeRequiredFieldId] ON [Entity].[EntityActionField] ([EntityActionTypeRequiredFieldId]);

CREATE INDEX [IX_EntityActionField_EntityFieldId] ON [Entity].[EntityActionField] ([EntityFieldId]);

CREATE INDEX [IX_EntityActionGroup_EntityId] ON [Entity].[EntityActionGroup] ([EntityId]);

CREATE INDEX [IX_EntityActionGroupCondition_ConditionTypeId] ON [Entity].[EntityActionGroupCondition] ([ConditionTypeId]);

CREATE INDEX [IX_EntityActionGroupCondition_EntityActionGroupConditionGroupId] ON [Entity].[EntityActionGroupCondition] ([EntityActionGroupConditionGroupId]);

CREATE INDEX [IX_EntityActionGroupCondition_FirstSideRelatedToEntityId] ON [Entity].[EntityActionGroupCondition] ([FirstSideRelatedToEntityId]);

CREATE INDEX [IX_EntityActionGroupCondition_SecondSideRelatedToEntityId] ON [Entity].[EntityActionGroupCondition] ([SecondSideRelatedToEntityId]);

CREATE INDEX [IX_EntityActionGroupConditionGroup_EntityActionGroupId] ON [Entity].[EntityActionGroupConditionGroup] ([EntityActionGroupId]);

CREATE INDEX [IX_EntityActionGroupTriggerType_TriggerTypeId] ON [Entity].[EntityActionGroupTriggerType] ([TriggerTypeId]);

CREATE INDEX [IX_EntityActionType_EntityTypeId] ON [Entity].[EntityActionType] ([EntityTypeId]);

CREATE INDEX [IX_EntityActionTypeRequiredField_EntityActionTypeId] ON [Entity].[EntityActionTypeRequiredField] ([EntityActionTypeId]);

CREATE INDEX [IX_EntityActionTypeRequiredField_FieldShouldRelatedToEntityTypeId] ON [Entity].[EntityActionTypeRequiredField] ([FieldShouldRelatedToEntityTypeId]);

CREATE INDEX [IX_EntityActionTypeRequiredField_FieldTypeId] ON [Entity].[EntityActionTypeRequiredField] ([FieldTypeId]);

CREATE INDEX [IX_EntityField_EntityFieldGroupId] ON [Entity].[EntityField] ([EntityFieldGroupId]);

CREATE INDEX [IX_EntityField_FieldTypeId] ON [Entity].[EntityField] ([FieldTypeId]);

CREATE INDEX [IX_EntityField_RelatedToEntityId] ON [Entity].[EntityField] ([RelatedToEntityId]);

CREATE INDEX [IX_EntityFieldAction_DynamicFunctionId] ON [Entity].[EntityFieldAction] ([DynamicFunctionId]);

CREATE INDEX [IX_EntityFieldAction_EntityFieldActionGroupId] ON [Entity].[EntityFieldAction] ([EntityFieldActionGroupId]);

CREATE INDEX [IX_EntityFieldAction_EntityFieldActionTypeId] ON [Entity].[EntityFieldAction] ([EntityFieldActionTypeId]);

CREATE INDEX [IX_EntityFieldActionDynamicFunction_DynamicFunctionId] ON [Entity].[EntityFieldActionDynamicFunction] ([DynamicFunctionId]);

CREATE INDEX [IX_EntityFieldActionDynamicFunction_EntityFieldActionId] ON [Entity].[EntityFieldActionDynamicFunction] ([EntityFieldActionId]);

CREATE INDEX [IX_EntityFieldActionDynamicFunctionParameter_DynamicFunctionParameterId] ON [Entity].[EntityFieldActionDynamicFunctionParameter] ([DynamicFunctionParameterId]);

CREATE INDEX [IX_EntityFieldActionDynamicFunctionParameter_EntityFieldActionDynamicFunctionId] ON [Entity].[EntityFieldActionDynamicFunctionParameter] ([EntityFieldActionDynamicFunctionId]);

CREATE INDEX [IX_EntityFieldActionDynamicFunctionParameter_EntityFieldActionId] ON [Entity].[EntityFieldActionDynamicFunctionParameter] ([EntityFieldActionId]);

CREATE INDEX [IX_EntityFieldActionDynamicFunctionParameter_EntityFieldId] ON [Entity].[EntityFieldActionDynamicFunctionParameter] ([EntityFieldId]);

CREATE INDEX [IX_EntityFieldActionDynamicFunctionResult_DynamicFunctionResultId] ON [Entity].[EntityFieldActionDynamicFunctionResult] ([DynamicFunctionResultId]);

CREATE INDEX [IX_EntityFieldActionDynamicFunctionResult_EntityFieldActionDynamicFunctionId] ON [Entity].[EntityFieldActionDynamicFunctionResult] ([EntityFieldActionDynamicFunctionId]);

CREATE INDEX [IX_EntityFieldActionDynamicFunctionResult_EntityFieldActionId] ON [Entity].[EntityFieldActionDynamicFunctionResult] ([EntityFieldActionId]);

CREATE INDEX [IX_EntityFieldActionDynamicFunctionResult_EntityFieldId] ON [Entity].[EntityFieldActionDynamicFunctionResult] ([EntityFieldId]);

CREATE INDEX [IX_EntityFieldActionField_EntityFieldActionId] ON [Entity].[EntityFieldActionField] ([EntityFieldActionId]);

CREATE INDEX [IX_EntityFieldActionField_EntityFieldActionTypeRequiredFieldId] ON [Entity].[EntityFieldActionField] ([EntityFieldActionTypeRequiredFieldId]);

CREATE INDEX [IX_EntityFieldActionField_EntityFieldId] ON [Entity].[EntityFieldActionField] ([EntityFieldId]);

CREATE INDEX [IX_EntityFieldActionGroup_EntityFieldId] ON [Entity].[EntityFieldActionGroup] ([EntityFieldId]);

CREATE INDEX [IX_EntityFieldActionGroupCondition_ConditionTypeId] ON [Entity].[EntityFieldActionGroupCondition] ([ConditionTypeId]);

CREATE INDEX [IX_EntityFieldActionGroupCondition_EntityFieldActionGroupConditionGroupId] ON [Entity].[EntityFieldActionGroupCondition] ([EntityFieldActionGroupConditionGroupId]);

CREATE INDEX [IX_EntityFieldActionGroupCondition_FirstSideRelatedToEntityId] ON [Entity].[EntityFieldActionGroupCondition] ([FirstSideRelatedToEntityId]);

CREATE INDEX [IX_EntityFieldActionGroupCondition_SecondSideRelatedToEntityId] ON [Entity].[EntityFieldActionGroupCondition] ([SecondSideRelatedToEntityId]);

CREATE INDEX [IX_EntityFieldActionGroupConditionGroup_EntityFieldActionGroupId] ON [Entity].[EntityFieldActionGroupConditionGroup] ([EntityFieldActionGroupId]);

CREATE INDEX [IX_EntityFieldActionGroupTriggerType_TriggerTypeId] ON [Entity].[EntityFieldActionGroupTriggerType] ([TriggerTypeId]);

CREATE INDEX [IX_EntityFieldActionType_EntityId] ON [Entity].[EntityFieldActionType] ([EntityId]);

CREATE INDEX [IX_EntityFieldActionTypeRequiredField_EntityFieldActionTypeId] ON [Entity].[EntityFieldActionTypeRequiredField] ([EntityFieldActionTypeId]);

CREATE INDEX [IX_EntityFieldActionTypeRequiredField_FieldShouldRelatedToEntityId] ON [Entity].[EntityFieldActionTypeRequiredField] ([FieldShouldRelatedToEntityId]);

CREATE INDEX [IX_EntityFieldActionTypeRequiredField_FieldTypeId] ON [Entity].[EntityFieldActionTypeRequiredField] ([FieldTypeId]);

CREATE INDEX [IX_EntityFieldCondition_ConditionTypeId] ON [Entity].[EntityFieldCondition] ([ConditionTypeId]);

CREATE INDEX [IX_EntityFieldCondition_EntityFieldConditionGroupId] ON [Entity].[EntityFieldCondition] ([EntityFieldConditionGroupId]);

CREATE INDEX [IX_EntityFieldCondition_FirstSideRelatedToEntityId] ON [Entity].[EntityFieldCondition] ([FirstSideRelatedToEntityId]);

CREATE INDEX [IX_EntityFieldCondition_SecondSideRelatedToEntityId] ON [Entity].[EntityFieldCondition] ([SecondSideRelatedToEntityId]);

CREATE INDEX [IX_EntityFieldConditionGroup_ConditionForId] ON [Entity].[EntityFieldConditionGroup] ([ConditionForId]);

CREATE INDEX [IX_EntityFieldConditionGroup_EntityFieldId] ON [Entity].[EntityFieldConditionGroup] ([EntityFieldId]);

CREATE INDEX [IX_EntityFieldGroup_EntityId] ON [Entity].[EntityFieldGroup] ([EntityId]);

CREATE INDEX [IX_EntityFieldOption_EntityFieldId] ON [Entity].[EntityFieldOption] ([EntityFieldId]);

CREATE INDEX [IX_EntityFieldOptionCondition_ConditionTypeId] ON [Entity].[EntityFieldOptionCondition] ([ConditionTypeId]);

CREATE INDEX [IX_EntityFieldOptionCondition_EntityFieldOptionConditionGroupId] ON [Entity].[EntityFieldOptionCondition] ([EntityFieldOptionConditionGroupId]);

CREATE INDEX [IX_EntityFieldOptionCondition_FirstSideRelatedToEntityId] ON [Entity].[EntityFieldOptionCondition] ([FirstSideRelatedToEntityId]);

CREATE INDEX [IX_EntityFieldOptionCondition_SecondSideRelatedToEntityId] ON [Entity].[EntityFieldOptionCondition] ([SecondSideRelatedToEntityId]);

CREATE INDEX [IX_EntityFieldOptionConditionGroup_ConditionForId] ON [Entity].[EntityFieldOptionConditionGroup] ([ConditionForId]);

CREATE INDEX [IX_EntityFieldOptionConditionGroup_EntityFieldOptionId] ON [Entity].[EntityFieldOptionConditionGroup] ([EntityFieldOptionId]);

CREATE INDEX [IX_EntityFieldValue_EntityFieldId] ON [Entity].[EntityFieldValue] ([EntityFieldId]);

CREATE INDEX [IX_EntityMap_EntityId] ON [Entity].[EntityMap] ([EntityId]);

CREATE INDEX [IX_EntityMap_MappedEntityId] ON [Entity].[EntityMap] ([MappedEntityId]);

CREATE INDEX [IX_EntityRelationBreak_Entity2Id] ON [Entity].[EntityRelationBreak] ([Entity2Id]);

CREATE INDEX [IX_HistoricalCall_AssignFromUserId] ON [Application].[HistoricalCall] ([AssignFromUserId]);

CREATE INDEX [IX_HistoricalCall_AssignToUserId] ON [Application].[HistoricalCall] ([AssignToUserId]);

CREATE INDEX [IX_HistoricalCall_CallStatusId] ON [Application].[HistoricalCall] ([CallStatusId]);

CREATE INDEX [IX_HistoricalCall_CallTypeId] ON [Application].[HistoricalCall] ([CallTypeId]);

CREATE INDEX [IX_HistoricalCall_CampaignId] ON [Application].[HistoricalCall] ([CampaignId]);

CREATE INDEX [IX_HistoricalCall_CategoryId] ON [Application].[HistoricalCall] ([CategoryId]);

CREATE INDEX [IX_HistoricalCall_ContactId] ON [Application].[HistoricalCall] ([ContactId]);

CREATE INDEX [IX_HistoricalCall_LatestHistoricalCallId] ON [Application].[HistoricalCall] ([LatestHistoricalCallId]);

CREATE INDEX [IX_HistoricalCall_PriorityId] ON [Application].[HistoricalCall] ([PriorityId]);

CREATE INDEX [IX_HistoricalCall_ScheduledByUserId] ON [Application].[HistoricalCall] ([ScheduledByUserId]);

CREATE INDEX [IX_HistoricalCall_ScheduledToUserId] ON [Application].[HistoricalCall] ([ScheduledToUserId]);

CREATE INDEX [IX_HistoricalCallGeneralReportSammary_CallStatusId] ON [Log].[HistoricalCallGeneralReportSammary] ([CallStatusId]);

CREATE INDEX [IX_HistoricalCallGeneralReportSammary_CallTypeId] ON [Log].[HistoricalCallGeneralReportSammary] ([CallTypeId]);

CREATE INDEX [IX_HistoricalCallGeneralReportSammary_CampaignId] ON [Log].[HistoricalCallGeneralReportSammary] ([CampaignId]);

CREATE INDEX [IX_HistoricalCallGeneralReportSammary_CategoryId] ON [Log].[HistoricalCallGeneralReportSammary] ([CategoryId]);

CREATE INDEX [IX_HistoricalCallGeneralReportSammary_ContactId] ON [Log].[HistoricalCallGeneralReportSammary] ([ContactId]);

CREATE INDEX [IX_HistoricalCallGeneralReportSammary_HistoricalCallId] ON [Log].[HistoricalCallGeneralReportSammary] ([HistoricalCallId]);

CREATE INDEX [IX_HistoricalCallGeneralReportSammary_LeaderId] ON [Log].[HistoricalCallGeneralReportSammary] ([LeaderId]);

CREATE INDEX [IX_HistoricalCallGeneralReportSammary_UserId] ON [Log].[HistoricalCallGeneralReportSammary] ([UserId]);

CREATE INDEX [IX_HistoricalCallPathResult_EntityFieldId] ON [Application].[HistoricalCallPathResult] ([EntityFieldId]);

CREATE INDEX [IX_HistoricalCallPathResult_HistoricalCallId] ON [Application].[HistoricalCallPathResult] ([HistoricalCallId]);

CREATE INDEX [IX_PersonalInfo_CityId] ON [Application].[PersonalInfo] ([CityId]);

CREATE INDEX [IX_Pim_contact_attempts_history_AutoContactId] ON [Log].[Pim_contact_attempts_history] ([AutoContactId]);

CREATE INDEX [IX_Pim_contact_attempts_history_CampaignId] ON [Log].[Pim_contact_attempts_history] ([CampaignId]);

CREATE INDEX [IX_Pim_contact_attempts_history_CategoryId] ON [Log].[Pim_contact_attempts_history] ([CategoryId]);

CREATE INDEX [IX_Pim_contact_attempts_history_ContactId] ON [Log].[Pim_contact_attempts_history] ([ContactId]);

CREATE INDEX [IX_Pim_contact_attempts_history_HistoricalCallId] ON [Log].[Pim_contact_attempts_history] ([HistoricalCallId]);

CREATE INDEX [IX_Pim_contact_attempts_history_UserId] ON [Log].[Pim_contact_attempts_history] ([UserId]);

CREATE INDEX [IX_Pim_contact_attempts_historyLog_CampaignId] ON [Log].[Pim_contact_attempts_historyLog] ([CampaignId]);

CREATE INDEX [IX_Pim_contact_attempts_historyLog_CategoryId] ON [Log].[Pim_contact_attempts_historyLog] ([CategoryId]);

CREATE INDEX [IX_Pim_contact_attempts_historyLog_ContactId] ON [Log].[Pim_contact_attempts_historyLog] ([ContactId]);

CREATE INDEX [IX_Pim_contact_attempts_historyLog_HistoricalCallId] ON [Log].[Pim_contact_attempts_historyLog] ([HistoricalCallId]);

CREATE INDEX [IX_Pim_contact_attempts_historyLog_UserId] ON [Log].[Pim_contact_attempts_historyLog] ([UserId]);

CREATE UNIQUE INDEX [RoleNameIndex] ON [Identity].[Role] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

CREATE INDEX [IX_RoleClaims_RoleId] ON [Identity].[RoleClaims] ([RoleId]);

CREATE INDEX [IX_RolePermission_PermissionId] ON [Identity].[RolePermission] ([PermissionId]);

CREATE INDEX [IX_ScheduledCall_AssignFromUserId] ON [Application].[ScheduledCall] ([AssignFromUserId]);

CREATE INDEX [IX_ScheduledCall_AssignToUserId] ON [Application].[ScheduledCall] ([AssignToUserId]);

CREATE INDEX [IX_ScheduledCall_CallStatusId] ON [Application].[ScheduledCall] ([CallStatusId]);

CREATE INDEX [IX_ScheduledCall_CallTypeId] ON [Application].[ScheduledCall] ([CallTypeId]);

CREATE INDEX [IX_ScheduledCall_CampaignId] ON [Application].[ScheduledCall] ([CampaignId]);

CREATE INDEX [IX_ScheduledCall_CategoryId] ON [Application].[ScheduledCall] ([CategoryId]);

CREATE INDEX [IX_ScheduledCall_ContactId] ON [Application].[ScheduledCall] ([ContactId]);

CREATE INDEX [IX_ScheduledCall_LatestHistoricalCallId] ON [Application].[ScheduledCall] ([LatestHistoricalCallId]);

CREATE INDEX [IX_ScheduledCall_PriorityId] ON [Application].[ScheduledCall] ([PriorityId]);

CREATE INDEX [IX_ScheduledCall_ScheduledByUserId] ON [Application].[ScheduledCall] ([ScheduledByUserId]);

CREATE INDEX [IX_ScheduledCall_ScheduledToUserId] ON [Application].[ScheduledCall] ([ScheduledToUserId]);

CREATE INDEX [IX_SystemProgress_EntityId] ON [Application].[SystemProgress] ([EntityId]);

CREATE INDEX [IX_Team_LeaderId] ON [Lookup].[Team] ([LeaderId]);

CREATE INDEX [EmailIndex] ON [Identity].[User] ([NormalizedEmail]);

CREATE INDEX [IX_User_CreatedByUserId] ON [Identity].[User] ([CreatedByUserId]);

CREATE INDEX [IX_User_LastModifiedByUserId] ON [Identity].[User] ([LastModifiedByUserId]);

CREATE UNIQUE INDEX [UserNameIndex] ON [Identity].[User] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

CREATE INDEX [IX_UserClaims_UserId] ON [Identity].[UserClaims] ([UserId]);

CREATE INDEX [IX_UserLogins_UserId] ON [Identity].[UserLogins] ([UserId]);

CREATE INDEX [IX_UserPermission_PermissionId] ON [Identity].[UserPermission] ([PermissionId]);

CREATE INDEX [IX_UserRealTime_CreatedByUserId] ON [Identity].[UserRealTime] ([CreatedByUserId]);

CREATE INDEX [IX_UserRealTime_LastModifiedByUserId] ON [Identity].[UserRealTime] ([LastModifiedByUserId]);

CREATE INDEX [IX_UserRoles_RoleId] ON [Identity].[UserRoles] ([RoleId]);

CREATE INDEX [IX_UserSetting_CreatedByUserId] ON [Identity].[UserSetting] ([CreatedByUserId]);

CREATE INDEX [IX_UserSetting_LastModifiedByUserId] ON [Identity].[UserSetting] ([LastModifiedByUserId]);

CREATE INDEX [IX_UserSetting_SettingTypeId] ON [Identity].[UserSetting] ([SettingTypeId]);

CREATE INDEX [IX_UserTeams_TeamId] ON [Identity].[UserTeams] ([TeamId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250812140645_initmigration', N'9.0.8');

COMMIT;
GO

