using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalFarmer2.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class PaymentMethodsJson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PaymentMethodsJson",
                table: "Farmhouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethodsJson",
                table: "Farmhouses");
        }
    }
}
