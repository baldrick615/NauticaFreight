using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NauticaFreight.API.Migrations
{
    /// <inheritdoc />
    public partial class AddVessel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vessels",
                columns: table => new
                {
                    VesselId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    VesselName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryOfOrigin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargoCategory = table.Column<int>(type: "int", nullable: false),
                    CarryingCapacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vessels", x => x.VesselId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vessels");
        }
    }
}
