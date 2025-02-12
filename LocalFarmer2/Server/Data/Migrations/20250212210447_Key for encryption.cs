using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalFarmer2.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Keyforencryption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ChatUserKeys",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    User1Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User2Id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AESKey = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatUserKeys", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatUserKeys");
        }
    }
}
