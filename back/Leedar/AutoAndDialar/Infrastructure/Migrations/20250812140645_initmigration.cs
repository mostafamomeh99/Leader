using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Lookup");

            migrationBuilder.EnsureSchema(
                name: "Application");

            migrationBuilder.EnsureSchema(
                name: "Log");

            migrationBuilder.EnsureSchema(
                name: "Entity");

            migrationBuilder.EnsureSchema(
                name: "Identity");

            migrationBuilder.CreateTable(
                name: "AppSetting",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    SectionName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    KeyName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AVAYAAURACampaignPredictive",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    NameInAvayaSystem = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsPredictive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AVAYAAURACampaignPredictive", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallStatus",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CallType",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPath",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPath", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "City",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConditionFor",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionFor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConditionType",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConditionType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DynamicFunction",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    FunctionIdentifire = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicFunction", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EntityType",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    SchemaName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    TabelName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldType",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nhc_agentless_can",
                schema: "Log",
                columns: table => new
                {
                    IdGu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<long>(type: "bigint", nullable: false),
                    UCID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    agentid = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    callernumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    evalresult1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    submitdate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    evalresult2 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    channel = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhc_agentless_can", x => x.IdGu);
                });

            migrationBuilder.CreateTable(
                name: "nhc_interest_camp",
                schema: "Log",
                columns: table => new
                {
                    IdGu = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<long>(type: "bigint", nullable: false),
                    UCID = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    agentid = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    callernumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Visited_Note = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    submitdate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nhc_interest_camp", x => x.IdGu);
                });

            migrationBuilder.CreateTable(
                name: "Permission",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Priority",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Priority", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsDefualt = table.Column<bool>(type: "bit", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Setting",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    NameForSystem = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettingType",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettingType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TriggerType",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TriggerType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalInfo",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    IdentityNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FullNameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber2 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonalInfo_City_CityId",
                        column: x => x.CityId,
                        principalSchema: "Lookup",
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DynamicFunctionParameter",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    DynamicFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FunctionIdentifire = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicFunctionParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicFunctionParameter_DynamicFunction_DynamicFunctionId",
                        column: x => x.DynamicFunctionId,
                        principalSchema: "Entity",
                        principalTable: "DynamicFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DynamicFunctionResult",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    DynamicFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OutputIdentifire = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicFunctionResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicFunctionResult_DynamicFunction_DynamicFunctionId",
                        column: x => x.DynamicFunctionId,
                        principalSchema: "Entity",
                        principalTable: "DynamicFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Entity",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelatedEntityPK = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CallStatusFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubCallStatusFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    NoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubNoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OtherNoteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entity_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalSchema: "Entity",
                        principalTable: "EntityType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityActionType",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityActionType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityActionType_EntityType_EntityTypeId",
                        column: x => x.EntityTypeId,
                        principalSchema: "Entity",
                        principalTable: "EntityType",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    PriorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaign_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalSchema: "Lookup",
                        principalTable: "Priority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    CallCategoryMainId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryPathId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AVAYAAURACampaignPredictiveId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CallTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PriorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_AVAYAAURACampaignPredictive_AVAYAAURACampaignPredictiveId",
                        column: x => x.AVAYAAURACampaignPredictiveId,
                        principalSchema: "Lookup",
                        principalTable: "AVAYAAURACampaignPredictive",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_CallType_CallTypeId",
                        column: x => x.CallTypeId,
                        principalSchema: "Lookup",
                        principalTable: "CallType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Category_CategoryPath_CategoryPathId",
                        column: x => x.CategoryPathId,
                        principalSchema: "Lookup",
                        principalTable: "CategoryPath",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Category_Category_CallCategoryMainId",
                        column: x => x.CallCategoryMainId,
                        principalSchema: "Lookup",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Category_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalSchema: "Lookup",
                        principalTable: "Priority",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoleClaims_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                schema: "Identity",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "Lookup",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    PersonalInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ContactCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDesable = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contact_ContactCategory_ContactCategoryId",
                        column: x => x.ContactCategoryId,
                        principalTable: "ContactCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Contact_PersonalInfo_Id",
                        column: x => x.Id,
                        principalSchema: "Application",
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "User",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false),
                    IsHasSpecialPermissions = table.Column<bool>(type: "bit", nullable: false),
                    LatestLoggedInDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LatestPasswordChangedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PasswordHint = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    WrongPassTry = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    PersonalInfoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_PersonalInfo_Id",
                        column: x => x.Id,
                        principalSchema: "Application",
                        principalTable: "PersonalInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_User_User_LastModifiedByUserId",
                        column: x => x.LastModifiedByUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DynamicReport",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicReport_Entity_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityActionGroup",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ANDorOR = table.Column<bool>(type: "bit", nullable: true),
                    ProcessOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityActionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityActionGroup_Entity_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldActionType",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldActionType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionType_Entity_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldGroup",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldGroup_Entity_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityMap",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    RelationName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MappedEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsNullable = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityMap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityMap_Entity_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityMap_Entity_MappedEntityId",
                        column: x => x.MappedEntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityRelationBreak",
                schema: "Entity",
                columns: table => new
                {
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Entity2Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityPK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Entity2PK = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityRelationBreak", x => new { x.EntityId, x.Entity2Id });
                    table.ForeignKey(
                        name: "FK_EntityRelationBreak_Entity_Entity2Id",
                        column: x => x.Entity2Id,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityRelationBreak_Entity_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemProgress",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    Max = table.Column<int>(type: "int", nullable: false),
                    Currant = table.Column<int>(type: "int", nullable: false),
                    FilePath = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SystemProgress_Entity_EntityId",
                        column: x => x.EntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityActionTypeRequiredField",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityActionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FieldTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldShouldRelatedToEntityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityActionTypeRequiredField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityActionTypeRequiredField_EntityActionType_EntityActionTypeId",
                        column: x => x.EntityActionTypeId,
                        principalSchema: "Entity",
                        principalTable: "EntityActionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityActionTypeRequiredField_EntityType_FieldShouldRelatedToEntityTypeId",
                        column: x => x.FieldShouldRelatedToEntityTypeId,
                        principalSchema: "Entity",
                        principalTable: "EntityType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityActionTypeRequiredField_FieldType_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalSchema: "Lookup",
                        principalTable: "FieldType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactUploadingLog",
                schema: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PriorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsUploadedSuccessfully = table.Column<bool>(type: "bit", nullable: false),
                    FileRow = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DescriptionOthers = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUploadingLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactUploadingLog_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Lookup",
                        principalTable: "Campaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactUploadingLog_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Lookup",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactUploadingLog_Contact_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "Application",
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ContactUploadingLog_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalSchema: "Lookup",
                        principalTable: "Priority",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HistoricalCall",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CallStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubCallStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CallTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignFromUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignToUserAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledToUserAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledCallDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CallDuration = table.Column<double>(type: "float", nullable: true),
                    IsLatestCall = table.Column<bool>(type: "bit", nullable: false),
                    LatestHistoricalCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CallDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PriorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    GetResultFromAvayaAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalCall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricalCall_CallStatus_CallStatusId",
                        column: x => x.CallStatusId,
                        principalSchema: "Lookup",
                        principalTable: "CallStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalCall_CallType_CallTypeId",
                        column: x => x.CallTypeId,
                        principalSchema: "Lookup",
                        principalTable: "CallType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_HistoricalCall_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Lookup",
                        principalTable: "Campaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricalCall_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Lookup",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricalCall_Contact_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "Application",
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalCall_HistoricalCall_LatestHistoricalCallId",
                        column: x => x.LatestHistoricalCallId,
                        principalSchema: "Application",
                        principalTable: "HistoricalCall",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricalCall_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalSchema: "Lookup",
                        principalTable: "Priority",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricalCall_User_AssignFromUserId",
                        column: x => x.AssignFromUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricalCall_User_AssignToUserId",
                        column: x => x.AssignToUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricalCall_User_ScheduledByUserId",
                        column: x => x.ScheduledByUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricalCall_User_ScheduledToUserId",
                        column: x => x.ScheduledToUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Team",
                schema: "Lookup",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    LeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Team_User_LeaderId",
                        column: x => x.LeaderId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                schema: "Identity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserClaims_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                schema: "Identity",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_UserLogins_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => new { x.UserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserPermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "Lookup",
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserPermission_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRealTime",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SignalRId = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRealTime", x => new { x.UserId, x.SignalRId });
                    table.ForeignKey(
                        name: "FK_UserRealTime_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRealTime_User_LastModifiedByUserId",
                        column: x => x.LastModifiedByUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserRealTime_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "Identity",
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRoles_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSetting",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SettingTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSetting", x => new { x.UserId, x.SettingTypeId });
                    table.ForeignKey(
                        name: "FK_UserSetting_SettingType_SettingTypeId",
                        column: x => x.SettingTypeId,
                        principalSchema: "Lookup",
                        principalTable: "SettingType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserSetting_User_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSetting_User_LastModifiedByUserId",
                        column: x => x.LastModifiedByUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSetting_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_UserTokens_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityAction",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityActionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityActionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessOrder = table.Column<int>(type: "int", nullable: false),
                    DynamicFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityAction_DynamicFunction_DynamicFunctionId",
                        column: x => x.DynamicFunctionId,
                        principalSchema: "Entity",
                        principalTable: "DynamicFunction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityAction_EntityActionGroup_EntityActionGroupId",
                        column: x => x.EntityActionGroupId,
                        principalSchema: "Entity",
                        principalTable: "EntityActionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityAction_EntityActionType_EntityActionTypeId",
                        column: x => x.EntityActionTypeId,
                        principalSchema: "Entity",
                        principalTable: "EntityActionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityActionGroupConditionGroup",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityActionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ANDorOR = table.Column<bool>(type: "bit", nullable: true),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityActionGroupConditionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityActionGroupConditionGroup_EntityActionGroup_EntityActionGroupId",
                        column: x => x.EntityActionGroupId,
                        principalSchema: "Entity",
                        principalTable: "EntityActionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityActionGroupTriggerType",
                schema: "Entity",
                columns: table => new
                {
                    EntityActionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TriggerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityActionGroupTriggerType", x => new { x.EntityActionGroupId, x.TriggerTypeId });
                    table.ForeignKey(
                        name: "FK_EntityActionGroupTriggerType_EntityActionGroup_EntityActionGroupId",
                        column: x => x.EntityActionGroupId,
                        principalSchema: "Entity",
                        principalTable: "EntityActionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityActionGroupTriggerType_TriggerType_TriggerTypeId",
                        column: x => x.TriggerTypeId,
                        principalSchema: "Lookup",
                        principalTable: "TriggerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldActionTypeRequiredField",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldActionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FieldTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldShouldRelatedToEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldActionTypeRequiredField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionTypeRequiredField_EntityFieldActionType_EntityFieldActionTypeId",
                        column: x => x.EntityFieldActionTypeId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldActionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionTypeRequiredField_Entity_FieldShouldRelatedToEntityId",
                        column: x => x.FieldShouldRelatedToEntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityFieldActionTypeRequiredField_FieldType_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalSchema: "Lookup",
                        principalTable: "FieldType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityField",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RelatedToEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsRequired = table.Column<bool>(type: "bit", nullable: true),
                    IsReadOnly = table.Column<bool>(type: "bit", nullable: true),
                    IsReportExportable = table.Column<bool>(type: "bit", nullable: true),
                    IsForVisitReport = table.Column<bool>(type: "bit", nullable: true),
                    IsForSpecialSammaryReport = table.Column<bool>(type: "bit", nullable: true),
                    Unified = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Column = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<int>(type: "int", nullable: false),
                    Height = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityField_EntityFieldGroup_EntityFieldGroupId",
                        column: x => x.EntityFieldGroupId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityField_EntityType_RelatedToEntityId",
                        column: x => x.RelatedToEntityId,
                        principalSchema: "Entity",
                        principalTable: "EntityType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityField_FieldType_FieldTypeId",
                        column: x => x.FieldTypeId,
                        principalSchema: "Lookup",
                        principalTable: "FieldType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DynamicReportField",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    DynamicReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityMapId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicReportField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicReportField_DynamicReport_DynamicReportId",
                        column: x => x.DynamicReportId,
                        principalSchema: "Entity",
                        principalTable: "DynamicReport",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DynamicReportField_EntityMap_EntityMapId",
                        column: x => x.EntityMapId,
                        principalSchema: "Entity",
                        principalTable: "EntityMap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalCallGeneralReportSammary",
                schema: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    HistoricalCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CallStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactIdentity = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ContactPhone1 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ContactPhone2 = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CallTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CallDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CallDuration = table.Column<double>(type: "float", nullable: true),
                    CallDurationString = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CallStatusName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    SubCallStatusName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CallStatusResult = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CallStatusResultSub = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CallStatusOtherNote = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CampaignName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmployeeNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LeaderName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CallUpload = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CallStartAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CallEndAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PriorityName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalCallGeneralReportSammary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricalCallGeneralReportSammary_CallStatus_CallStatusId",
                        column: x => x.CallStatusId,
                        principalSchema: "Lookup",
                        principalTable: "CallStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalCallGeneralReportSammary_CallType_CallTypeId",
                        column: x => x.CallTypeId,
                        principalSchema: "Lookup",
                        principalTable: "CallType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricalCallGeneralReportSammary_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Lookup",
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalCallGeneralReportSammary_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Lookup",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalCallGeneralReportSammary_Contact_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "Application",
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalCallGeneralReportSammary_HistoricalCall_HistoricalCallId",
                        column: x => x.HistoricalCallId,
                        principalSchema: "Application",
                        principalTable: "HistoricalCall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalCallGeneralReportSammary_User_LeaderId",
                        column: x => x.LeaderId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HistoricalCallGeneralReportSammary_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pim_contact_attempts_historyLog",
                schema: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Pim_session_id = table.Column<long>(type: "bigint", nullable: false),
                    Completion_Code_id = table.Column<int>(type: "int", nullable: false),
                    Completion_Code_Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Completion_Code_Name_Ar = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Sys_completion_code_id = table.Column<int>(type: "int", nullable: true),
                    Contact_attempt_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Last_nw_disposition_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Call_start_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Call_completion_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ucid = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Agent_id = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Campaign_id = table.Column<int>(type: "int", nullable: true),
                    Campaign_list_id = table.Column<int>(type: "int", nullable: true),
                    CallDuration = table.Column<double>(type: "float", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HistoricalCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pim_contact_attempts_historyLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pim_contact_attempts_historyLog_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Lookup",
                        principalTable: "Campaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pim_contact_attempts_historyLog_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Lookup",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pim_contact_attempts_historyLog_Contact_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "Application",
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pim_contact_attempts_historyLog_HistoricalCall_HistoricalCallId",
                        column: x => x.HistoricalCallId,
                        principalSchema: "Application",
                        principalTable: "HistoricalCall",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pim_contact_attempts_historyLog_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScheduledCall",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CallStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CallTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignFromUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignToUserAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledToUserAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledCallDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PriorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LatestHistoricalCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledCall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledCall_CallStatus_CallStatusId",
                        column: x => x.CallStatusId,
                        principalSchema: "Lookup",
                        principalTable: "CallStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledCall_CallType_CallTypeId",
                        column: x => x.CallTypeId,
                        principalSchema: "Lookup",
                        principalTable: "CallType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_ScheduledCall_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Lookup",
                        principalTable: "Campaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCall_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Lookup",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCall_Contact_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "Application",
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledCall_HistoricalCall_LatestHistoricalCallId",
                        column: x => x.LatestHistoricalCallId,
                        principalSchema: "Application",
                        principalTable: "HistoricalCall",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCall_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalSchema: "Lookup",
                        principalTable: "Priority",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCall_User_AssignFromUserId",
                        column: x => x.AssignFromUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCall_User_AssignToUserId",
                        column: x => x.AssignToUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCall_User_ScheduledByUserId",
                        column: x => x.ScheduledByUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCall_User_ScheduledToUserId",
                        column: x => x.ScheduledToUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserTeams",
                schema: "Identity",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TeamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeams", x => new { x.UserId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_UserTeams_Team_TeamId",
                        column: x => x.TeamId,
                        principalSchema: "Lookup",
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTeams_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityActionGroupCondition",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityActionGroupConditionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstSideRelatedToEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FirstSideFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondSideRelatedToEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CondetionValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ANDorOR = table.Column<bool>(type: "bit", nullable: true),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    ProcessOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityActionGroupCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityActionGroupCondition_ConditionType_ConditionTypeId",
                        column: x => x.ConditionTypeId,
                        principalSchema: "Lookup",
                        principalTable: "ConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityActionGroupCondition_EntityActionGroupConditionGroup_EntityActionGroupConditionGroupId",
                        column: x => x.EntityActionGroupConditionGroupId,
                        principalSchema: "Entity",
                        principalTable: "EntityActionGroupConditionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityActionGroupCondition_Entity_FirstSideRelatedToEntityId",
                        column: x => x.FirstSideRelatedToEntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityActionGroupCondition_Entity_SecondSideRelatedToEntityId",
                        column: x => x.SecondSideRelatedToEntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityActionDynamicFunctionParameter",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DynamicFunctionParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FieldShouldRelatedToEntityTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityActionDynamicFunctionParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityActionDynamicFunctionParameter_DynamicFunctionParameter_DynamicFunctionParameterId",
                        column: x => x.DynamicFunctionParameterId,
                        principalSchema: "Entity",
                        principalTable: "DynamicFunctionParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityActionDynamicFunctionParameter_EntityAction_EntityActionId",
                        column: x => x.EntityActionId,
                        principalSchema: "Entity",
                        principalTable: "EntityAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityActionDynamicFunctionParameter_EntityField_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityField",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityActionDynamicFunctionResult",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DynamicFunctionResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsResultToNotification = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityActionDynamicFunctionResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityActionDynamicFunctionResult_DynamicFunctionResult_DynamicFunctionResultId",
                        column: x => x.DynamicFunctionResultId,
                        principalSchema: "Entity",
                        principalTable: "DynamicFunctionResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityActionDynamicFunctionResult_EntityAction_EntityActionId",
                        column: x => x.EntityActionId,
                        principalSchema: "Entity",
                        principalTable: "EntityAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityActionDynamicFunctionResult_EntityField_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityActionField",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityActionTypeRequiredFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityActionField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityActionField_EntityActionTypeRequiredField_EntityActionTypeRequiredFieldId",
                        column: x => x.EntityActionTypeRequiredFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityActionTypeRequiredField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityActionField_EntityAction_EntityActionId",
                        column: x => x.EntityActionId,
                        principalSchema: "Entity",
                        principalTable: "EntityAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityActionField_EntityField_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityField",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldActionGroup",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ANDorOR = table.Column<bool>(type: "bit", nullable: true),
                    ProcessOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldActionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionGroup_EntityField_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldConditionGroup",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionForId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ANDorOR = table.Column<bool>(type: "bit", nullable: true),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldConditionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldConditionGroup_ConditionFor_ConditionForId",
                        column: x => x.ConditionForId,
                        principalSchema: "Lookup",
                        principalTable: "ConditionFor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldConditionGroup_EntityField_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldOption",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<byte>(type: "tinyint", nullable: false),
                    RelatedEntityOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldOption_EntityField_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldValue",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityPK = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldValue_EntityField_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalCallPathResult",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    HistoricalCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ValueString = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalCallPathResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoricalCallPathResult_EntityField_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistoricalCallPathResult_HistoricalCall_HistoricalCallId",
                        column: x => x.HistoricalCallId,
                        principalSchema: "Application",
                        principalTable: "HistoricalCall",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutoContact",
                schema: "Application",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Notes = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsSendToAvaya = table.Column<bool>(type: "bit", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ScheduledCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDesable = table.Column<bool>(type: "bit", nullable: true),
                    IsUploadedSuccessfully = table.Column<bool>(type: "bit", nullable: false),
                    FileRow = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    DescriptionOthers = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoContact_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Lookup",
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutoContact_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Lookup",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AutoContact_ScheduledCall_ScheduledCallId",
                        column: x => x.ScheduledCallId,
                        principalSchema: "Application",
                        principalTable: "ScheduledCall",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldAction",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldActionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFieldActionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DynamicFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ProcessOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false),
                    NameAr = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    IsStatic = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldAction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldAction_DynamicFunction_DynamicFunctionId",
                        column: x => x.DynamicFunctionId,
                        principalSchema: "Entity",
                        principalTable: "DynamicFunction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityFieldAction_EntityFieldActionGroup_EntityFieldActionGroupId",
                        column: x => x.EntityFieldActionGroupId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldActionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldAction_EntityFieldActionType_EntityFieldActionTypeId",
                        column: x => x.EntityFieldActionTypeId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldActionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldActionGroupConditionGroup",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldActionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ANDorOR = table.Column<bool>(type: "bit", nullable: true),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldActionGroupConditionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionGroupConditionGroup_EntityFieldActionGroup_EntityFieldActionGroupId",
                        column: x => x.EntityFieldActionGroupId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldActionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldActionGroupTriggerType",
                schema: "Entity",
                columns: table => new
                {
                    EntityFieldActionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TriggerTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldActionGroupTriggerType", x => new { x.EntityFieldActionGroupId, x.TriggerTypeId });
                    table.ForeignKey(
                        name: "FK_EntityFieldActionGroupTriggerType_EntityFieldActionGroup_EntityFieldActionGroupId",
                        column: x => x.EntityFieldActionGroupId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldActionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionGroupTriggerType_TriggerType_TriggerTypeId",
                        column: x => x.TriggerTypeId,
                        principalSchema: "Lookup",
                        principalTable: "TriggerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldCondition",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldConditionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstSideRelatedToEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstSideFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondSideRelatedToEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CondetionValue = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ANDorOR = table.Column<bool>(type: "bit", nullable: true),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldCondition_ConditionType_ConditionTypeId",
                        column: x => x.ConditionTypeId,
                        principalSchema: "Lookup",
                        principalTable: "ConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldCondition_EntityFieldConditionGroup_EntityFieldConditionGroupId",
                        column: x => x.EntityFieldConditionGroupId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldConditionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldCondition_Entity_FirstSideRelatedToEntityId",
                        column: x => x.FirstSideRelatedToEntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldCondition_Entity_SecondSideRelatedToEntityId",
                        column: x => x.SecondSideRelatedToEntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldOptionConditionGroup",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldOptionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionForId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ANDorOR = table.Column<bool>(type: "bit", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldOptionConditionGroup", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldOptionConditionGroup_ConditionFor_ConditionForId",
                        column: x => x.ConditionForId,
                        principalSchema: "Lookup",
                        principalTable: "ConditionFor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldOptionConditionGroup_EntityFieldOption_EntityFieldOptionId",
                        column: x => x.EntityFieldOptionId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldOption",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pim_contact_attempts_history",
                schema: "Log",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    Pim_session_id = table.Column<long>(type: "bigint", nullable: false),
                    Completion_Code_id = table.Column<int>(type: "int", nullable: false),
                    Completion_Code_Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Completion_Code_Name_Ar = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Sys_completion_code_id = table.Column<int>(type: "int", nullable: true),
                    Contact_attempt_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Last_nw_disposition_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Call_start_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Call_completion_time = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Agent_id = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Campaign_id = table.Column<int>(type: "int", nullable: true),
                    Campaign_list_id = table.Column<int>(type: "int", nullable: true),
                    CallDuration = table.Column<double>(type: "float", nullable: false),
                    IsSuccess = table.Column<bool>(type: "bit", nullable: false),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    HistoricalCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AutoContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pim_contact_attempts_history", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pim_contact_attempts_history_AutoContact_AutoContactId",
                        column: x => x.AutoContactId,
                        principalSchema: "Application",
                        principalTable: "AutoContact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pim_contact_attempts_history_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Lookup",
                        principalTable: "Campaign",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pim_contact_attempts_history_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Lookup",
                        principalTable: "Category",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pim_contact_attempts_history_Contact_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "Application",
                        principalTable: "Contact",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pim_contact_attempts_history_HistoricalCall_HistoricalCallId",
                        column: x => x.HistoricalCallId,
                        principalSchema: "Application",
                        principalTable: "HistoricalCall",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Pim_contact_attempts_history_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldActionDynamicFunction",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DynamicFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldActionDynamicFunction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionDynamicFunction_DynamicFunction_DynamicFunctionId",
                        column: x => x.DynamicFunctionId,
                        principalSchema: "Entity",
                        principalTable: "DynamicFunction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionDynamicFunction_EntityFieldAction_EntityFieldActionId",
                        column: x => x.EntityFieldActionId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldActionField",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFieldActionTypeRequiredFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldActionField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionField_EntityFieldActionTypeRequiredField_EntityFieldActionTypeRequiredFieldId",
                        column: x => x.EntityFieldActionTypeRequiredFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldActionTypeRequiredField",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionField_EntityFieldAction_EntityFieldActionId",
                        column: x => x.EntityFieldActionId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionField_EntityField_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityField",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldActionGroupCondition",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldActionGroupConditionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstSideRelatedToEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstSideFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondSideRelatedToEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CondetionValue = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ANDorOR = table.Column<bool>(type: "bit", nullable: true),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    ProcessOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldActionGroupCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionGroupCondition_ConditionType_ConditionTypeId",
                        column: x => x.ConditionTypeId,
                        principalSchema: "Lookup",
                        principalTable: "ConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionGroupCondition_EntityFieldActionGroupConditionGroup_EntityFieldActionGroupConditionGroupId",
                        column: x => x.EntityFieldActionGroupConditionGroupId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldActionGroupConditionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionGroupCondition_Entity_FirstSideRelatedToEntityId",
                        column: x => x.FirstSideRelatedToEntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionGroupCondition_Entity_SecondSideRelatedToEntityId",
                        column: x => x.SecondSideRelatedToEntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldOptionCondition",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldOptionConditionGroupId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstSideRelatedToEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstSideFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConditionTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SecondSideRelatedToEntityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CondetionValue = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: true),
                    ANDorOR = table.Column<bool>(type: "bit", nullable: true),
                    ViewOrder = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldOptionCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldOptionCondition_ConditionType_ConditionTypeId",
                        column: x => x.ConditionTypeId,
                        principalSchema: "Lookup",
                        principalTable: "ConditionType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldOptionCondition_EntityFieldOptionConditionGroup_EntityFieldOptionConditionGroupId",
                        column: x => x.EntityFieldOptionConditionGroupId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldOptionConditionGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldOptionCondition_Entity_FirstSideRelatedToEntityId",
                        column: x => x.FirstSideRelatedToEntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldOptionCondition_Entity_SecondSideRelatedToEntityId",
                        column: x => x.SecondSideRelatedToEntityId,
                        principalSchema: "Entity",
                        principalTable: "Entity",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldActionDynamicFunctionParameter",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DynamicFunctionParameterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EntityFieldActionDynamicFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldActionDynamicFunctionParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionDynamicFunctionParameter_DynamicFunctionParameter_DynamicFunctionParameterId",
                        column: x => x.DynamicFunctionParameterId,
                        principalSchema: "Entity",
                        principalTable: "DynamicFunctionParameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionDynamicFunctionParameter_EntityFieldActionDynamicFunction_EntityFieldActionDynamicFunctionId",
                        column: x => x.EntityFieldActionDynamicFunctionId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldActionDynamicFunction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityFieldActionDynamicFunctionParameter_EntityFieldAction_EntityFieldActionId",
                        column: x => x.EntityFieldActionId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionDynamicFunctionParameter_EntityField_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityField",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EntityFieldActionDynamicFunctionResult",
                schema: "Entity",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    EntityFieldActionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DynamicFunctionResultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EntityFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsResultToNotification = table.Column<bool>(type: "bit", nullable: true),
                    IsPathResult = table.Column<bool>(type: "bit", nullable: true),
                    IsPathValue = table.Column<bool>(type: "bit", nullable: true),
                    EntityFieldActionDynamicFunctionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntityFieldActionDynamicFunctionResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionDynamicFunctionResult_DynamicFunctionResult_DynamicFunctionResultId",
                        column: x => x.DynamicFunctionResultId,
                        principalSchema: "Entity",
                        principalTable: "DynamicFunctionResult",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionDynamicFunctionResult_EntityFieldActionDynamicFunction_EntityFieldActionDynamicFunctionId",
                        column: x => x.EntityFieldActionDynamicFunctionId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldActionDynamicFunction",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EntityFieldActionDynamicFunctionResult_EntityFieldAction_EntityFieldActionId",
                        column: x => x.EntityFieldActionId,
                        principalSchema: "Entity",
                        principalTable: "EntityFieldAction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EntityFieldActionDynamicFunctionResult_EntityField_EntityFieldId",
                        column: x => x.EntityFieldId,
                        principalSchema: "Entity",
                        principalTable: "EntityField",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "CallStatus",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "IsStatic", "LastModifiedByUserId", "LastModifiedOn", "NameAr", "NameEn", "StateCode", "ViewOrder" },
                values: new object[,]
                {
                    { new Guid("0c027c7d-59a2-4319-a876-b22015611f97"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مجدولة الآن", "Queued In System", (byte)1, 1 },
                    { new Guid("123c61d3-de6b-4385-bb40-0ce35ecb4625"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "غير ناجحة (التنبؤي)", "Scheduled In Dialer", (byte)1, 1 },
                    { new Guid("29dc61d3-de6b-4385-bb40-0ce35ecb4625"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مجدولة تاريخياً (التنبؤي)", "Scheduled In Dialer", (byte)1, 1 },
                    { new Guid("2cd4cc0e-afbd-4a72-b930-8911662a4fcf"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "إعادة اتصال", "Recall", (byte)1, 1 },
                    { new Guid("75bad3f5-23cb-47e7-8485-a83e14e325d3"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مسندة", "Assigned", (byte)1, 1 },
                    { new Guid("9d7064b9-a41a-4b76-9889-d26750f3eca6"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مجدولة الآن (التنبؤي)", "Queued In Dialer", (byte)1, 1 },
                    { new Guid("b8151e6f-6415-4b46-9b74-5dae2e47d072"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "ناجحة", "Success", (byte)1, 1 },
                    { new Guid("d252adcd-cb7c-45bb-a1f7-d7905a14e348"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مجدولة تاريخياً", "Scheduled In System", (byte)1, 1 },
                    { new Guid("df1523df-5fc3-41fc-a2d0-b3937ca4228f"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "غير ناجحة", "Not Success", (byte)1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "CallType",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "IsStatic", "LastModifiedByUserId", "LastModifiedOn", "NameAr", "NameEn", "StateCode", "ViewOrder" },
                values: new object[,]
                {
                    { new Guid("331c1515-23d2-452b-82f5-5f2999582f8d"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مكالمة تحصيل - متابعة", "Collecting Call Followup", (byte)1, 1 },
                    { new Guid("3ac144c5-5ea4-4ca3-a8a3-0b2f173dd6db"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مكالمة تحصيل", "Collecting Call", (byte)1, 1 },
                    { new Guid("b22c1515-23d2-452b-82f5-5f2999582f8d"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مكالمة تبليغ", "Notification Call", (byte)1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "ConditionFor",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "IsStatic", "LastModifiedByUserId", "LastModifiedOn", "NameAr", "NameEn", "StateCode", "ViewOrder" },
                values: new object[,]
                {
                    { new Guid("32ce529a-107e-4242-bd48-00d87d85e68c"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "عرض", "Show", (byte)1, 1 },
                    { new Guid("5e6a7ddf-d4a2-49d8-81b1-195bc9eb63b6"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "تعطيل", "Disabel", (byte)1, 1 },
                    { new Guid("8ce24129-c34f-4ed2-94ae-1a8d8fb81182"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "إجباري", "Required", (byte)1, 1 },
                    { new Guid("b1d9a26b-745a-4a5e-bfb7-b3519a7c0e47"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "اختيار", "Select", (byte)1, 1 },
                    { new Guid("ce8d37c5-66c8-41e9-ade0-cb8d6d13ffa9"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "تنفيذ", "Execute", (byte)1, 1 },
                    { new Guid("df704671-910c-4625-8ce7-577aa2ca95ad"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "للقراءة فقط", "ReadOnly", (byte)1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "ConditionType",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "IsStatic", "LastModifiedByUserId", "LastModifiedOn", "NameAr", "NameEn", "StateCode", "ViewOrder" },
                values: new object[,]
                {
                    { new Guid("059f4279-53da-4d31-bac3-cf75092b9e44"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "يحتوي", "Contain", (byte)1, 1 },
                    { new Guid("0f979f1c-4419-420e-81d2-0ce99048049f"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "غير فارغ", "Not Null", (byte)1, 1 },
                    { new Guid("45fa4a17-8a36-4a2b-a5fb-c389f65c6bf9"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "ضمن", "In", (byte)1, 1 },
                    { new Guid("47d75e03-d7a1-467f-a870-5cf451b552a6"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "فارغ", "Null", (byte)1, 1 },
                    { new Guid("55899e39-2eb5-42c4-a090-f719457b865f"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أكبر من أو يساوي", "More Than Or Equal", (byte)1, 1 },
                    { new Guid("7cbdb20f-8790-4193-8bca-4adb1ea743a9"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "يساوي", "Equal", (byte)1, 1 },
                    { new Guid("b47b64a4-da48-4d66-9972-532c8f23eec3"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أقل من", "Less Than", (byte)1, 1 },
                    { new Guid("c03cfa6a-8125-458b-85dc-babc046417bf"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أكبر من", "MoreThan", (byte)1, 1 },
                    { new Guid("df540314-dfa9-4a2d-bc82-863bbb77b271"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "لا يساوي", "Not Equal", (byte)1, 1 },
                    { new Guid("f29b0cea-10f5-4a62-90e2-6377f644b2a3"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أقل من أو يساوي", "Less Than Or Equal", (byte)1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Entity",
                table: "EntityFieldActionType",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "EntityId", "IsStatic", "LastModifiedByUserId", "LastModifiedOn", "NameAr", "NameEn", "StateCode", "ViewOrder" },
                values: new object[] { new Guid("1f4398fe-7940-4310-8149-40f71b5bb97b"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, null, null, "تنفيذ إجراء ديناميكي", "Execute Dynamic Function", (byte)1, 1 });

            migrationBuilder.InsertData(
                schema: "Entity",
                table: "EntityType",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "IsStatic", "LastModifiedByUserId", "LastModifiedOn", "NameAr", "NameEn", "SchemaName", "StateCode", "TabelName", "ViewOrder" },
                values: new object[,]
                {
                    { new Guid("04e4943a-0d56-4ea9-b878-926d05c435f9"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "صلاحيات المستخدمين", "User Permission", "Identity", (byte)1, "UserPermission", 0 },
                    { new Guid("1a9b70a2-1d02-49bc-9aeb-64cee6cb9b09"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "حلول القرض", "Loan Time Status", "Lookup", (byte)1, "LoanTimeStatus", 0 },
                    { new Guid("1c28bc30-d216-4812-a292-8e8e2c02c5e1"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "التصنيفات", "Category", "Lookup", (byte)1, "Category", 0 },
                    { new Guid("1e648ce3-267c-44ad-940a-9aa3148a8519"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الحملات", "Campaign", "Lookup", (byte)1, "Campaign", 0 },
                    { new Guid("1fcc2bfb-bb08-44f3-b99e-804c6ab5df8d"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "سجلات تحديثات العقود", "Contract History", "Log", (byte)1, "ContractHistory", 0 },
                    { new Guid("25254ee1-f98c-4800-a3be-bff0f306b6bf"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أنواع التعثرات", "Stumble Type", "Lookup", (byte)1, "StumbleType", 0 },
                    { new Guid("2632b95e-2ff7-4b4f-9422-3ecebd856fc9"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أنواع الحقول", "Field Type", "Lookup", (byte)1, "FieldType", 0 },
                    { new Guid("296f3487-44a7-4237-96d0-c2aeaa7ecaeb"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "المستخدمين", "User", "Identity", (byte)1, "User", 0 },
                    { new Guid("316168b0-dd10-457a-9689-a9ce82be9073"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أجزاء معايير تقييم المكالمات", "Call Quality Criteria Part", "Application", (byte)1, "CallQualityCriteriaPart", 0 },
                    { new Guid("357ab406-6e13-48f1-be88-6c1cbd97654d"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الأجناس", "Gender", "Lookup", (byte)1, "Gender", 0 },
                    { new Guid("357d1ce2-3631-4021-9f49-ddb8be7fbd0f"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مسارات التصنيفات", "Category Path", "Lookup", (byte)1, "CategoryPath", 0 },
                    { new Guid("376ccb5d-408f-4c15-b0f6-289f5b4c2f99"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الفرق", "Team", "Lookup", (byte)1, "Team", 0 },
                    { new Guid("38920507-73c0-4035-8639-d4f66bee9952"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "صلاحيات الأدوار الوظيفية", "Role Permission", "Identity", (byte)1, "RolePermission", 0 },
                    { new Guid("38a84837-16ce-4fbb-99b2-5a595c95ecf0"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "المعلومات الشخصية", "Personal Info", "Application", (byte)1, "PersonalInfo", 0 },
                    { new Guid("38ae3821-99b4-4167-813f-a51c9a36af92"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "التعليقات على المكالمات التاريخية", "Historical Call Comment", "Application", (byte)1, "HistoricalCallComment", 0 },
                    { new Guid("4605c6b9-afdc-4baa-bac9-2ed38a16cf8e"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "قطاع العمل", "Employer Sector", "Lookup", (byte)1, "EmployerSector", 0 },
                    { new Guid("48564202-568f-4e84-94d0-518cc61631cd"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أنواع الرضى", "Satisfaction", "Lookup", (byte)1, "Satisfaction", 0 },
                    { new Guid("50e6cef1-da4e-4bb3-8e26-c8d80ce41e20"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الجنسيات", "Nationality", "Lookup", (byte)1, "Nationality", 0 },
                    { new Guid("60c47180-b24f-47ca-bd37-77edfaf257f0"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أنواع تسجيلات المستخدمين", "Registration Type", "Lookup", (byte)1, "RegistrationType", 0 },
                    { new Guid("63e0a8a6-43e3-4718-b08a-e0f80f7f7f56"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "المكالمات التاريخية", "Historical Call", "Application", (byte)1, "HistoricalCall", 0 },
                    { new Guid("6509294e-df52-4524-826c-10e58e5b67d5"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الإعدادات", "Setting", "Application", (byte)1, "Setting", 0 },
                    { new Guid("6fc1c72c-780a-4877-bf65-803f913d5190"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "حالات المكالمات", "Call Status", "Lookup", (byte)1, "CallStatus", 0 },
                    { new Guid("6ffe76fa-7c3b-4ff9-9fb5-e9851beb5327"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الشروط لـ", "Condition For", "Lookup", (byte)1, "ConditionFor", 0 },
                    { new Guid("708593c8-baca-409c-b9be-325e05f48123"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أنواع الأحداث على حقول الكيانات", "Entity Field Action Type", "Entity", (byte)1, "EntityFieldActionType", 0 },
                    { new Guid("70ebe78c-f361-46e6-be83-faf7affd693e"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "نوع العقد", "Contract Type", "Lookup", (byte)1, "ContractStatus", 0 },
                    { new Guid("73218b82-b075-4b0d-a3f0-fcb4a456e96e"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "معايير تقييم المكالمة", "Call Quality Criteria", "Application", (byte)1, "CallQualityCriteria", 0 },
                    { new Guid("77527367-7cfd-416c-be58-9780bdad879b"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "سجلات تحديثات المعلومات الشخصية", "Personal Info Log", "Log", (byte)1, "PersonalInfoLog", 0 },
                    { new Guid("7c535ca0-56c0-4b53-a3b3-c66ef12d389e"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أنواع المكالمات", "Call Type", "Lookup", (byte)1, "CallType", 0 },
                    { new Guid("7e532c9d-8101-4294-8c73-cf04f0c64c95"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "فرق المستخدمين", "User Teams", "Identity", (byte)1, "UserTeams", 0 },
                    { new Guid("83f6c13b-64c4-4ad1-af46-f55a7118e2c0"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "المكالمات المجدولة", "Scheduled Call", "Application", (byte)1, "ScheduledCall", 0 },
                    { new Guid("872fb63a-a1ab-4031-ac30-5653b356fde9"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "العقود", "Contract", "Application", (byte)1, "Contract", 0 },
                    { new Guid("90431599-2fbf-4c2c-98ee-d20c469551bc"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "سجلات تحميل المستفيدين", "Contact Uploading Log", "Log", (byte)1, "ContactUploadingLog", 0 },
                    { new Guid("90e20a39-b72b-418b-beff-658ad0fbd7b5"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مسارات التصنيف للمستخدمين", "User Category Path", "Identity", (byte)1, "UserCategoryPath", 0 },
                    { new Guid("91b2ee8a-4126-4589-901b-993688d9efda"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "فاتورة المكالمة", "Call Bill", "Application", (byte)1, "CallBill", 0 },
                    { new Guid("92aabbd9-b890-4118-9ce8-c8e6862dc11e"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الصلاحيات", "Permission", "Lookup", (byte)1, "Permission", 0 },
                    { new Guid("96bd359e-5060-41b7-b15c-041245df0a92"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "العملاء", "Contacts", "Application", (byte)1, "Contact", 0 },
                    { new Guid("a56cec1b-44e5-4fa3-b42d-485ec5eb37aa"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الدوال الديناميكية", "Dynamic Function", "Entity", (byte)1, "DynamicFunction", 0 },
                    { new Guid("a596f09b-e63f-42d8-86ca-875fd6eaf6d3"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "التقارير الديناميكية", "Dynamic Report", "Entity", (byte)1, "DynamicReport", 0 },
                    { new Guid("b3918956-0106-4c6a-8e79-b02a5d9759c5"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أنواع الإعدادات", "Setting Type", "Lookup", (byte)1, "SettingType", 0 },
                    { new Guid("b67c5548-7098-48de-a86c-2ced19a40471"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الأدوار الوظيفية", "Role", "Identity", (byte)1, "Role", 0 },
                    { new Guid("b730380a-8f15-423a-884f-c2249eb2d58d"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الكيانات", "Entity", "Entity", (byte)1, "Entity", 0 },
                    { new Guid("ba4c4a9e-7a21-4183-ae97-4bc322581b20"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "إجراءات النظام", "System Progress", "Application", (byte)1, "SystemProgress", 0 },
                    { new Guid("bc800b0e-8743-4e3d-86a3-7ce3946bc76b"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "بوابات الدفع", "Payment Gateway", "Lookup", (byte)1, "PaymentGateway", 0 },
                    { new Guid("bec9374f-79bd-4b85-a476-5ac32f5e7e2f"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "المدفوعات", "Payment", "Application", (byte)1, "Payment", 0 },
                    { new Guid("c32068b2-e391-460d-9e08-1d92bc33746b"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الأولويات", "Priority", "Lookup", (byte)1, "Priority", 0 },
                    { new Guid("cad78edc-6da3-4b03-8cfc-13ddcc229440"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "تقييم المكالمة", "Call Quality", "Application", (byte)1, "CallQuality", 0 },
                    { new Guid("caec39b5-2bfe-43d7-8fb8-ccd455f66312"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "المدن", "City", "Lookup", (byte)1, "City", 0 },
                    { new Guid("caecbb8c-a116-49c8-8d05-1e75ca9b573f"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أنواع الشروط", "Condition Type", "Lookup", (byte)1, "ConditionType", 0 },
                    { new Guid("cb444b0b-2c22-41bd-86db-131e401e5f71"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "طرق الدفع", "Payment Method", "Lookup", (byte)1, "PaymentMethod", 0 },
                    { new Guid("cb4ef3ce-fae8-4828-881c-f4b02f96f855"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أنواع الأحداث على الكيانات", "Entity Action Type", "Entity", (byte)1, "EntityActionType", 0 },
                    { new Guid("d1fded5f-88ca-4537-80f8-ddb6bf5b6ed5"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "إعدادات المستخدمين", "User Setting", "Identity", (byte)1, "UserSetting", 0 },
                    { new Guid("dacf4e52-019e-4bda-ae72-f22b135cc9b8"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "حالة العقد", "Contract Status", "Lookup", (byte)1, "ContractType", 0 },
                    { new Guid("dd6a0c1a-9c1b-4f8b-af33-1907c0e6e024"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "أنواع الإجراءات", "Trigger Type", "Lookup", (byte)1, "TriggerType", 0 },
                    { new Guid("e857c3ca-be15-41af-8f93-306b94c85cfc"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "جهة العمل", "Employer Type", "Lookup", (byte)1, "EmployerType", 0 },
                    { new Guid("e8aa01af-6578-4912-b9cb-6601779ec1b8"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "الملاءة المالية", "Solvency", "Lookup", (byte)1, "Solvency", 0 },
                    { new Guid("f0a695d9-a73c-4e2c-992d-c23c85853e70"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "البلاد", "Country", "Lookup", (byte)1, "Country", 0 },
                    { new Guid("f7a5b0cb-b0c7-4744-81c3-d9b3f67a6612"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "حالة التقاعد", "Retirement Status", "Lookup", (byte)1, "RetirementStatus", 0 },
                    { new Guid("f91ccfaf-9260-4baf-b9df-9f27715ac092"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "سجلات إرسال الرسائل النصية", "SMS Sent Log", "Log", (byte)1, "SMSSentLog", 0 },
                    { new Guid("f9ffd0b6-1223-43a9-b214-d5d0b9498902"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "حالة التأمينات", "Insurance Status", "Lookup", (byte)1, "InsuranceStatus", 0 }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "FieldType",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "IsStatic", "LastModifiedByUserId", "LastModifiedOn", "NameAr", "NameEn", "StateCode", "ViewOrder" },
                values: new object[,]
                {
                    { new Guid("061beaca-01b1-443a-a5f9-bd636b8ee9b1"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "ملف", "File", (byte)1, 1 },
                    { new Guid("0caa25d9-befb-4096-9041-c05e7b4da188"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "خيارات متعددة (CheckBox)", "CheckBox Group", (byte)1, 1 },
                    { new Guid("24a3e2ce-c8d2-485d-9bfb-028ad5ae5444"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "وقت", "Time", (byte)1, 1 },
                    { new Guid("2bccee4a-8236-486e-9691-da019d679600"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "رقم", "Number", (byte)1, 1 },
                    { new Guid("45de289b-67b3-406f-aa95-b01a857fdf74"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "عنوان", "Label", (byte)1, 1 },
                    { new Guid("61e80126-233e-4143-94bc-e906c1e64b03"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "نص كبير", "Text Area", (byte)1, 1 },
                    { new Guid("66326b14-7fa5-45f4-b3df-92f364b146d8"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "خيار اختياري (CheckBox)", "CheckBox", (byte)1, 1 },
                    { new Guid("92a1f535-6c86-4489-a494-afcd1165334a"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "زر", "Button", (byte)1, 1 },
                    { new Guid("9eaed8a2-517b-48c8-bfb8-eb2344a79804"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "خيارات متعددة (Select)", "MultibelSelect", (byte)1, 1 },
                    { new Guid("b040939f-d7eb-47cc-9a5a-f063db7fdd8e"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "قائمة نصية", "View List", (byte)1, 1 },
                    { new Guid("bc557ce6-adb6-4a98-9214-639534862014"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "نص", "Text", (byte)1, 1 },
                    { new Guid("d448dd89-168e-47eb-9425-36a4074cd853"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "اختيار واحد (Select)", "One Select", (byte)1, 1 },
                    { new Guid("d4730e56-dcc3-42e8-af4a-a6b66edbb728"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "تاريخ ووقت", "DateTime", (byte)1, 1 },
                    { new Guid("f9e4efb5-f7c4-44d5-9c35-febfbfc7f834"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "تاريخ", "Date", (byte)1, 1 },
                    { new Guid("fb14e732-8d25-4ffb-bd63-b5e6e09cf231"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "اختيار واحد (Radio)", "Radio Button", (byte)1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Application",
                table: "PersonalInfo",
                columns: new[] { "Id", "CityId", "CreatedByUserId", "CreatedOn", "Email", "FullNameAr", "IdentityNumber", "LastModifiedByUserId", "LastModifiedOn", "Notes", "PhoneNumber", "PhoneNumber2", "StateCode" },
                values: new object[,]
                {
                    { new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), null, null, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "System@System", "النظام", null, null, null, null, null, null, (byte)1 },
                    { new Guid("d741da85-bd74-42cc-8d22-8176f49580e6"), null, null, new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "POMApplicationUser@System", "نظام الاتصال التنبؤي", null, null, null, null, null, null, (byte)1 }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "Priority",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "IsStatic", "LastModifiedByUserId", "LastModifiedOn", "NameAr", "NameEn", "Number", "StateCode", "ViewOrder" },
                values: new object[,]
                {
                    { new Guid("5f2c9033-4842-4797-8da8-c3dffb331609"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مهم جداً", "Important", 3, (byte)1, 3 },
                    { new Guid("5f2c90ee-4842-4797-8da8-c3dffb331609"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "استثنائي جداً", "Very Special", 1, (byte)1, 1 },
                    { new Guid("5f2ca633-4842-4797-8da8-c3dffb331609"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "استثنائي", "Special", 2, (byte)1, 2 },
                    { new Guid("64cd40dd-747a-46c7-a91d-123febad6d44"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "غير مهم", "Low", 6, (byte)1, 6 },
                    { new Guid("6aeb7f2a-5a60-4086-8320-55120317806e"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "عادي", "Normal", 5, (byte)1, 5 },
                    { new Guid("71bd4bae-361c-41a9-bd54-22c29eea602a"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "غير مهم أبداً", "Very Low", 7, (byte)1, 7 },
                    { new Guid("b44b633e-a94a-4dac-a093-5650aa8184eb"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "مهم", "Important", 4, (byte)1, 4 }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDefualt", "IsStatic", "Name", "NameAr", "NormalizedName", "StateCode" },
                values: new object[,]
                {
                    { new Guid("24e65b31-a815-4fb0-a5fa-4b78aab03c72"), "4f421dc4-9f03-4d54-898a-caf3ad286a2d", false, true, "SuperAdmin", "مسؤول النظام", "superadmin", (byte)0 },
                    { new Guid("5918287c-140d-4938-a8ee-d3a3099ec957"), "6c4191c2-5d95-40d6-bccc-006b7faf8a16", false, true, "Admin", "المسؤول", "admin", (byte)1 },
                    { new Guid("6fdd3e8a-ebfc-4fe5-8a48-ed2bde9fb2ad"), "f9cb65bf-3071-42ff-a952-a166e99077e3", false, true, "Leader", "قائد الفريق", "leader", (byte)1 },
                    { new Guid("746f79ee-bc4a-4e58-95d2-01c73cf3a868"), "10a464f7-65af-4423-9325-49482bf51fed", false, true, "Reporter", "منظم التقارير", "reporter", (byte)0 },
                    { new Guid("93b91e52-5850-4190-9e87-2a1bfbd81910"), "e3f6e940-5380-41eb-98be-601439d614e9", false, true, "Supervisor", "المشرف", "supervisor", (byte)1 },
                    { new Guid("ad0b3b57-295f-4312-bba1-b09a11865237"), "2bb13d4b-8187-4420-998a-335182d1a71e", true, true, "Employee", "موظف", "employee", (byte)1 },
                    { new Guid("b57d5da1-98e7-4c98-ac00-104919cb8e8d"), "1e0a9742-eedd-4389-a1b3-5c9fd3e6ca61", false, true, "System", "النظام", "system", (byte)0 }
                });

            migrationBuilder.InsertData(
                schema: "Lookup",
                table: "TriggerType",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "IsStatic", "LastModifiedByUserId", "LastModifiedOn", "NameAr", "NameEn", "StateCode", "ViewOrder" },
                values: new object[,]
                {
                    { new Guid("125572ee-3743-4d03-b4f8-f003fa3d22ad"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "عند التحديث", "On Update", (byte)1, 1 },
                    { new Guid("2bab8ff2-8ddf-4691-b704-7c29526605f2"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "عند الإنشاء", "On Create", (byte)1, 1 },
                    { new Guid("2fdd7ad8-a254-490e-ba65-cd4971811658"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "عند الحذف", "On Delete", (byte)1, 1 },
                    { new Guid("4ea813d4-a0c6-4ee2-97d6-8f5756e23896"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "عند التعطيل", "On DeActivate", (byte)1, 1 },
                    { new Guid("51a7be15-439d-4300-aea3-0b6c9dd91b57"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "عند التفعيل", "On Activate", (byte)1, 1 },
                    { new Guid("78055fed-079a-43b2-a0b3-69fc7f38744d"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "عند الإرسال", "On Submit", (byte)1, 1 },
                    { new Guid("817e4b7f-c425-4774-ba93-ca4aedea160d"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "عند الضغط على", "On Click", (byte)1, 1 },
                    { new Guid("8e40406e-7ab8-405c-b6c8-3e4cd7db5ef3"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), true, null, null, "عند الاستعراض", "On View", (byte)1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Entity",
                table: "EntityActionType",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "EntityTypeId", "IsStatic", "LastModifiedByUserId", "LastModifiedOn", "NameAr", "NameEn", "StateCode", "ViewOrder" },
                values: new object[,]
                {
                    { new Guid("0280d3e4-0b91-4a09-af6c-9493365722e9"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("357d1ce2-3631-4021-9f49-ddb8be7fbd0f"), true, null, null, "حفظ نتيجة المكالمة بحالة ناجحة", "Save Call In Success Status", (byte)1, 1 },
                    { new Guid("090e1ae7-3878-489a-ab85-8c9affb4a913"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("357d1ce2-3631-4021-9f49-ddb8be7fbd0f"), true, null, null, "جدولة مكالمة جديدة", "Schedule New Call", (byte)1, 1 },
                    { new Guid("12121212-1212-42d1-a92a-aa3e93867f79"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("357d1ce2-3631-4021-9f49-ddb8be7fbd0f"), true, null, null, "إشعار بإنشاء فاتورة", "Notify On Bill Created", (byte)1, 1 },
                    { new Guid("63a13eb8-3949-42d1-a92a-aa3e93867f79"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("357d1ce2-3631-4021-9f49-ddb8be7fbd0f"), true, null, null, "حفظ نتيجة المكالمة بحالة إعادة اتصال", "Save Call In Recall Status", (byte)1, 1 },
                    { new Guid("d8ee0ba8-5f2a-4691-a388-8616dbdf39ba"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("357d1ce2-3631-4021-9f49-ddb8be7fbd0f"), true, null, null, "حفظ نتيجة المكالمة بحالة غير ناجحة", "Save Call In Not Success Status", (byte)1, 1 }
                });

            migrationBuilder.InsertData(
                schema: "Identity",
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedByUserId", "CreatedOn", "Email", "EmailConfirmed", "EmployeeNumber", "Extension", "IsHasSpecialPermissions", "IsLoggedIn", "IsStatic", "LastModifiedByUserId", "LastModifiedOn", "LatestLoggedInDateTime", "LatestPasswordChangedDateTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PasswordHint", "PersonalInfoId", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "StateCode", "TwoFactorEnabled", "UserName", "WrongPassTry" },
                values: new object[] { new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), 0, "76c52b9b-21df-4f45-8220-d2755f39860c", new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "System@System", false, "1", null, false, false, true, null, null, null, null, false, null, null, "System", null, null, new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), null, false, null, (byte)1, false, "System", null });

            migrationBuilder.InsertData(
                schema: "Entity",
                table: "EntityActionTypeRequiredField",
                columns: new[] { "Id", "CreatedByUserId", "CreatedOn", "EntityActionTypeId", "FieldName", "FieldShouldRelatedToEntityTypeId", "FieldTypeId", "LastModifiedByUserId", "LastModifiedOn", "StateCode" },
                values: new object[,]
                {
                    { new Guid("17b7dc0b-afe2-4ff5-b3d7-29cb93e04b74"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("090e1ae7-3878-489a-ab85-8c9affb4a913"), "حقل تاريخ جدولة المكالمة الجديدة", null, new Guid("d4730e56-dcc3-42e8-af4a-a6b66edbb728"), null, null, (byte)1 },
                    { new Guid("dfbd996e-4e65-4261-b4d2-d5fd584035c6"), new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"), new DateTime(2021, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("090e1ae7-3878-489a-ab85-8c9affb4a913"), "حقل نوع المسار المراد إعادة الجدولة عليه", new Guid("357d1ce2-3631-4021-9f49-ddb8be7fbd0f"), new Guid("d4730e56-dcc3-42e8-af4a-a6b66edbb728"), null, null, (byte)1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoContact_CampaignId",
                schema: "Application",
                table: "AutoContact",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoContact_CategoryId",
                schema: "Application",
                table: "AutoContact",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoContact_ScheduledCallId",
                schema: "Application",
                table: "AutoContact",
                column: "ScheduledCallId");

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_PriorityId",
                schema: "Lookup",
                table: "Campaign",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_AVAYAAURACampaignPredictiveId",
                schema: "Lookup",
                table: "Category",
                column: "AVAYAAURACampaignPredictiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CallCategoryMainId",
                schema: "Lookup",
                table: "Category",
                column: "CallCategoryMainId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CallTypeId",
                schema: "Lookup",
                table: "Category",
                column: "CallTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_CategoryPathId",
                schema: "Lookup",
                table: "Category",
                column: "CategoryPathId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_PriorityId",
                schema: "Lookup",
                table: "Category",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_Contact_ContactCategoryId",
                schema: "Application",
                table: "Contact",
                column: "ContactCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUploadingLog_CampaignId",
                schema: "Log",
                table: "ContactUploadingLog",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUploadingLog_CategoryId",
                schema: "Log",
                table: "ContactUploadingLog",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUploadingLog_ContactId",
                schema: "Log",
                table: "ContactUploadingLog",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUploadingLog_PriorityId",
                schema: "Log",
                table: "ContactUploadingLog",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicFunctionParameter_DynamicFunctionId",
                schema: "Entity",
                table: "DynamicFunctionParameter",
                column: "DynamicFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicFunctionResult_DynamicFunctionId",
                schema: "Entity",
                table: "DynamicFunctionResult",
                column: "DynamicFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicReport_EntityId",
                schema: "Entity",
                table: "DynamicReport",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicReportField_DynamicReportId",
                schema: "Entity",
                table: "DynamicReportField",
                column: "DynamicReportId");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicReportField_EntityMapId",
                schema: "Entity",
                table: "DynamicReportField",
                column: "EntityMapId");

            migrationBuilder.CreateIndex(
                name: "IX_Entity_EntityTypeId",
                schema: "Entity",
                table: "Entity",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAction_DynamicFunctionId",
                schema: "Entity",
                table: "EntityAction",
                column: "DynamicFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAction_EntityActionGroupId",
                schema: "Entity",
                table: "EntityAction",
                column: "EntityActionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityAction_EntityActionTypeId",
                schema: "Entity",
                table: "EntityAction",
                column: "EntityActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionDynamicFunctionParameter_DynamicFunctionParameterId",
                schema: "Entity",
                table: "EntityActionDynamicFunctionParameter",
                column: "DynamicFunctionParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionDynamicFunctionParameter_EntityActionId",
                schema: "Entity",
                table: "EntityActionDynamicFunctionParameter",
                column: "EntityActionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionDynamicFunctionParameter_EntityFieldId",
                schema: "Entity",
                table: "EntityActionDynamicFunctionParameter",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionDynamicFunctionResult_DynamicFunctionResultId",
                schema: "Entity",
                table: "EntityActionDynamicFunctionResult",
                column: "DynamicFunctionResultId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionDynamicFunctionResult_EntityActionId",
                schema: "Entity",
                table: "EntityActionDynamicFunctionResult",
                column: "EntityActionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionDynamicFunctionResult_EntityFieldId",
                schema: "Entity",
                table: "EntityActionDynamicFunctionResult",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionField_EntityActionId",
                schema: "Entity",
                table: "EntityActionField",
                column: "EntityActionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionField_EntityActionTypeRequiredFieldId",
                schema: "Entity",
                table: "EntityActionField",
                column: "EntityActionTypeRequiredFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionField_EntityFieldId",
                schema: "Entity",
                table: "EntityActionField",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionGroup_EntityId",
                schema: "Entity",
                table: "EntityActionGroup",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionGroupCondition_ConditionTypeId",
                schema: "Entity",
                table: "EntityActionGroupCondition",
                column: "ConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionGroupCondition_EntityActionGroupConditionGroupId",
                schema: "Entity",
                table: "EntityActionGroupCondition",
                column: "EntityActionGroupConditionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionGroupCondition_FirstSideRelatedToEntityId",
                schema: "Entity",
                table: "EntityActionGroupCondition",
                column: "FirstSideRelatedToEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionGroupCondition_SecondSideRelatedToEntityId",
                schema: "Entity",
                table: "EntityActionGroupCondition",
                column: "SecondSideRelatedToEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionGroupConditionGroup_EntityActionGroupId",
                schema: "Entity",
                table: "EntityActionGroupConditionGroup",
                column: "EntityActionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionGroupTriggerType_TriggerTypeId",
                schema: "Entity",
                table: "EntityActionGroupTriggerType",
                column: "TriggerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionType_EntityTypeId",
                schema: "Entity",
                table: "EntityActionType",
                column: "EntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionTypeRequiredField_EntityActionTypeId",
                schema: "Entity",
                table: "EntityActionTypeRequiredField",
                column: "EntityActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionTypeRequiredField_FieldShouldRelatedToEntityTypeId",
                schema: "Entity",
                table: "EntityActionTypeRequiredField",
                column: "FieldShouldRelatedToEntityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityActionTypeRequiredField_FieldTypeId",
                schema: "Entity",
                table: "EntityActionTypeRequiredField",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityField_EntityFieldGroupId",
                schema: "Entity",
                table: "EntityField",
                column: "EntityFieldGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityField_FieldTypeId",
                schema: "Entity",
                table: "EntityField",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityField_RelatedToEntityId",
                schema: "Entity",
                table: "EntityField",
                column: "RelatedToEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldAction_DynamicFunctionId",
                schema: "Entity",
                table: "EntityFieldAction",
                column: "DynamicFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldAction_EntityFieldActionGroupId",
                schema: "Entity",
                table: "EntityFieldAction",
                column: "EntityFieldActionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldAction_EntityFieldActionTypeId",
                schema: "Entity",
                table: "EntityFieldAction",
                column: "EntityFieldActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionDynamicFunction_DynamicFunctionId",
                schema: "Entity",
                table: "EntityFieldActionDynamicFunction",
                column: "DynamicFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionDynamicFunction_EntityFieldActionId",
                schema: "Entity",
                table: "EntityFieldActionDynamicFunction",
                column: "EntityFieldActionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionDynamicFunctionParameter_DynamicFunctionParameterId",
                schema: "Entity",
                table: "EntityFieldActionDynamicFunctionParameter",
                column: "DynamicFunctionParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionDynamicFunctionParameter_EntityFieldActionDynamicFunctionId",
                schema: "Entity",
                table: "EntityFieldActionDynamicFunctionParameter",
                column: "EntityFieldActionDynamicFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionDynamicFunctionParameter_EntityFieldActionId",
                schema: "Entity",
                table: "EntityFieldActionDynamicFunctionParameter",
                column: "EntityFieldActionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionDynamicFunctionParameter_EntityFieldId",
                schema: "Entity",
                table: "EntityFieldActionDynamicFunctionParameter",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionDynamicFunctionResult_DynamicFunctionResultId",
                schema: "Entity",
                table: "EntityFieldActionDynamicFunctionResult",
                column: "DynamicFunctionResultId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionDynamicFunctionResult_EntityFieldActionDynamicFunctionId",
                schema: "Entity",
                table: "EntityFieldActionDynamicFunctionResult",
                column: "EntityFieldActionDynamicFunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionDynamicFunctionResult_EntityFieldActionId",
                schema: "Entity",
                table: "EntityFieldActionDynamicFunctionResult",
                column: "EntityFieldActionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionDynamicFunctionResult_EntityFieldId",
                schema: "Entity",
                table: "EntityFieldActionDynamicFunctionResult",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionField_EntityFieldActionId",
                schema: "Entity",
                table: "EntityFieldActionField",
                column: "EntityFieldActionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionField_EntityFieldActionTypeRequiredFieldId",
                schema: "Entity",
                table: "EntityFieldActionField",
                column: "EntityFieldActionTypeRequiredFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionField_EntityFieldId",
                schema: "Entity",
                table: "EntityFieldActionField",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionGroup_EntityFieldId",
                schema: "Entity",
                table: "EntityFieldActionGroup",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionGroupCondition_ConditionTypeId",
                schema: "Entity",
                table: "EntityFieldActionGroupCondition",
                column: "ConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionGroupCondition_EntityFieldActionGroupConditionGroupId",
                schema: "Entity",
                table: "EntityFieldActionGroupCondition",
                column: "EntityFieldActionGroupConditionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionGroupCondition_FirstSideRelatedToEntityId",
                schema: "Entity",
                table: "EntityFieldActionGroupCondition",
                column: "FirstSideRelatedToEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionGroupCondition_SecondSideRelatedToEntityId",
                schema: "Entity",
                table: "EntityFieldActionGroupCondition",
                column: "SecondSideRelatedToEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionGroupConditionGroup_EntityFieldActionGroupId",
                schema: "Entity",
                table: "EntityFieldActionGroupConditionGroup",
                column: "EntityFieldActionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionGroupTriggerType_TriggerTypeId",
                schema: "Entity",
                table: "EntityFieldActionGroupTriggerType",
                column: "TriggerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionType_EntityId",
                schema: "Entity",
                table: "EntityFieldActionType",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionTypeRequiredField_EntityFieldActionTypeId",
                schema: "Entity",
                table: "EntityFieldActionTypeRequiredField",
                column: "EntityFieldActionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionTypeRequiredField_FieldShouldRelatedToEntityId",
                schema: "Entity",
                table: "EntityFieldActionTypeRequiredField",
                column: "FieldShouldRelatedToEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldActionTypeRequiredField_FieldTypeId",
                schema: "Entity",
                table: "EntityFieldActionTypeRequiredField",
                column: "FieldTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldCondition_ConditionTypeId",
                schema: "Entity",
                table: "EntityFieldCondition",
                column: "ConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldCondition_EntityFieldConditionGroupId",
                schema: "Entity",
                table: "EntityFieldCondition",
                column: "EntityFieldConditionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldCondition_FirstSideRelatedToEntityId",
                schema: "Entity",
                table: "EntityFieldCondition",
                column: "FirstSideRelatedToEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldCondition_SecondSideRelatedToEntityId",
                schema: "Entity",
                table: "EntityFieldCondition",
                column: "SecondSideRelatedToEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldConditionGroup_ConditionForId",
                schema: "Entity",
                table: "EntityFieldConditionGroup",
                column: "ConditionForId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldConditionGroup_EntityFieldId",
                schema: "Entity",
                table: "EntityFieldConditionGroup",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldGroup_EntityId",
                schema: "Entity",
                table: "EntityFieldGroup",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldOption_EntityFieldId",
                schema: "Entity",
                table: "EntityFieldOption",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldOptionCondition_ConditionTypeId",
                schema: "Entity",
                table: "EntityFieldOptionCondition",
                column: "ConditionTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldOptionCondition_EntityFieldOptionConditionGroupId",
                schema: "Entity",
                table: "EntityFieldOptionCondition",
                column: "EntityFieldOptionConditionGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldOptionCondition_FirstSideRelatedToEntityId",
                schema: "Entity",
                table: "EntityFieldOptionCondition",
                column: "FirstSideRelatedToEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldOptionCondition_SecondSideRelatedToEntityId",
                schema: "Entity",
                table: "EntityFieldOptionCondition",
                column: "SecondSideRelatedToEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldOptionConditionGroup_ConditionForId",
                schema: "Entity",
                table: "EntityFieldOptionConditionGroup",
                column: "ConditionForId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldOptionConditionGroup_EntityFieldOptionId",
                schema: "Entity",
                table: "EntityFieldOptionConditionGroup",
                column: "EntityFieldOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityFieldValue_EntityFieldId",
                schema: "Entity",
                table: "EntityFieldValue",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityMap_EntityId",
                schema: "Entity",
                table: "EntityMap",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityMap_MappedEntityId",
                schema: "Entity",
                table: "EntityMap",
                column: "MappedEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_EntityRelationBreak_Entity2Id",
                schema: "Entity",
                table: "EntityRelationBreak",
                column: "Entity2Id");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCall_AssignFromUserId",
                schema: "Application",
                table: "HistoricalCall",
                column: "AssignFromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCall_AssignToUserId",
                schema: "Application",
                table: "HistoricalCall",
                column: "AssignToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCall_CallStatusId",
                schema: "Application",
                table: "HistoricalCall",
                column: "CallStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCall_CallTypeId",
                schema: "Application",
                table: "HistoricalCall",
                column: "CallTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCall_CampaignId",
                schema: "Application",
                table: "HistoricalCall",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCall_CategoryId",
                schema: "Application",
                table: "HistoricalCall",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCall_ContactId",
                schema: "Application",
                table: "HistoricalCall",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCall_LatestHistoricalCallId",
                schema: "Application",
                table: "HistoricalCall",
                column: "LatestHistoricalCallId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCall_PriorityId",
                schema: "Application",
                table: "HistoricalCall",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCall_ScheduledByUserId",
                schema: "Application",
                table: "HistoricalCall",
                column: "ScheduledByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCall_ScheduledToUserId",
                schema: "Application",
                table: "HistoricalCall",
                column: "ScheduledToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCallGeneralReportSammary_CallStatusId",
                schema: "Log",
                table: "HistoricalCallGeneralReportSammary",
                column: "CallStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCallGeneralReportSammary_CallTypeId",
                schema: "Log",
                table: "HistoricalCallGeneralReportSammary",
                column: "CallTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCallGeneralReportSammary_CampaignId",
                schema: "Log",
                table: "HistoricalCallGeneralReportSammary",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCallGeneralReportSammary_CategoryId",
                schema: "Log",
                table: "HistoricalCallGeneralReportSammary",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCallGeneralReportSammary_ContactId",
                schema: "Log",
                table: "HistoricalCallGeneralReportSammary",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCallGeneralReportSammary_HistoricalCallId",
                schema: "Log",
                table: "HistoricalCallGeneralReportSammary",
                column: "HistoricalCallId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCallGeneralReportSammary_LeaderId",
                schema: "Log",
                table: "HistoricalCallGeneralReportSammary",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCallGeneralReportSammary_UserId",
                schema: "Log",
                table: "HistoricalCallGeneralReportSammary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCallPathResult_EntityFieldId",
                schema: "Application",
                table: "HistoricalCallPathResult",
                column: "EntityFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoricalCallPathResult_HistoricalCallId",
                schema: "Application",
                table: "HistoricalCallPathResult",
                column: "HistoricalCallId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonalInfo_CityId",
                schema: "Application",
                table: "PersonalInfo",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_history_AutoContactId",
                schema: "Log",
                table: "Pim_contact_attempts_history",
                column: "AutoContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_history_CampaignId",
                schema: "Log",
                table: "Pim_contact_attempts_history",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_history_CategoryId",
                schema: "Log",
                table: "Pim_contact_attempts_history",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_history_ContactId",
                schema: "Log",
                table: "Pim_contact_attempts_history",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_history_HistoricalCallId",
                schema: "Log",
                table: "Pim_contact_attempts_history",
                column: "HistoricalCallId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_history_UserId",
                schema: "Log",
                table: "Pim_contact_attempts_history",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_historyLog_CampaignId",
                schema: "Log",
                table: "Pim_contact_attempts_historyLog",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_historyLog_CategoryId",
                schema: "Log",
                table: "Pim_contact_attempts_historyLog",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_historyLog_ContactId",
                schema: "Log",
                table: "Pim_contact_attempts_historyLog",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_historyLog_HistoricalCallId",
                schema: "Log",
                table: "Pim_contact_attempts_historyLog",
                column: "HistoricalCallId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_historyLog_UserId",
                schema: "Log",
                table: "Pim_contact_attempts_historyLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "Identity",
                table: "Role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RoleClaims_RoleId",
                schema: "Identity",
                table: "RoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                schema: "Identity",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCall_AssignFromUserId",
                schema: "Application",
                table: "ScheduledCall",
                column: "AssignFromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCall_AssignToUserId",
                schema: "Application",
                table: "ScheduledCall",
                column: "AssignToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCall_CallStatusId",
                schema: "Application",
                table: "ScheduledCall",
                column: "CallStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCall_CallTypeId",
                schema: "Application",
                table: "ScheduledCall",
                column: "CallTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCall_CampaignId",
                schema: "Application",
                table: "ScheduledCall",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCall_CategoryId",
                schema: "Application",
                table: "ScheduledCall",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCall_ContactId",
                schema: "Application",
                table: "ScheduledCall",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCall_LatestHistoricalCallId",
                schema: "Application",
                table: "ScheduledCall",
                column: "LatestHistoricalCallId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCall_PriorityId",
                schema: "Application",
                table: "ScheduledCall",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCall_ScheduledByUserId",
                schema: "Application",
                table: "ScheduledCall",
                column: "ScheduledByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCall_ScheduledToUserId",
                schema: "Application",
                table: "ScheduledCall",
                column: "ScheduledToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SystemProgress_EntityId",
                schema: "Application",
                table: "SystemProgress",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Team_LeaderId",
                schema: "Lookup",
                table: "Team",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_User_CreatedByUserId",
                schema: "Identity",
                table: "User",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_LastModifiedByUserId",
                schema: "Identity",
                table: "User",
                column: "LastModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "Identity",
                table: "User",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserClaims_UserId",
                schema: "Identity",
                table: "UserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                schema: "Identity",
                table: "UserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_PermissionId",
                schema: "Identity",
                table: "UserPermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRealTime_CreatedByUserId",
                schema: "Identity",
                table: "UserRealTime",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRealTime_LastModifiedByUserId",
                schema: "Identity",
                table: "UserRealTime",
                column: "LastModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "Identity",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetting_CreatedByUserId",
                schema: "Identity",
                table: "UserSetting",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetting_LastModifiedByUserId",
                schema: "Identity",
                table: "UserSetting",
                column: "LastModifiedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSetting_SettingTypeId",
                schema: "Identity",
                table: "UserSetting",
                column: "SettingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeams_TeamId",
                schema: "Identity",
                table: "UserTeams",
                column: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSetting",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "ContactUploadingLog",
                schema: "Log");

            migrationBuilder.DropTable(
                name: "DynamicReportField",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityActionDynamicFunctionParameter",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityActionDynamicFunctionResult",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityActionField",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityActionGroupCondition",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityActionGroupTriggerType",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldActionDynamicFunctionParameter",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldActionDynamicFunctionResult",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldActionField",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldActionGroupCondition",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldActionGroupTriggerType",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldCondition",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldOptionCondition",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldValue",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityRelationBreak",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "HistoricalCallGeneralReportSammary",
                schema: "Log");

            migrationBuilder.DropTable(
                name: "HistoricalCallPathResult",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "nhc_agentless_can",
                schema: "Log");

            migrationBuilder.DropTable(
                name: "nhc_interest_camp",
                schema: "Log");

            migrationBuilder.DropTable(
                name: "Pim_contact_attempts_history",
                schema: "Log");

            migrationBuilder.DropTable(
                name: "Pim_contact_attempts_historyLog",
                schema: "Log");

            migrationBuilder.DropTable(
                name: "RoleClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "RolePermission",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "Setting",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "SystemProgress",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "UserClaims",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserLogins",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserPermission",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRealTime",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserSetting",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTeams",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "UserTokens",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "DynamicReport",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityMap",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityActionTypeRequiredField",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityAction",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityActionGroupConditionGroup",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "DynamicFunctionParameter",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "DynamicFunctionResult",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldActionDynamicFunction",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldActionTypeRequiredField",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldActionGroupConditionGroup",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "TriggerType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "EntityFieldConditionGroup",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "ConditionType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "EntityFieldOptionConditionGroup",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "AutoContact",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "Permission",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Role",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "SettingType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Team",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "EntityActionType",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityActionGroup",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldAction",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "ConditionFor",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "EntityFieldOption",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "ScheduledCall",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "DynamicFunction",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldActionGroup",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "EntityFieldActionType",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "HistoricalCall",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "EntityField",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "CallStatus",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Campaign",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Contact",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "User",
                schema: "Identity");

            migrationBuilder.DropTable(
                name: "EntityFieldGroup",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "FieldType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "AVAYAAURACampaignPredictive",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "CallType",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "CategoryPath",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "Priority",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "ContactCategory");

            migrationBuilder.DropTable(
                name: "PersonalInfo",
                schema: "Application");

            migrationBuilder.DropTable(
                name: "Entity",
                schema: "Entity");

            migrationBuilder.DropTable(
                name: "City",
                schema: "Lookup");

            migrationBuilder.DropTable(
                name: "EntityType",
                schema: "Entity");
        }
    }
}
