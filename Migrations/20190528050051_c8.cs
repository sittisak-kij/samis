using Microsoft.EntityFrameworkCore.Migrations;

namespace samis.Migrations
{
    public partial class c8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "actyivityTypeName",
                table: "ActivityTypes",
                newName: "activityTypeName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "activityTypeName",
                table: "ActivityTypes",
                newName: "actyivityTypeName");
        }
    }
}
