using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NauticaFreight.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePortTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "Ports",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "Ports",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Ports");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Ports");
        }
    }
}
