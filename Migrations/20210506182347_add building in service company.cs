using Microsoft.EntityFrameworkCore.Migrations;

namespace GKU_App.Migrations
{
    public partial class addbuildinginservicecompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
