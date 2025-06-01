using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NauticaFreight.API.Migrations
{
    /// <inheritdoc />
    public partial class CorrectstatusforTripstable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.DropIndex(
                name: "IX_Trips_StatusId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Trips");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Trips",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Trips");

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TripStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripStatus", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_StatusId",
                table: "Trips",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_TripStatus_StatusId",
                table: "Trips",
                column: "StatusId",
                principalTable: "TripStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
