using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMApp.Migrations
{
    public partial class Yarimchiqq : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySalaries_Companies_CompanyId",
                table: "MonthlySalaries");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "MonthlySalaries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "MonthlySalaries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Companies",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StaffContractId",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Claims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Claims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Claims_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyContracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Agreements = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    MonthCount = table.Column<decimal>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyContracts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    MyProperty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StaffContracts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Agreement = table.Column<string>(nullable: true),
                    Expire = table.Column<DateTime>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffContracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffContracts_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StaffRequests",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    About = table.Column<string>(nullable: true),
                    AppUserId = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    MinSalary = table.Column<decimal>(nullable: false),
                    Ability = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaffRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StaffRequests_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StaffRequests_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnnouncementWorks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MinSalary = table.Column<decimal>(nullable: false),
                    ClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnouncementWorks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnouncementWorks_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    DeadLine = table.Column<DateTime>(nullable: false),
                    ClaimId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobTasks_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobTasks_Claims_ClaimId",
                        column: x => x.ClaimId,
                        principalTable: "Claims",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bids",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AnnouncmentWorkId = table.Column<int>(nullable: false),
                    IsAccepted = table.Column<bool>(nullable: false),
                    AppUserId = table.Column<string>(nullable: true),
                    AnnouncementWorkId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bids_AnnouncementWorks_AnnouncementWorkId",
                        column: x => x.AnnouncementWorkId,
                        principalTable: "AnnouncementWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bids_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MonthlySalaries_AppUserId",
                table: "MonthlySalaries",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnouncementWorks_ClaimId",
                table: "AnnouncementWorks",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AnnouncementWorkId",
                table: "Bids",
                column: "AnnouncementWorkId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AppUserId",
                table: "Bids",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Claims_CompanyId",
                table: "Claims",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyContracts_CompanyId",
                table: "CompanyContracts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_AppUserId",
                table: "JobTasks",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_ClaimId",
                table: "JobTasks",
                column: "ClaimId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffContracts_AppUserId",
                table: "StaffContracts",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRequests_AppUserId",
                table: "StaffRequests",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_StaffRequests_CompanyId",
                table: "StaffRequests",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySalaries_AspNetUsers_AppUserId",
                table: "MonthlySalaries",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySalaries_Companies_CompanyId",
                table: "MonthlySalaries",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySalaries_AspNetUsers_AppUserId",
                table: "MonthlySalaries");

            migrationBuilder.DropForeignKey(
                name: "FK_MonthlySalaries_Companies_CompanyId",
                table: "MonthlySalaries");

            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Bids");

            migrationBuilder.DropTable(
                name: "CompanyContracts");

            migrationBuilder.DropTable(
                name: "JobTasks");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "StaffContracts");

            migrationBuilder.DropTable(
                name: "StaffRequests");

            migrationBuilder.DropTable(
                name: "AnnouncementWorks");

            migrationBuilder.DropTable(
                name: "Claims");

            migrationBuilder.DropIndex(
                name: "IX_MonthlySalaries_AppUserId",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "MonthlySalaries");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "StaffContractId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "MonthlySalaries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MonthlySalaries_Companies_CompanyId",
                table: "MonthlySalaries",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
