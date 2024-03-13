using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalFarmer2.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Alert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alerts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdFarmhouse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Alerts_AspNetUsers_IdUser",
                        column: x => x.IdUser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alerts_Farmhouses_IdFarmhouse",
                        column: x => x.IdFarmhouse,
                        principalTable: "Farmhouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_IdFarmhouse",
                table: "Alerts",
                column: "IdFarmhouse");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_IdUser",
                table: "Alerts",
                column: "IdUser");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerts");
        }
    }
}
