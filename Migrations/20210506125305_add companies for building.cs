using Microsoft.EntityFrameworkCore.Migrations;

namespace GKU_App.Migrations
{
    public partial class addcompaniesforbuilding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "ServiceCompanies",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Salt = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Login);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCompanies_BuildingId",
                table: "ServiceCompanies",
                column: "BuildingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceCompanies_Buildings_BuildingId",
                table: "ServiceCompanies",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "BuildingId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCompanies_Buildings_BuildingId",
                table: "ServiceCompanies");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCompanies_BuildingId",
                table: "ServiceCompanies");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "ServiceCompanies");
        }
    }
}
