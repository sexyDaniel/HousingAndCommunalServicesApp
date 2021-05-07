using Microsoft.EntityFrameworkCore.Migrations;

namespace GKU_App.Migrations
{
    public partial class addbuildinginServiceCompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceCompanies_Buildings_BuildingId",
                table: "ServiceCompanies");

            migrationBuilder.DropIndex(
                name: "IX_ServiceCompanies_BuildingId",
                table: "ServiceCompanies");

            migrationBuilder.DropColumn(
                name: "BuildingId",
                table: "ServiceCompanies");

            migrationBuilder.CreateTable(
                name: "BuildingServiceCompany",
                columns: table => new
                {
                    BuildingsBuildingId = table.Column<int>(type: "integer", nullable: false),
                    ServiceCompaniesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuildingServiceCompany", x => new { x.BuildingsBuildingId, x.ServiceCompaniesId });
                    table.ForeignKey(
                        name: "FK_BuildingServiceCompany_Buildings_BuildingsBuildingId",
                        column: x => x.BuildingsBuildingId,
                        principalTable: "Buildings",
                        principalColumn: "BuildingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuildingServiceCompany_ServiceCompanies_ServiceCompaniesId",
                        column: x => x.ServiceCompaniesId,
                        principalTable: "ServiceCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuildingServiceCompany_ServiceCompaniesId",
                table: "BuildingServiceCompany",
                column: "ServiceCompaniesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuildingServiceCompany");

            migrationBuilder.AddColumn<int>(
                name: "BuildingId",
                table: "ServiceCompanies",
                type: "integer",
                nullable: true);

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
    }
}
