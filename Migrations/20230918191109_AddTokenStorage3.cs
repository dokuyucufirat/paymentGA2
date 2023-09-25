using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentGetaway.Migrations
{
    /// <inheritdoc />
    public partial class AddTokenStorage3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardInfo_CardCVC",
                table: "TokenStorages");

            migrationBuilder.DropColumn(
                name: "CardInfo_CardExpiry",
                table: "TokenStorages");

            migrationBuilder.DropColumn(
                name: "CardInfo_CardNumber",
                table: "TokenStorages");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardInfo_CardCVC",
                table: "TokenStorages",
                type: "character varying(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardInfo_CardExpiry",
                table: "TokenStorages",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CardInfo_CardNumber",
                table: "TokenStorages",
                type: "character varying(16)",
                maxLength: 16,
                nullable: false,
                defaultValue: "");
        }
    }
}
