using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace samis.Migrations
{
    public partial class c10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugets_BudgetTypes_budgetTypeId",
                table: "Bugets");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Bugets");

            migrationBuilder.RenameColumn(
                name: "budgetTypeId",
                table: "Bugets",
                newName: "budgetDescriptionId");

            migrationBuilder.RenameIndex(
                name: "IX_Bugets_budgetTypeId",
                table: "Bugets",
                newName: "IX_Bugets_budgetDescriptionId");

            migrationBuilder.CreateTable(
                name: "BudgetDescription",
                columns: table => new
                {
                    budgetDescriptionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    budgetTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDescription", x => x.budgetDescriptionId);
                    table.ForeignKey(
                        name: "FK_BudgetDescription_BudgetTypes_budgetTypeId",
                        column: x => x.budgetTypeId,
                        principalTable: "BudgetTypes",
                        principalColumn: "budgetTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BudgetDescription_budgetTypeId",
                table: "BudgetDescription",
                column: "budgetTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bugets_BudgetDescription_budgetDescriptionId",
                table: "Bugets",
                column: "budgetDescriptionId",
                principalTable: "BudgetDescription",
                principalColumn: "budgetDescriptionId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugets_BudgetDescription_budgetDescriptionId",
                table: "Bugets");

            migrationBuilder.DropTable(
                name: "BudgetDescription");

            migrationBuilder.RenameColumn(
                name: "budgetDescriptionId",
                table: "Bugets",
                newName: "budgetTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Bugets_budgetDescriptionId",
                table: "Bugets",
                newName: "IX_Bugets_budgetTypeId");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Bugets",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Bugets_BudgetTypes_budgetTypeId",
                table: "Bugets",
                column: "budgetTypeId",
                principalTable: "BudgetTypes",
                principalColumn: "budgetTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
