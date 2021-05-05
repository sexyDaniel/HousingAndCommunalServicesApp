using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GKU_App.Migrations
{
    public partial class ChargeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Charges",
                table: "Charges");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Charges",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Charges",
                table: "Charges",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Charges_PropertyId",
                table: "Charges",
                column: "PropertyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Charges",
                table: "Charges");

            migrationBuilder.DropIndex(
                name: "IX_Charges_PropertyId",
                table: "Charges");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Charges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Charges",
                table: "Charges",
                columns: new[] { "PropertyId", "ServiceId" });
        }
    }
}
