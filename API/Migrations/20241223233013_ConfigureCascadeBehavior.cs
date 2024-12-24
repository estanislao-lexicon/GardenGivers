using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureCascadeBehavior : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Requests_RequestId",
                table: "Transactions");

            migrationBuilder.AddColumn<int>(
                name: "OfferId1",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequestId1",
                table: "Transactions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_OfferId1",
                table: "Transactions",
                column: "OfferId1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_RequestId1",
                table: "Transactions",
                column: "RequestId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Offers_OfferId1",
                table: "Transactions",
                column: "OfferId1",
                principalTable: "Offers",
                principalColumn: "OfferId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Requests_RequestId",
                table: "Transactions",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Requests_RequestId1",
                table: "Transactions",
                column: "RequestId1",
                principalTable: "Requests",
                principalColumn: "RequestId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Offers_OfferId1",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Requests_RequestId",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Requests_RequestId1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_OfferId1",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_RequestId1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "OfferId1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "RequestId1",
                table: "Transactions");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Requests_RequestId",
                table: "Transactions",
                column: "RequestId",
                principalTable: "Requests",
                principalColumn: "RequestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
