using Microsoft.EntityFrameworkCore.Migrations;

namespace samis.Migrations
{
    public partial class c7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInformations_ActivityTypes_activityTypeId",
                table: "ActivityInformations");

            migrationBuilder.RenameColumn(
                name: "typeId",
                table: "ActivityInformations",
                newName: "projectLevelId");

            migrationBuilder.AlterColumn<int>(
                name: "activityTypeId",
                table: "ActivityInformations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInformations_projectLevelId",
                table: "ActivityInformations",
                column: "projectLevelId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityInformations_ActivityTypes_activityTypeId",
                table: "ActivityInformations",
                column: "activityTypeId",
                principalTable: "ActivityTypes",
                principalColumn: "activityTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityInformations_ProjectLevels_projectLevelId",
                table: "ActivityInformations",
                column: "projectLevelId",
                principalTable: "ProjectLevels",
                principalColumn: "projectLevelId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInformations_ActivityTypes_activityTypeId",
                table: "ActivityInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_ActivityInformations_ProjectLevels_projectLevelId",
                table: "ActivityInformations");

            migrationBuilder.DropIndex(
                name: "IX_ActivityInformations_projectLevelId",
                table: "ActivityInformations");

            migrationBuilder.RenameColumn(
                name: "projectLevelId",
                table: "ActivityInformations",
                newName: "typeId");

            migrationBuilder.AlterColumn<int>(
                name: "activityTypeId",
                table: "ActivityInformations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_ActivityInformations_ActivityTypes_activityTypeId",
                table: "ActivityInformations",
                column: "activityTypeId",
                principalTable: "ActivityTypes",
                principalColumn: "activityTypeId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
