using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ASPProjectBackend.Data.Migrations
{
    /// <inheritdoc />
    public partial class addedpricetogamelib : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "DiscountPercent",
                table: "Games",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InitialPrice",
                table: "Games",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "InitialPrice",
                table: "Games");
        }
    }
}
