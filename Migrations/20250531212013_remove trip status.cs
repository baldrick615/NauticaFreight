using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NauticaFreight.API.Migrations
{
    /// <inheritdoc />
    public partial class removetripstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Statuses_StatusId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses");

            migrationBuilder.RenameTable(
                name: "Statuses",
                newName: "TripStatus");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TripStatus",
                table: "TripStatus",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_TripStatus_StatusId",
                table: "Trips",
                column: "StatusId",
                principalTable: "TripStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_TripStatus_StatusId",
                table: "Trips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TripStatus",
                table: "TripStatus");

            migrationBuilder.RenameTable(
                name: "TripStatus",
                newName: "Statuses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statuses",
                table: "Statuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Statuses_StatusId",
                table: "Trips",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
