using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPProjectBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class addgamelibraryagain3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MacRequirements_Minimum",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "MacRequirements_Recommended",
                table: "GameLibraries");

            migrationBuilder.AddColumn<int>(
                name: "MacRequirements_Capacity",
                table: "GameLibraries",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MacRequirements_Capacity",
                table: "GameLibraries");

            migrationBuilder.AddColumn<string>(
                name: "MacRequirements_Minimum",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MacRequirements_Recommended",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
