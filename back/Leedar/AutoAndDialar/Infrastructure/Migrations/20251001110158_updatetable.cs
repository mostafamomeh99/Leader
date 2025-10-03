using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_CreatedByUserId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_LastModifiedByUserId",
                schema: "Identity",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "DirectLeaderId",
                schema: "Identity",
                table: "User",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Identity",
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"),
                column: "DirectLeaderId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_User_LastModifiedByUserId",
                schema: "Identity",
                table: "User",
                column: "LastModifiedByUserId",
                unique: true,
                filter: "[LastModifiedByUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_CreatedByUserId",
                schema: "Identity",
                table: "User",
                column: "CreatedByUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_CreatedByUserId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_LastModifiedByUserId",
                schema: "Identity",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DirectLeaderId",
                schema: "Identity",
                table: "User");

            migrationBuilder.CreateIndex(
                name: "IX_User_LastModifiedByUserId",
                schema: "Identity",
                table: "User",
                column: "LastModifiedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_CreatedByUserId",
                schema: "Identity",
                table: "User",
                column: "CreatedByUserId",
                principalSchema: "Identity",
                principalTable: "User",
                principalColumn: "Id");
        }
    }
}
