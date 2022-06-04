using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mathematio.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContestJudges",
                columns: table => new
                {
                    ContestID = table.Column<int>(type: "int", nullable: false),
                    MentorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestJudges", x => new { x.ContestID, x.MentorID });
                });

            migrationBuilder.CreateTable(
                name: "ContestProblems",
                columns: table => new
                {
                    ContestID = table.Column<int>(type: "int", nullable: false),
                    ProblemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestProblems", x => new { x.ContestID, x.ProblemID });
                });

            migrationBuilder.CreateTable(
                name: "ContestSubmissions",
                columns: table => new
                {
                    ContestID = table.Column<int>(type: "int", nullable: false),
                    ProblemID = table.Column<int>(type: "int", nullable: false),
                    ContestantID = table.Column<int>(type: "int", nullable: false),
                    Solution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContestSubmissions", x => new { x.ContestID, x.ProblemID, x.ContestantID });
                });

            migrationBuilder.CreateTable(
                name: "Mentorships",
                columns: table => new
                {
                    MentorID = table.Column<int>(type: "int", nullable: false),
                    ContestantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentorships", x => new { x.MentorID, x.ContestantID });
                });

            migrationBuilder.CreateTable(
                name: "Participants",
                columns: table => new
                {
                    ContestID = table.Column<int>(type: "int", nullable: false),
                    ContestantID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Participants", x => new { x.ContestID, x.ContestantID });
                });

            migrationBuilder.CreateTable(
                name: "ProblemAreas",
                columns: table => new
                {
                    ProblemID = table.Column<int>(type: "int", nullable: false),
                    AreaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemAreas", x => new { x.ProblemID, x.AreaID });
                });

            migrationBuilder.CreateTable(
                name: "ProblemAuthors",
                columns: table => new
                {
                    ProblemID = table.Column<int>(type: "int", nullable: false),
                    MentorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProblemAuthors", x => new { x.ProblemID, x.MentorID });
                });

            migrationBuilder.CreateTable(
                name: "Contestants",
                columns: table => new
                {
                    ContestantID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    School = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ContestantPoints = table.Column<int>(type: "int", nullable: false),
                    ContestSubmissionsContestID = table.Column<int>(type: "int", nullable: true),
                    ContestSubmissionsContestantID = table.Column<int>(type: "int", nullable: true),
                    ContestSubmissionsProblemID = table.Column<int>(type: "int", nullable: true),
                    MentorshipContestantID = table.Column<int>(type: "int", nullable: true),
                    MentorshipMentorID = table.Column<int>(type: "int", nullable: true),
                    ParticipantsContestID = table.Column<int>(type: "int", nullable: true),
                    ParticipantsContestantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contestants", x => x.ContestantID);
                    table.ForeignKey(
                        name: "FK_Contestants_ContestSubmissions_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                        columns: x => new { x.ContestSubmissionsContestID, x.ContestSubmissionsProblemID, x.ContestSubmissionsContestantID },
                        principalTable: "ContestSubmissions",
                        principalColumns: new[] { "ContestID", "ProblemID", "ContestantID" });
                    table.ForeignKey(
                        name: "FK_Contestants_Mentorships_MentorshipMentorID_MentorshipContestantID",
                        columns: x => new { x.MentorshipMentorID, x.MentorshipContestantID },
                        principalTable: "Mentorships",
                        principalColumns: new[] { "MentorID", "ContestantID" });
                    table.ForeignKey(
                        name: "FK_Contestants_Participants_ParticipantsContestID_ParticipantsContestantID",
                        columns: x => new { x.ParticipantsContestID, x.ParticipantsContestantID },
                        principalTable: "Participants",
                        principalColumns: new[] { "ContestID", "ContestantID" });
                });

            migrationBuilder.CreateTable(
                name: "Contests",
                columns: table => new
                {
                    ContestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ContestJudgesContestID = table.Column<int>(type: "int", nullable: true),
                    ContestJudgesMentorID = table.Column<int>(type: "int", nullable: true),
                    ContestProblemsContestID = table.Column<int>(type: "int", nullable: true),
                    ContestProblemsProblemID = table.Column<int>(type: "int", nullable: true),
                    ContestSubmissionsContestID = table.Column<int>(type: "int", nullable: true),
                    ContestSubmissionsContestantID = table.Column<int>(type: "int", nullable: true),
                    ContestSubmissionsProblemID = table.Column<int>(type: "int", nullable: true),
                    ParticipantsContestID = table.Column<int>(type: "int", nullable: true),
                    ParticipantsContestantID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contests", x => x.ContestID);
                    table.ForeignKey(
                        name: "FK_Contests_ContestJudges_ContestJudgesContestID_ContestJudgesMentorID",
                        columns: x => new { x.ContestJudgesContestID, x.ContestJudgesMentorID },
                        principalTable: "ContestJudges",
                        principalColumns: new[] { "ContestID", "MentorID" });
                    table.ForeignKey(
                        name: "FK_Contests_ContestProblems_ContestProblemsContestID_ContestProblemsProblemID",
                        columns: x => new { x.ContestProblemsContestID, x.ContestProblemsProblemID },
                        principalTable: "ContestProblems",
                        principalColumns: new[] { "ContestID", "ProblemID" });
                    table.ForeignKey(
                        name: "FK_Contests_ContestSubmissions_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                        columns: x => new { x.ContestSubmissionsContestID, x.ContestSubmissionsProblemID, x.ContestSubmissionsContestantID },
                        principalTable: "ContestSubmissions",
                        principalColumns: new[] { "ContestID", "ProblemID", "ContestantID" });
                    table.ForeignKey(
                        name: "FK_Contests_Participants_ParticipantsContestID_ParticipantsContestantID",
                        columns: x => new { x.ParticipantsContestID, x.ParticipantsContestantID },
                        principalTable: "Participants",
                        principalColumns: new[] { "ContestID", "ContestantID" });
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ProblemAreasAreaID = table.Column<int>(type: "int", nullable: true),
                    ProblemAreasProblemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaID);
                    table.ForeignKey(
                        name: "FK_Areas_ProblemAreas_ProblemAreasProblemID_ProblemAreasAreaID",
                        columns: x => new { x.ProblemAreasProblemID, x.ProblemAreasAreaID },
                        principalTable: "ProblemAreas",
                        principalColumns: new[] { "ProblemID", "AreaID" });
                });

            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    MentorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Profession = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MentorPoints = table.Column<int>(type: "int", nullable: false),
                    ContestJudgesContestID = table.Column<int>(type: "int", nullable: true),
                    ContestJudgesMentorID = table.Column<int>(type: "int", nullable: true),
                    MentorshipContestantID = table.Column<int>(type: "int", nullable: true),
                    MentorshipMentorID = table.Column<int>(type: "int", nullable: true),
                    ProblemAuthorsMentorID = table.Column<int>(type: "int", nullable: true),
                    ProblemAuthorsProblemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.MentorID);
                    table.ForeignKey(
                        name: "FK_Mentors_ContestJudges_ContestJudgesContestID_ContestJudgesMentorID",
                        columns: x => new { x.ContestJudgesContestID, x.ContestJudgesMentorID },
                        principalTable: "ContestJudges",
                        principalColumns: new[] { "ContestID", "MentorID" });
                    table.ForeignKey(
                        name: "FK_Mentors_Mentorships_MentorshipMentorID_MentorshipContestantID",
                        columns: x => new { x.MentorshipMentorID, x.MentorshipContestantID },
                        principalTable: "Mentorships",
                        principalColumns: new[] { "MentorID", "ContestantID" });
                    table.ForeignKey(
                        name: "FK_Mentors_ProblemAuthors_ProblemAuthorsProblemID_ProblemAuthorsMentorID",
                        columns: x => new { x.ProblemAuthorsProblemID, x.ProblemAuthorsMentorID },
                        principalTable: "ProblemAuthors",
                        principalColumns: new[] { "ProblemID", "MentorID" });
                });

            migrationBuilder.CreateTable(
                name: "Problems",
                columns: table => new
                {
                    ProblemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContestProblemsContestID = table.Column<int>(type: "int", nullable: true),
                    ContestProblemsProblemID = table.Column<int>(type: "int", nullable: true),
                    ContestSubmissionsContestID = table.Column<int>(type: "int", nullable: true),
                    ContestSubmissionsContestantID = table.Column<int>(type: "int", nullable: true),
                    ContestSubmissionsProblemID = table.Column<int>(type: "int", nullable: true),
                    ProblemAreasAreaID = table.Column<int>(type: "int", nullable: true),
                    ProblemAreasProblemID = table.Column<int>(type: "int", nullable: true),
                    ProblemAuthorsMentorID = table.Column<int>(type: "int", nullable: true),
                    ProblemAuthorsProblemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problems", x => x.ProblemId);
                    table.ForeignKey(
                        name: "FK_Problems_ContestProblems_ContestProblemsContestID_ContestProblemsProblemID",
                        columns: x => new { x.ContestProblemsContestID, x.ContestProblemsProblemID },
                        principalTable: "ContestProblems",
                        principalColumns: new[] { "ContestID", "ProblemID" });
                    table.ForeignKey(
                        name: "FK_Problems_ContestSubmissions_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                        columns: x => new { x.ContestSubmissionsContestID, x.ContestSubmissionsProblemID, x.ContestSubmissionsContestantID },
                        principalTable: "ContestSubmissions",
                        principalColumns: new[] { "ContestID", "ProblemID", "ContestantID" });
                    table.ForeignKey(
                        name: "FK_Problems_ProblemAreas_ProblemAreasProblemID_ProblemAreasAreaID",
                        columns: x => new { x.ProblemAreasProblemID, x.ProblemAreasAreaID },
                        principalTable: "ProblemAreas",
                        principalColumns: new[] { "ProblemID", "AreaID" });
                    table.ForeignKey(
                        name: "FK_Problems_ProblemAuthors_ProblemAuthorsProblemID_ProblemAuthorsMentorID",
                        columns: x => new { x.ProblemAuthorsProblemID, x.ProblemAuthorsMentorID },
                        principalTable: "ProblemAuthors",
                        principalColumns: new[] { "ProblemID", "MentorID" });
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
                name: "IX_Areas_ProblemAreasProblemID_ProblemAreasAreaID",
                table: "Areas",
                columns: new[] { "ProblemAreasProblemID", "ProblemAreasAreaID" });

            migrationBuilder.CreateIndex(
                name: "IX_ContestantMentor_MentorsMentorID",
                table: "ContestantMentor",
                column: "MentorsMentorID");

            migrationBuilder.CreateIndex(
                name: "IX_Contestants_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Contestants",
                columns: new[] { "ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID" });

            migrationBuilder.CreateIndex(
                name: "IX_Contestants_MentorshipMentorID_MentorshipContestantID",
                table: "Contestants",
                columns: new[] { "MentorshipMentorID", "MentorshipContestantID" });

            migrationBuilder.CreateIndex(
                name: "IX_Contestants_ParticipantsContestID_ParticipantsContestantID",
                table: "Contestants",
                columns: new[] { "ParticipantsContestID", "ParticipantsContestantID" });

            migrationBuilder.CreateIndex(
                name: "IX_ContestContestant_ParticipantsContestantID",
                table: "ContestContestant",
                column: "ParticipantsContestantID");

            migrationBuilder.CreateIndex(
                name: "IX_ContestMentor_JudgesMentorID",
                table: "ContestMentor",
                column: "JudgesMentorID");

            migrationBuilder.CreateIndex(
                name: "IX_Contests_ContestJudgesContestID_ContestJudgesMentorID",
                table: "Contests",
                columns: new[] { "ContestJudgesContestID", "ContestJudgesMentorID" });

            migrationBuilder.CreateIndex(
                name: "IX_Contests_ContestProblemsContestID_ContestProblemsProblemID",
                table: "Contests",
                columns: new[] { "ContestProblemsContestID", "ContestProblemsProblemID" });

            migrationBuilder.CreateIndex(
                name: "IX_Contests_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Contests",
                columns: new[] { "ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID" });

            migrationBuilder.CreateIndex(
                name: "IX_Contests_ParticipantsContestID_ParticipantsContestantID",
                table: "Contests",
                columns: new[] { "ParticipantsContestID", "ParticipantsContestantID" });

            migrationBuilder.CreateIndex(
                name: "IX_MentorProblem_ProblemsProblemId",
                table: "MentorProblem",
                column: "ProblemsProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_Mentors_ContestJudgesContestID_ContestJudgesMentorID",
                table: "Mentors",
                columns: new[] { "ContestJudgesContestID", "ContestJudgesMentorID" });

            migrationBuilder.CreateIndex(
                name: "IX_Mentors_MentorshipMentorID_MentorshipContestantID",
                table: "Mentors",
                columns: new[] { "MentorshipMentorID", "MentorshipContestantID" });

            migrationBuilder.CreateIndex(
                name: "IX_Mentors_ProblemAuthorsProblemID_ProblemAuthorsMentorID",
                table: "Mentors",
                columns: new[] { "ProblemAuthorsProblemID", "ProblemAuthorsMentorID" });

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ContestProblemsContestID_ContestProblemsProblemID",
                table: "Problems",
                columns: new[] { "ContestProblemsContestID", "ContestProblemsProblemID" });

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Problems",
                columns: new[] { "ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID" });

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ProblemAreasProblemID_ProblemAreasAreaID",
                table: "Problems",
                columns: new[] { "ProblemAreasProblemID", "ProblemAreasAreaID" });

            migrationBuilder.CreateIndex(
                name: "IX_Problems_ProblemAuthorsProblemID_ProblemAuthorsMentorID",
                table: "Problems",
                columns: new[] { "ProblemAuthorsProblemID", "ProblemAuthorsMentorID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Contestants");

            migrationBuilder.DropTable(
                name: "Contests");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "Problems");

            migrationBuilder.DropTable(
                name: "Participants");

            migrationBuilder.DropTable(
                name: "ContestJudges");

            migrationBuilder.DropTable(
                name: "Mentorships");

            migrationBuilder.DropTable(
                name: "ContestProblems");

            migrationBuilder.DropTable(
                name: "ContestSubmissions");

            migrationBuilder.DropTable(
                name: "ProblemAreas");

            migrationBuilder.DropTable(
                name: "ProblemAuthors");
        }
    }
}
