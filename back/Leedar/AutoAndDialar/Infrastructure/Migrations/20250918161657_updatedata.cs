using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CallTypeId",
                schema: "Application",
                table: "SystemProgress",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CampaignId",
                schema: "Application",
                table: "SystemProgress",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                schema: "Application",
                table: "SystemProgress",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PriorityId",
                schema: "Application",
                table: "SystemProgress",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "Application",
                table: "SystemProgress",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CallTypeId",
                schema: "Log",
                table: "Pim_contact_attempts_history",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "CallStatusId",
                schema: "Application",
                table: "HistoricalCall",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "SystemProgressId",
                schema: "Log",
                table: "ContactUploadingLog",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ScheduledCallLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    ContactId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CallStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CallTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AssignFromUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignToUserAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledToUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ScheduledToUserAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ScheduledCallDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Body = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    BodyHTML = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ScheduledToIPAddress = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CampaignId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PriorityId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LatestHistoricalCallId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ContactName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ContactIdentity = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ContactMobile = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CallStatusName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmployeeName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CampaignName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CategoryName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    PriorityName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    UploadDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "getDate()"),
                    CreatedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedByUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StateCode = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduledCallLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduledCallLog_CallStatus_CallStatusId",
                        column: x => x.CallStatusId,
                        principalSchema: "Lookup",
                        principalTable: "CallStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledCallLog_CallType_CallTypeId",
                        column: x => x.CallTypeId,
                        principalSchema: "Lookup",
                        principalTable: "CallType",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCallLog_Campaign_CampaignId",
                        column: x => x.CampaignId,
                        principalSchema: "Lookup",
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledCallLog_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Lookup",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledCallLog_Contact_ContactId",
                        column: x => x.ContactId,
                        principalSchema: "Application",
                        principalTable: "Contact",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledCallLog_HistoricalCall_LatestHistoricalCallId",
                        column: x => x.LatestHistoricalCallId,
                        principalSchema: "Application",
                        principalTable: "HistoricalCall",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCallLog_Priority_PriorityId",
                        column: x => x.PriorityId,
                        principalSchema: "Lookup",
                        principalTable: "Priority",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCallLog_User_AssignFromUserId",
                        column: x => x.AssignFromUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ScheduledCallLog_User_AssignToUserId",
                        column: x => x.AssignToUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCallLog_User_ScheduledByUserId",
                        column: x => x.ScheduledByUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ScheduledCallLog_User_ScheduledToUserId",
                        column: x => x.ScheduledToUserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "newsequentialid()"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "Lookup",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCategory_User_UserId",
                        column: x => x.UserId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CallType",
                keyColumn: "Id",
                keyValue: new Guid("3ac144c5-5ea4-4ca3-a8a3-0b2f173dd6db"),
                columns: new[] { "NameAr", "NameEn" },
                values: new object[] { "مكالمة متصل تنبؤي", "Normal Call" });

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CallType",
                keyColumn: "Id",
                keyValue: new Guid("b22c1515-23d2-452b-82f5-5f2999582f8d"),
                columns: new[] { "NameAr", "NameEn" },
                values: new object[] { "مكالمة تلقائي", "Auto Call" });

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_history_CallTypeId",
                schema: "Log",
                table: "Pim_contact_attempts_history",
                column: "CallTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pim_contact_attempts_history_ScheduledCallId",
                schema: "Log",
                table: "Pim_contact_attempts_history",
                column: "ScheduledCallId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUploadingLog_SystemProgressId",
                schema: "Log",
                table: "ContactUploadingLog",
                column: "SystemProgressId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCallLog_AssignFromUserId",
                table: "ScheduledCallLog",
                column: "AssignFromUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCallLog_AssignToUserId",
                table: "ScheduledCallLog",
                column: "AssignToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCallLog_CallStatusId",
                table: "ScheduledCallLog",
                column: "CallStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCallLog_CallTypeId",
                table: "ScheduledCallLog",
                column: "CallTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCallLog_CampaignId",
                table: "ScheduledCallLog",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCallLog_CategoryId",
                table: "ScheduledCallLog",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCallLog_ContactId",
                table: "ScheduledCallLog",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCallLog_LatestHistoricalCallId",
                table: "ScheduledCallLog",
                column: "LatestHistoricalCallId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCallLog_PriorityId",
                table: "ScheduledCallLog",
                column: "PriorityId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCallLog_ScheduledByUserId",
                table: "ScheduledCallLog",
                column: "ScheduledByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduledCallLog_ScheduledToUserId",
                table: "ScheduledCallLog",
                column: "ScheduledToUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_CategoryId",
                table: "UserCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCategory_UserId",
                table: "UserCategory",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUploadingLog_SystemProgress_SystemProgressId",
                schema: "Log",
                table: "ContactUploadingLog",
                column: "SystemProgressId",
                principalSchema: "Application",
                principalTable: "SystemProgress",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pim_contact_attempts_history_CallType_CallTypeId",
                schema: "Log",
                table: "Pim_contact_attempts_history",
                column: "CallTypeId",
                principalSchema: "Lookup",
                principalTable: "CallType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pim_contact_attempts_history_ScheduledCall_ScheduledCallId",
                schema: "Log",
                table: "Pim_contact_attempts_history",
                column: "ScheduledCallId",
                principalSchema: "Application",
                principalTable: "ScheduledCall",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactUploadingLog_SystemProgress_SystemProgressId",
                schema: "Log",
                table: "ContactUploadingLog");

            migrationBuilder.DropForeignKey(
                name: "FK_Pim_contact_attempts_history_CallType_CallTypeId",
                schema: "Log",
                table: "Pim_contact_attempts_history");

            migrationBuilder.DropForeignKey(
                name: "FK_Pim_contact_attempts_history_ScheduledCall_ScheduledCallId",
                schema: "Log",
                table: "Pim_contact_attempts_history");

            migrationBuilder.DropTable(
                name: "ScheduledCallLog");

            migrationBuilder.DropTable(
                name: "UserCategory");

            migrationBuilder.DropIndex(
                name: "IX_Pim_contact_attempts_history_CallTypeId",
                schema: "Log",
                table: "Pim_contact_attempts_history");

            migrationBuilder.DropIndex(
                name: "IX_Pim_contact_attempts_history_ScheduledCallId",
                schema: "Log",
                table: "Pim_contact_attempts_history");

            migrationBuilder.DropIndex(
                name: "IX_ContactUploadingLog_SystemProgressId",
                schema: "Log",
                table: "ContactUploadingLog");

            migrationBuilder.DropColumn(
                name: "CallTypeId",
                schema: "Application",
                table: "SystemProgress");

            migrationBuilder.DropColumn(
                name: "CampaignId",
                schema: "Application",
                table: "SystemProgress");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                schema: "Application",
                table: "SystemProgress");

            migrationBuilder.DropColumn(
                name: "PriorityId",
                schema: "Application",
                table: "SystemProgress");

            migrationBuilder.DropColumn(
                name: "Type",
                schema: "Application",
                table: "SystemProgress");

            migrationBuilder.DropColumn(
                name: "CallTypeId",
                schema: "Log",
                table: "Pim_contact_attempts_history");

            migrationBuilder.DropColumn(
                name: "SystemProgressId",
                schema: "Log",
                table: "ContactUploadingLog");

            migrationBuilder.AlterColumn<Guid>(
                name: "CallStatusId",
                schema: "Application",
                table: "HistoricalCall",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CallType",
                keyColumn: "Id",
                keyValue: new Guid("3ac144c5-5ea4-4ca3-a8a3-0b2f173dd6db"),
                columns: new[] { "NameAr", "NameEn" },
                values: new object[] { "مكالمة تحصيل", "Collecting Call" });

            migrationBuilder.UpdateData(
                schema: "Lookup",
                table: "CallType",
                keyColumn: "Id",
                keyValue: new Guid("b22c1515-23d2-452b-82f5-5f2999582f8d"),
                columns: new[] { "NameAr", "NameEn" },
                values: new object[] { "مكالمة تبليغ", "Notification Call" });
        }
    }
}
