using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LocalFarmer2.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class paymentMethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethods",
                table: "Farmhouses");

            migrationBuilder.AddColumn<bool>(
                name: "IsPaymentBankTransfer",
                table: "Farmhouses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaymentCard",
                table: "Farmhouses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaymentCash",
                table: "Farmhouses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaymentOther",
                table: "Farmhouses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaymentTransferOnPhone",
                table: "Farmhouses",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPaymentBankTransfer",
                table: "Farmhouses");

            migrationBuilder.DropColumn(
                name: "IsPaymentCard",
                table: "Farmhouses");

            migrationBuilder.DropColumn(
                name: "IsPaymentCash",
                table: "Farmhouses");

            migrationBuilder.DropColumn(
                name: "IsPaymentOther",
                table: "Farmhouses");

            migrationBuilder.DropColumn(
                name: "IsPaymentTransferOnPhone",
                table: "Farmhouses");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethods",
                table: "Farmhouses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
