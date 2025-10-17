using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalFarmer2.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class alertwith2userid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_AspNetUsers_IdUser",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Alerts",
                newName: "IdUserTarget");

            migrationBuilder.RenameIndex(
                name: "IX_Alerts_IdUser",
                table: "Alerts",
                newName: "IX_Alerts_IdUserTarget");

            migrationBuilder.AddColumn<string>(
                name: "IdUserSource",
                table: "Alerts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Alerts_IdUserSource",
                table: "Alerts",
                column: "IdUserSource");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_AspNetUsers_IdUserSource",
                table: "Alerts",
                column: "IdUserSource",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_AspNetUsers_IdUserTarget",
                table: "Alerts",
                column: "IdUserTarget",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_AspNetUsers_IdUserSource",
                table: "Alerts");

            migrationBuilder.DropForeignKey(
                name: "FK_Alerts_AspNetUsers_IdUserTarget",
                table: "Alerts");

            migrationBuilder.DropIndex(
                name: "IX_Alerts_IdUserSource",
                table: "Alerts");

            migrationBuilder.DropColumn(
                name: "IdUserSource",
                table: "Alerts");

            migrationBuilder.RenameColumn(
                name: "IdUserTarget",
                table: "Alerts",
                newName: "IdUser");

            migrationBuilder.RenameIndex(
                name: "IX_Alerts_IdUserTarget",
                table: "Alerts",
                newName: "IX_Alerts_IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerts_AspNetUsers_IdUser",
                table: "Alerts",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
