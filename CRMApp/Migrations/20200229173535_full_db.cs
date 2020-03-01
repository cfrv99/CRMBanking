using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMApp.Migrations
{
    public partial class full_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySalaries_Companies_CompanyId",
                table: "MonthlySalaries");

            migrationBuilder.DropIndex(
                name: "IX_MonthlySalaries_CompanyId",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "MyProperty",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "MonthlySalaries");

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlySalary",
                table: "StaffContracts",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "MonthlyAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false),
                    SalaryDate = table.Column<DateTime>(nullable: false),
                    CompanyId = table.Column<int>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonthlyAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MonthlyAmounts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MonthlyAmounts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_AppUserId",
                table: "Products",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyAmounts_AppUserId",
                table: "MonthlyAmounts",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_MonthlyAmounts_CompanyId",
                table: "MonthlyAmounts",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_AppUserId",
                table: "Products",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_AppUserId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "MonthlyAmounts");

            migrationBuilder.DropIndex(
                name: "IX_Products_AppUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MonthlySalary",
                table: "StaffContracts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "MyProperty",
                table: "Products",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "MonthlySalaries",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalaries_CompanyId",
                table: "MonthlySalaries",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySalaries_Companies_CompanyId",
                table: "MonthlySalaries",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
