using Microsoft.EntityFrameworkCore.Migrations;

namespace samis.Migrations
{
    public partial class changeadvisortable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Advisors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lineID",
                table: "Advisors",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phoneNumber",
                table: "Advisors",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "email",
                table: "Advisors");

            migrationBuilder.DropColumn(
                name: "lineID",
                table: "Advisors");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "Advisors");
        }
    }
}
