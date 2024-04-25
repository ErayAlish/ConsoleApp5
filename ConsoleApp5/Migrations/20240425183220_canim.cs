using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConsoleApp5.Migrations
{
    public partial class canim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DietPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    CaloriesPerDay = table.Column<int>(type: "INTEGER", nullable: false),
                    ProteinsPerDay = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DietPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Meals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Calories = table.Column<int>(type: "INTEGER", nullable: false),
                    Proteins = table.Column<int>(type: "INTEGER", nullable: false),
                    TimeOfDay = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingsPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Dauer = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingsPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Height = table.Column<double>(type: "REAL", nullable: false),
                    Gender = table.Column<char>(type: "TEXT", nullable: false),
                    DailyActivity = table.Column<double>(type: "REAL", nullable: false),
                    Goal = table.Column<string>(type: "TEXT", nullable: false),
                    TrainingDays = table.Column<int>(type: "INTEGER", nullable: false),
                    TrainingHoursPerDay = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aktivitäts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Wdh = table.Column<int>(type: "INTEGER", nullable: false),
                    WdhPS = table.Column<int>(type: "INTEGER", nullable: false),
                    Dauer = table.Column<int>(type: "INTEGER", nullable: false),
                    Typ = table.Column<string>(type: "TEXT", nullable: false),
                    TrainingsPlanId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktivitäts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aktivitäts_TrainingsPlans_TrainingsPlanId",
                        column: x => x.TrainingsPlanId,
                        principalTable: "TrainingsPlans",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aktivitäts_TrainingsPlanId",
                table: "Aktivitäts",
                column: "TrainingsPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktivitäts");

            migrationBuilder.DropTable(
                name: "DietPlans");

            migrationBuilder.DropTable(
                name: "Meals");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "TrainingsPlans");
        }
    }
}
