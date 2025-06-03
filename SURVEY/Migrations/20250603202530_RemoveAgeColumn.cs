using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SURVEY.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAgeColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Surveys");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Surveys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
