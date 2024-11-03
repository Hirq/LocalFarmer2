using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalFarmer2.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixAlert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Farmhouses_IdFarmhouse",
                table: "Alerts");

            migrationBuilder.AlterColumn<int>(
                name: "IdFarmhouse",
                table: "Alerts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Farmhouses_IdFarmhouse",
                table: "Alerts",
                column: "IdFarmhouse",
                principalTable: "Farmhouses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_Farmhouses_IdFarmhouse",
                table: "Alerts");

            migrationBuilder.AlterColumn<int>(
                name: "IdFarmhouse",
                table: "Alerts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_Farmhouses_IdFarmhouse",
                table: "Alerts",
                column: "IdFarmhouse",
                principalTable: "Farmhouses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
