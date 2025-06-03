using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SURVEY.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_surveyModels",
                table: "surveyModels");

            migrationBuilder.RenameTable(
                name: "surveyModels",
                newName: "Surveys");

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Surveys",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Movies",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Out",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Raido",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TV",
                table: "Surveys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Surveys",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Movies",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Out",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "Raido",
                table: "Surveys");

            migrationBuilder.DropColumn(
                name: "TV",
                table: "Surveys");

            migrationBuilder.RenameTable(
                name: "Surveys",
                newName: "surveyModels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_surveyModels",
                table: "surveyModels",
                column: "Id");
        }
    }
}
