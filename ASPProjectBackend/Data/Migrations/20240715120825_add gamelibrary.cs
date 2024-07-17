using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPProjectBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class addgamelibrary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameLibraries",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "GameLibraryId",
                table: "GameLibraries");

            migrationBuilder.RenameColumn(
                name: "appId",
                table: "GameLibraries",
                newName: "LinuxRequirements_Capacity");

            migrationBuilder.AddColumn<long>(
                name: "SteamAppid",
                table: "GameLibraries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "AboutTheGame",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CapsuleImage",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CapsuleImagev5",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ControllerSupport",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DetailedDescription",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HeaderImage",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "GameLibraries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MacRequirements_Minimum",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "Metacritic_Score",
                table: "GameLibraries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "Metacritic_Url",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PcRequirements_Minimum",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PcRequirements_Recommended",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PriceOverview_Currency",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PriceOverview_DiscountPercent",
                table: "GameLibraries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PriceOverview_Final",
                table: "GameLibraries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "PriceOverview_FinalFormatted",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "PriceOverview_Initial",
                table: "GameLibraries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "PriceOverview_InitialFormatted",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ReleaseDate_ComingSoon",
                table: "GameLibraries",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ReleaseDate_Date",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "RequiredAge",
                table: "GameLibraries",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<string>(
                name: "ShortDescription",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "SupportedLanguages",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "GameLibraries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameLibraries",
                table: "GameLibraries",
                column: "SteamAppid");

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GameLibrarySteamAppid = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => new { x.GameLibrarySteamAppid, x.Id });
                    table.ForeignKey(
                        name: "FK_Genre_GameLibraries_GameLibrarySteamAppid",
                        column: x => x.GameLibrarySteamAppid,
                        principalTable: "GameLibraries",
                        principalColumn: "SteamAppid",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GameLibraries",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "SteamAppid",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "AboutTheGame",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "CapsuleImage",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "CapsuleImagev5",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "ControllerSupport",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "DetailedDescription",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "HeaderImage",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "MacRequirements_Minimum",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "Metacritic_Score",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "Metacritic_Url",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "PcRequirements_Minimum",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "PcRequirements_Recommended",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "PriceOverview_Currency",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "PriceOverview_DiscountPercent",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "PriceOverview_Final",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "PriceOverview_FinalFormatted",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "PriceOverview_Initial",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "PriceOverview_InitialFormatted",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "ReleaseDate_ComingSoon",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "ReleaseDate_Date",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "RequiredAge",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "ShortDescription",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "SupportedLanguages",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "GameLibraries");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "GameLibraries");

            migrationBuilder.RenameColumn(
                name: "LinuxRequirements_Capacity",
                table: "GameLibraries",
                newName: "appId");

            migrationBuilder.AddColumn<int>(
                name: "GameLibraryId",
                table: "GameLibraries",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameLibraries",
                table: "GameLibraries",
                column: "GameLibraryId");
        }
    }
}
