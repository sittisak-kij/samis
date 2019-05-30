using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace samis.Migrations
{
    public partial class c13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugets_Project_Projectid",
                table: "Bugets");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Bugets_Projectid",
                table: "Bugets");

            migrationBuilder.DropColumn(
                name: "Projectid",
                table: "Bugets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Projectid",
                table: "Bugets",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    activityInformationactivityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.id);
                    table.ForeignKey(
                        name: "FK_Project_ActivityInformations_activityInformationactivityId",
                        column: x => x.activityInformationactivityId,
                        principalTable: "ActivityInformations",
                        principalColumn: "activityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bugets_Projectid",
                table: "Bugets",
                column: "Projectid");

            migrationBuilder.CreateIndex(
                name: "IX_Project_activityInformationactivityId",
                table: "Project",
                column: "activityInformationactivityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugets_Project_Projectid",
                table: "Bugets",
                column: "Projectid",
                principalTable: "Project",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
