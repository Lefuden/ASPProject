using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPProjectBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class addgamelibraryagain4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RequiredAge",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "RequiredAge",
                table: "GameLibraries",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
