using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PaymentGetaway.Migrations
{
    /// <inheritdoc />
    public partial class DBset3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentCompletions_PaymentRequests_PaymentRequestId",
                table: "PaymentCompletions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentCompletions",
                table: "PaymentCompletions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentCancellations",
                table: "PaymentCancellations");

            migrationBuilder.RenameTable(
                name: "PaymentCompletions",
                newName: "PaymentCompletionRequest");

            migrationBuilder.RenameTable(
                name: "PaymentCancellations",
                newName: "PaymentCancellationRequest");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentCompletions_PaymentRequestId",
                table: "PaymentCompletionRequest",
                newName: "IX_PaymentCompletionRequest_PaymentRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentCompletionRequest",
                table: "PaymentCompletionRequest",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentCancellationRequest",
                table: "PaymentCancellationRequest",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PaymentStatusRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PaymentId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentStatusRequests", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentCompletionRequest_PaymentRequests_PaymentRequestId",
                table: "PaymentCompletionRequest",
                column: "PaymentRequestId",
                principalTable: "PaymentRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentCompletionRequest_PaymentRequests_PaymentRequestId",
                table: "PaymentCompletionRequest");

            migrationBuilder.DropTable(
                name: "PaymentStatusRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentCompletionRequest",
                table: "PaymentCompletionRequest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentCancellationRequest",
                table: "PaymentCancellationRequest");

            migrationBuilder.RenameTable(
                name: "PaymentCompletionRequest",
                newName: "PaymentCompletions");

            migrationBuilder.RenameTable(
                name: "PaymentCancellationRequest",
                newName: "PaymentCancellations");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentCompletionRequest_PaymentRequestId",
                table: "PaymentCompletions",
                newName: "IX_PaymentCompletions_PaymentRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentCompletions",
                table: "PaymentCompletions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentCancellations",
                table: "PaymentCancellations",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentCompletions_PaymentRequests_PaymentRequestId",
                table: "PaymentCompletions",
                column: "PaymentRequestId",
                principalTable: "PaymentRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
