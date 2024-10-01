using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalFarmer2.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class NoteForUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUser",
                table: "Notes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_IdUser",
                table: "Notes",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_AspNetUsers_IdUser",
                table: "Notes",
                column: "IdUser",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_AspNetUsers_IdUser",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_IdUser",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IdUser",
                table: "Notes");
        }
    }
}
