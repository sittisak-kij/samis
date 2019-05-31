using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace samis.Migrations
{
    public partial class addprojecttimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "timestamp",
                table: "ActivityInformations",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "timestamp",
                table: "ActivityInformations");
        }
    }
}
