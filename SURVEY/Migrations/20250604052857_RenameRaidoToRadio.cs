using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SURVEY.Migrations
{
    /// <inheritdoc />
    public partial class RenameRaidoToRadio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Raido",
                table: "Surveys",
                newName: "Radio");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Radio",
                table: "Surveys",
                newName: "Raido");
        }
    }
}
