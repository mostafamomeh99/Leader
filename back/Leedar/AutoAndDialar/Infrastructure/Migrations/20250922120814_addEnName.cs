using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addEnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FullNameEn",
                schema: "Application",
                table: "PersonalInfo",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.UpdateData(
                schema: "Application",
                table: "PersonalInfo",
                keyColumn: "Id",
                keyValue: new Guid("3abfa071-e941-48e6-a492-b6cad5debf61"),
                column: "FullNameEn",
                value: null);

            migrationBuilder.UpdateData(
                schema: "Application",
                table: "PersonalInfo",
                keyColumn: "Id",
                keyValue: new Guid("d741da85-bd74-42cc-8d22-8176f49580e6"),
                column: "FullNameEn",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullNameEn",
                schema: "Application",
                table: "PersonalInfo");
        }
    }
}
