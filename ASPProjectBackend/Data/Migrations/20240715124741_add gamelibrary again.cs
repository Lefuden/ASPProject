using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPProjectBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class addgamelibraryagain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MacRequirements_Recommended",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MacRequirements_Recommended",
                table: "GameLibraries");
        }
    }
}
