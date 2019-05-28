using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace samis.Migrations
{
    public partial class c9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugets_BudgetDetails_budgetDetailId",
                table: "Bugets");

            migrationBuilder.DropTable(
                name: "BudgetDetails");

            migrationBuilder.RenameColumn(
                name: "budgetDetailId",
                table: "Bugets",
                newName: "budgetStatusId");

            migrationBuilder.RenameIndex(
                name: "IX_Bugets_budgetDetailId",
                table: "Bugets",
                newName: "IX_Bugets_budgetStatusId");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Bugets",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BudgetStatus",
                columns: table => new
                {
                    budgetStatusId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetStatus", x => x.budgetStatusId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bugets_BudgetStatus_budgetStatusId",
                table: "Bugets",
                column: "budgetStatusId",
                principalTable: "BudgetStatus",
                principalColumn: "budgetStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bugets_BudgetStatus_budgetStatusId",
                table: "Bugets");

            migrationBuilder.DropTable(
                name: "BudgetStatus");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Bugets");

            migrationBuilder.RenameColumn(
                name: "budgetStatusId",
                table: "Bugets",
                newName: "budgetDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_Bugets_budgetStatusId",
                table: "Bugets",
                newName: "IX_Bugets_budgetDetailId");

            migrationBuilder.CreateTable(
                name: "BudgetDetails",
                columns: table => new
                {
                    budgetDetailId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    budgetDetailDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetDetails", x => x.budgetDetailId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Bugets_BudgetDetails_budgetDetailId",
                table: "Bugets",
                column: "budgetDetailId",
                principalTable: "BudgetDetails",
                principalColumn: "budgetDetailId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
