using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace samis.Migrations
{
    public partial class createdatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityTypes",
                columns: table => new
                {
                    activityTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    actyivityTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityTypes", x => x.activityTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ActivityUnits",
                columns: table => new
                {
                    activityUnitId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityUnits", x => x.activityUnitId);
                });

            migrationBuilder.CreateTable(
                name: "AdvisorPositions",
                columns: table => new
                {
                    advisorPositionId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    advisorPositionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvisorPositions", x => x.advisorPositionId);
                });

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

            migrationBuilder.CreateTable(
                name: "BudgetTypes",
                columns: table => new
                {
                    budgetTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    budgetTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetTypes", x => x.budgetTypeId);
                });

            migrationBuilder.CreateTable(
                name: "LocationTypes",
                columns: table => new
                {
                    locationTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    locationTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationTypes", x => x.locationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "OrganizerTypes",
                columns: table => new
                {
                    organizerTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    organizerTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizerTypes", x => x.organizerTypeId);
                });

            migrationBuilder.CreateTable(
                name: "StatusTypes",
                columns: table => new
                {
                    statusTypeId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    statusTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusTypes", x => x.statusTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    studentId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    studentCode = table.Column<int>(nullable: false),
                    studentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.studentId);
                });

            migrationBuilder.CreateTable(
                name: "Advisors",
                columns: table => new
                {
                    advisorId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(nullable: true),
                    advisorPositionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advisors", x => x.advisorId);
                    table.ForeignKey(
                        name: "FK_Advisors_AdvisorPositions_advisorPositionId",
                        column: x => x.advisorPositionId,
                        principalTable: "AdvisorPositions",
                        principalColumn: "advisorPositionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityInformations",
                columns: table => new
                {
                    activityId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    activityUnitId = table.Column<int>(nullable: false),
                    referenceNumber = table.Column<string>(nullable: true),
                    activityName = table.Column<string>(nullable: true),
                    typeId = table.Column<int>(nullable: false),
                    activityTypeId = table.Column<int>(nullable: true),
                    startDate = table.Column<DateTime>(nullable: true),
                    endDate = table.Column<DateTime>(nullable: true),
                    locationTypeId = table.Column<int>(nullable: false),
                    venue = table.Column<string>(nullable: true),
                    semester = table.Column<int>(nullable: false),
                    year = table.Column<int>(nullable: false),
                    participant = table.Column<int>(nullable: false),
                    statusTypeId = table.Column<int>(nullable: false),
                    advisorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityInformations", x => x.activityId);
                    table.ForeignKey(
                        name: "FK_ActivityInformations_ActivityTypes_activityTypeId",
                        column: x => x.activityTypeId,
                        principalTable: "ActivityTypes",
                        principalColumn: "activityTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityInformations_ActivityUnits_activityUnitId",
                        column: x => x.activityUnitId,
                        principalTable: "ActivityUnits",
                        principalColumn: "activityUnitId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityInformations_Advisors_advisorId",
                        column: x => x.advisorId,
                        principalTable: "Advisors",
                        principalColumn: "advisorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityInformations_LocationTypes_locationTypeId",
                        column: x => x.locationTypeId,
                        principalTable: "LocationTypes",
                        principalColumn: "locationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityInformations_StatusTypes_statusTypeId",
                        column: x => x.statusTypeId,
                        principalTable: "StatusTypes",
                        principalColumn: "statusTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bugets",
                columns: table => new
                {
                    budgetId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    activityId = table.Column<int>(nullable: false),
                    budgetDetailId = table.Column<int>(nullable: false),
                    amount = table.Column<double>(nullable: false),
                    budgetTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bugets", x => x.budgetId);
                    table.ForeignKey(
                        name: "FK_Bugets_ActivityInformations_activityId",
                        column: x => x.activityId,
                        principalTable: "ActivityInformations",
                        principalColumn: "activityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bugets_BudgetDetails_budgetDetailId",
                        column: x => x.budgetDetailId,
                        principalTable: "BudgetDetails",
                        principalColumn: "budgetDetailId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bugets_BudgetTypes_budgetTypeId",
                        column: x => x.budgetTypeId,
                        principalTable: "BudgetTypes",
                        principalColumn: "budgetTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Origanizers",
                columns: table => new
                {
                    organizerId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    activityId = table.Column<int>(nullable: false),
                    studentId = table.Column<int>(nullable: false),
                    organierTypeId = table.Column<int>(nullable: false),
                    organizerTypeId = table.Column<int>(nullable: true),
                    phoneNumber = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Origanizers", x => x.organizerId);
                    table.ForeignKey(
                        name: "FK_Origanizers_ActivityInformations_activityId",
                        column: x => x.activityId,
                        principalTable: "ActivityInformations",
                        principalColumn: "activityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Origanizers_OrganizerTypes_organizerTypeId",
                        column: x => x.organizerTypeId,
                        principalTable: "OrganizerTypes",
                        principalColumn: "organizerTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Origanizers_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Praticipants",
                columns: table => new
                {
                    participantId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    activityId = table.Column<int>(nullable: false),
                    studentId = table.Column<int>(nullable: false),
                    phoneNumber = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Praticipants", x => x.participantId);
                    table.ForeignKey(
                        name: "FK_Praticipants_ActivityInformations_activityId",
                        column: x => x.activityId,
                        principalTable: "ActivityInformations",
                        principalColumn: "activityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Praticipants_Students_studentId",
                        column: x => x.studentId,
                        principalTable: "Students",
                        principalColumn: "studentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInformations_activityTypeId",
                table: "ActivityInformations",
                column: "activityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInformations_activityUnitId",
                table: "ActivityInformations",
                column: "activityUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInformations_advisorId",
                table: "ActivityInformations",
                column: "advisorId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInformations_locationTypeId",
                table: "ActivityInformations",
                column: "locationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityInformations_statusTypeId",
                table: "ActivityInformations",
                column: "statusTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Advisors_advisorPositionId",
                table: "Advisors",
                column: "advisorPositionId");

            migrationBuilder.CreateIndex(
                name: "IX_Bugets_activityId",
                table: "Bugets",
                column: "activityId");

            migrationBuilder.CreateIndex(
                name: "IX_Bugets_budgetDetailId",
                table: "Bugets",
                column: "budgetDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Bugets_budgetTypeId",
                table: "Bugets",
                column: "budgetTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Origanizers_activityId",
                table: "Origanizers",
                column: "activityId");

            migrationBuilder.CreateIndex(
                name: "IX_Origanizers_organizerTypeId",
                table: "Origanizers",
                column: "organizerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Origanizers_studentId",
                table: "Origanizers",
                column: "studentId");

            migrationBuilder.CreateIndex(
                name: "IX_Praticipants_activityId",
                table: "Praticipants",
                column: "activityId");

            migrationBuilder.CreateIndex(
                name: "IX_Praticipants_studentId",
                table: "Praticipants",
                column: "studentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bugets");

            migrationBuilder.DropTable(
                name: "Origanizers");

            migrationBuilder.DropTable(
                name: "Praticipants");

            migrationBuilder.DropTable(
                name: "BudgetDetails");

            migrationBuilder.DropTable(
                name: "BudgetTypes");

            migrationBuilder.DropTable(
                name: "OrganizerTypes");

            migrationBuilder.DropTable(
                name: "ActivityInformations");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "ActivityTypes");

            migrationBuilder.DropTable(
                name: "ActivityUnits");

            migrationBuilder.DropTable(
                name: "Advisors");

            migrationBuilder.DropTable(
                name: "LocationTypes");

            migrationBuilder.DropTable(
                name: "StatusTypes");

            migrationBuilder.DropTable(
                name: "AdvisorPositions");
        }
    }
}
