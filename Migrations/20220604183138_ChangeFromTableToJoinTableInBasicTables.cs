using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mathematio.Migrations
{
    public partial class ChangeFromTableToJoinTableInBasicTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaProblem");

            migrationBuilder.DropTable(
                name: "ContestantMentor");

            migrationBuilder.DropTable(
                name: "ContestContestant");

            migrationBuilder.DropTable(
                name: "ContestMentor");

            migrationBuilder.DropTable(
                name: "MentorProblem");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AreaProblem",
                columns: table => new
                {
                    AreasAreaID = table.Column<int>(type: "int", nullable: false),
                    ProblemsProblemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaProblem", x => new { x.AreasAreaID, x.ProblemsProblemId });
                    table.ForeignKey(
                        name: "FK_AreaProblem_Areas_AreasAreaID",
                        column: x => x.AreasAreaID,
                        principalTable: "Areas",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaProblem_Problems_ProblemsProblemId",
                        column: x => x.ProblemsProblemId,
                        principalTable: "Problems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestantMentor",
                columns: table => new
                {
                    ContestantsContestantID = table.Column<int>(type: "int", nullable: false),
                    MentorsMentorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestantMentor", x => new { x.ContestantsContestantID, x.MentorsMentorID });
                    table.ForeignKey(
                        name: "FK_ContestantMentor_Contestants_ContestantsContestantID",
                        column: x => x.ContestantsContestantID,
                        principalTable: "Contestants",
                        principalColumn: "ContestantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestantMentor_Mentors_MentorsMentorID",
                        column: x => x.MentorsMentorID,
                        principalTable: "Mentors",
                        principalColumn: "MentorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestContestant",
                columns: table => new
                {
                    ContestsContestID = table.Column<int>(type: "int", nullable: false),
                    ParticipantsContestantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestContestant", x => new { x.ContestsContestID, x.ParticipantsContestantID });
                    table.ForeignKey(
                        name: "FK_ContestContestant_Contestants_ParticipantsContestantID",
                        column: x => x.ParticipantsContestantID,
                        principalTable: "Contestants",
                        principalColumn: "ContestantID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestContestant_Contests_ContestsContestID",
                        column: x => x.ContestsContestID,
                        principalTable: "Contests",
                        principalColumn: "ContestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContestMentor",
                columns: table => new
                {
                    ContestsContestID = table.Column<int>(type: "int", nullable: false),
                    JudgesMentorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestMentor", x => new { x.ContestsContestID, x.JudgesMentorID });
                    table.ForeignKey(
                        name: "FK_ContestMentor_Contests_ContestsContestID",
                        column: x => x.ContestsContestID,
                        principalTable: "Contests",
                        principalColumn: "ContestID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContestMentor_Mentors_JudgesMentorID",
                        column: x => x.JudgesMentorID,
                        principalTable: "Mentors",
                        principalColumn: "MentorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MentorProblem",
                columns: table => new
                {
                    AuthorsMentorID = table.Column<int>(type: "int", nullable: false),
                    ProblemsProblemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MentorProblem", x => new { x.AuthorsMentorID, x.ProblemsProblemId });
                    table.ForeignKey(
                        name: "FK_MentorProblem_Mentors_AuthorsMentorID",
                        column: x => x.AuthorsMentorID,
                        principalTable: "Mentors",
                        principalColumn: "MentorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MentorProblem_Problems_ProblemsProblemId",
                        column: x => x.ProblemsProblemId,
                        principalTable: "Problems",
                        principalColumn: "ProblemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaProblem_ProblemsProblemId",
                table: "AreaProblem",
                column: "ProblemsProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_ContestantMentor_MentorsMentorID",
                table: "ContestantMentor",
                column: "MentorsMentorID");

            migrationBuilder.CreateIndex(
                name: "IX_ContestContestant_ParticipantsContestantID",
                table: "ContestContestant",
                column: "ParticipantsContestantID");

            migrationBuilder.CreateIndex(
                name: "IX_ContestMentor_JudgesMentorID",
                table: "ContestMentor",
                column: "JudgesMentorID");

            migrationBuilder.CreateIndex(
                name: "IX_MentorProblem_ProblemsProblemId",
                table: "MentorProblem",
                column: "ProblemsProblemId");
        }
    }
}
