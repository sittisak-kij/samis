using Microsoft.EntityFrameworkCore.Migrations;

namespace samis.Migrations
{
    public partial class movedb1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "advisorId",
                table: "ActivityUnits",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityUnits_advisorId",
                table: "ActivityUnits",
                column: "advisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityUnits_Advisors_advisorId",
                table: "ActivityUnits",
                column: "advisorId",
                principalTable: "Advisors",
                principalColumn: "advisorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityUnits_Advisors_advisorId",
                table: "ActivityUnits");

            migrationBuilder.DropIndex(
                name: "IX_ActivityUnits_advisorId",
                table: "ActivityUnits");

            migrationBuilder.DropColumn(
                name: "advisorId",
                table: "ActivityUnits");
        }
    }
}
