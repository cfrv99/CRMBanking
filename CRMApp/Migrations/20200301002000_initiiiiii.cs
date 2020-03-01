using Microsoft.EntityFrameworkCore.Migrations;

namespace CRMApp.Migrations
{
    public partial class initiiiiii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AnnouncementWorks_AnnouncementWorkId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_AnnouncementWorkId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "AnnouncementWorkId",
                table: "Bids");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "JobTasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_CompanyId",
                table: "JobTasks",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AnnouncmentWorkId",
                table: "Bids",
                column: "AnnouncmentWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AnnouncementWorks_AnnouncmentWorkId",
                table: "Bids",
                column: "AnnouncmentWorkId",
                principalTable: "AnnouncementWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Companies_CompanyId",
                table: "JobTasks",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AnnouncementWorks_AnnouncmentWorkId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Companies_CompanyId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_CompanyId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_Bids_AnnouncmentWorkId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "JobTasks");

            migrationBuilder.AddColumn<int>(
                name: "AnnouncementWorkId",
                table: "Bids",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_AnnouncementWorkId",
                table: "Bids",
                column: "AnnouncementWorkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AnnouncementWorks_AnnouncementWorkId",
                table: "Bids",
                column: "AnnouncementWorkId",
                principalTable: "AnnouncementWorks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
