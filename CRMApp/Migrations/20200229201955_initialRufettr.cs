using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMApp.Migrations
{
    public partial class initialRufettr : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClaimId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ClaimId",
                table: "AspNetUsers",
                column: "ClaimId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Claims_ClaimId",
                table: "AspNetUsers",
                column: "ClaimId",
                principalTable: "Claims",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Claims_ClaimId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ClaimId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ClaimId",
                table: "AspNetUsers");
        }
    }
}
