using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalFarmer2.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Chat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUserSender = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IdUserReceiver = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EncryptedMessage = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    MessageIV = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    DateSent = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessages_AspNetUsers_IdUserReceiver",
                        column: x => x.IdUserReceiver,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChatMessages_AspNetUsers_IdUserSender",
                        column: x => x.IdUserSender,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_IdUserReceiver",
                table: "ChatMessages",
                column: "IdUserReceiver");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessages_IdUserSender",
                table: "ChatMessages",
                column: "IdUserSender");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessages");
        }
    }
}
