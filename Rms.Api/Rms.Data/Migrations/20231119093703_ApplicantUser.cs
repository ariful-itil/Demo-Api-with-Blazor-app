using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rms.Migrations
{
    /// <inheritdoc />
    public partial class ApplicantUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NID",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Org",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "OrgAddress",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "OrgName",
                table: "AspNetRoles");

            migrationBuilder.DropColumn(
                name: "PhoneNo",
                table: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "AspNetUsers",
                newName: "ApprovedUser");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "AspNetUsers",
                newName: "CreatedBy");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "BranchInfo",
                table: "AspNetUsers",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "TransLimit",
                table: "AspNetUsers",
                type: "decimal(12,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UserFullName",
                table: "AspNetUsers",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "VerifiedLimit",
                table: "AspNetUsers",
                type: "decimal(12,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "WinPassword",
                table: "AspNetUsers",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BranchInfo",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TransLimit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserFullName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VerifiedLimit",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "WinPassword",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "AspNetUsers",
                newName: "FullName");

            migrationBuilder.RenameColumn(
                name: "ApprovedUser",
                table: "AspNetUsers",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "RoleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NID",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Org",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgAddress",
                table: "AspNetRoles",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrgName",
                table: "AspNetRoles",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNo",
                table: "AspNetRoles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
