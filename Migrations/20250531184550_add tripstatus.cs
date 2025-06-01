using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NauticaFreight.API.Migrations
{
    /// <inheritdoc />
    public partial class addtripstatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Trips",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trips_StatusId",
                table: "Trips",
                column: "StatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trips_Statuses_StatusId",
                table: "Trips",
                column: "StatusId",
                principalTable: "Statuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trips_Statuses_StatusId",
                table: "Trips");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Trips_StatusId",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Trips");
        }
    }
}
