using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestKendoTreeView.Migrations
{
    public partial class m5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimId",
                table: "RoleClaim");

            migrationBuilder.AddColumn<string>(
                name: "ClaimType",
                table: "RoleClaim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClaimValue",
                table: "RoleClaim",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClaimType",
                table: "RoleClaim");

            migrationBuilder.DropColumn(
                name: "ClaimValue",
                table: "RoleClaim");

            migrationBuilder.AddColumn<Guid>(
                name: "ClaimId",
                table: "RoleClaim",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
