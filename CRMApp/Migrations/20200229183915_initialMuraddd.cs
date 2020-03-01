using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMApp.Migrations
{
    public partial class initialMuraddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyContracts_Companies_CompanyId",
                table: "CompanyContracts");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "CompanyContracts",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyContracts_Companies_CompanyId",
                table: "CompanyContracts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyContracts_Companies_CompanyId",
                table: "CompanyContracts");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "CompanyContracts",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyContracts_Companies_CompanyId",
                table: "CompanyContracts",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
