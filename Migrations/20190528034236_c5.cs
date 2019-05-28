using Microsoft.EntityFrameworkCore.Migrations;

namespace samis.Migrations
{
    public partial class c5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInformations_LocationTypes_locationTypeId",
                table: "ActivityInformations");

            migrationBuilder.DropIndex(
                name: "IX_ActivityInformations_locationTypeId",
                table: "ActivityInformations");

            migrationBuilder.DropColumn(
                name: "locationTypeId",
                table: "ActivityInformations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "locationTypeId",
                table: "ActivityInformations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInformations_locationTypeId",
                table: "ActivityInformations",
                column: "locationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityInformations_LocationTypes_locationTypeId",
                table: "ActivityInformations",
                column: "locationTypeId",
                principalTable: "LocationTypes",
                principalColumn: "locationTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
