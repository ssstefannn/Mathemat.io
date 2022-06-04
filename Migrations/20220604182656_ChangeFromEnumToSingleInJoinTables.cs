using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mathematio.Migrations
{
    public partial class ChangeFromEnumToSingleInJoinTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Areas_ProblemAreas_ProblemAreasProblemID_ProblemAreasAreaID",
                table: "Areas");

            migrationBuilder.DropForeignKey(
                name: "FK_Contestants_ContestSubmissions_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Contestants");

            migrationBuilder.DropForeignKey(
                name: "FK_Contestants_Mentorships_MentorshipMentorID_MentorshipContestantID",
                table: "Contestants");

            migrationBuilder.DropForeignKey(
                name: "FK_Contestants_Participants_ParticipantsContestID_ParticipantsContestantID",
                table: "Contestants");

            migrationBuilder.DropForeignKey(
                name: "FK_Contests_ContestJudges_ContestJudgesContestID_ContestJudgesMentorID",
                table: "Contests");

            migrationBuilder.DropForeignKey(
                name: "FK_Contests_ContestProblems_ContestProblemsContestID_ContestProblemsProblemID",
                table: "Contests");

            migrationBuilder.DropForeignKey(
                name: "FK_Contests_ContestSubmissions_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Contests");

            migrationBuilder.DropForeignKey(
                name: "FK_Contests_Participants_ParticipantsContestID_ParticipantsContestantID",
                table: "Contests");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_ContestJudges_ContestJudgesContestID_ContestJudgesMentorID",
                table: "Mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_Mentorships_MentorshipMentorID_MentorshipContestantID",
                table: "Mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentors_ProblemAuthors_ProblemAuthorsProblemID_ProblemAuthorsMentorID",
                table: "Mentors");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_ContestProblems_ContestProblemsContestID_ContestProblemsProblemID",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_ContestSubmissions_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_ProblemAreas_ProblemAreasProblemID_ProblemAreasAreaID",
                table: "Problems");

            migrationBuilder.DropForeignKey(
                name: "FK_Problems_ProblemAuthors_ProblemAuthorsProblemID_ProblemAuthorsMentorID",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_Problems_ContestProblemsContestID_ContestProblemsProblemID",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_Problems_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_Problems_ProblemAreasProblemID_ProblemAreasAreaID",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_Problems_ProblemAuthorsProblemID_ProblemAuthorsMentorID",
                table: "Problems");

            migrationBuilder.DropIndex(
                name: "IX_Mentors_ContestJudgesContestID_ContestJudgesMentorID",
                table: "Mentors");

            migrationBuilder.DropIndex(
                name: "IX_Mentors_MentorshipMentorID_MentorshipContestantID",
                table: "Mentors");

            migrationBuilder.DropIndex(
                name: "IX_Mentors_ProblemAuthorsProblemID_ProblemAuthorsMentorID",
                table: "Mentors");

            migrationBuilder.DropIndex(
                name: "IX_Contests_ContestJudgesContestID_ContestJudgesMentorID",
                table: "Contests");

            migrationBuilder.DropIndex(
                name: "IX_Contests_ContestProblemsContestID_ContestProblemsProblemID",
                table: "Contests");

            migrationBuilder.DropIndex(
                name: "IX_Contests_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Contests");

            migrationBuilder.DropIndex(
                name: "IX_Contests_ParticipantsContestID_ParticipantsContestantID",
                table: "Contests");

            migrationBuilder.DropIndex(
                name: "IX_Contestants_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Contestants");

            migrationBuilder.DropIndex(
                name: "IX_Contestants_MentorshipMentorID_MentorshipContestantID",
                table: "Contestants");

            migrationBuilder.DropIndex(
                name: "IX_Contestants_ParticipantsContestID_ParticipantsContestantID",
                table: "Contestants");

            migrationBuilder.DropIndex(
                name: "IX_Areas_ProblemAreasProblemID_ProblemAreasAreaID",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "ContestProblemsContestID",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ContestProblemsProblemID",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ContestSubmissionsContestID",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ContestSubmissionsContestantID",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ContestSubmissionsProblemID",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ProblemAreasAreaID",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ProblemAreasProblemID",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ProblemAuthorsMentorID",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ProblemAuthorsProblemID",
                table: "Problems");

            migrationBuilder.DropColumn(
                name: "ContestJudgesContestID",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ContestJudgesMentorID",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "MentorshipContestantID",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "MentorshipMentorID",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ProblemAuthorsMentorID",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ProblemAuthorsProblemID",
                table: "Mentors");

            migrationBuilder.DropColumn(
                name: "ContestJudgesContestID",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ContestJudgesMentorID",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ContestProblemsContestID",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ContestProblemsProblemID",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ContestSubmissionsContestID",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ContestSubmissionsContestantID",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ContestSubmissionsProblemID",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ParticipantsContestID",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ParticipantsContestantID",
                table: "Contests");

            migrationBuilder.DropColumn(
                name: "ContestSubmissionsContestID",
                table: "Contestants");

            migrationBuilder.DropColumn(
                name: "ContestSubmissionsContestantID",
                table: "Contestants");

            migrationBuilder.DropColumn(
                name: "ContestSubmissionsProblemID",
                table: "Contestants");

            migrationBuilder.DropColumn(
                name: "MentorshipContestantID",
                table: "Contestants");

            migrationBuilder.DropColumn(
                name: "MentorshipMentorID",
                table: "Contestants");

            migrationBuilder.DropColumn(
                name: "ParticipantsContestID",
                table: "Contestants");

            migrationBuilder.DropColumn(
                name: "ParticipantsContestantID",
                table: "Contestants");

            migrationBuilder.DropColumn(
                name: "ProblemAreasAreaID",
                table: "Areas");

            migrationBuilder.DropColumn(
                name: "ProblemAreasProblemID",
                table: "Areas");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemAuthors_MentorID",
                table: "ProblemAuthors",
                column: "MentorID");

            migrationBuilder.CreateIndex(
                name: "IX_ProblemAreas_AreaID",
                table: "ProblemAreas",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_Participants_ContestantID",
                table: "Participants",
                column: "ContestantID");

            migrationBuilder.CreateIndex(
                name: "IX_Mentorships_ContestantID",
                table: "Mentorships",
                column: "ContestantID");

            migrationBuilder.CreateIndex(
                name: "IX_ContestSubmissions_ContestantID",
                table: "ContestSubmissions",
                column: "ContestantID");

            migrationBuilder.CreateIndex(
                name: "IX_ContestSubmissions_ProblemID",
                table: "ContestSubmissions",
                column: "ProblemID");

            migrationBuilder.CreateIndex(
                name: "IX_ContestProblems_ProblemID",
                table: "ContestProblems",
                column: "ProblemID");

            migrationBuilder.CreateIndex(
                name: "IX_ContestJudges_MentorID",
                table: "ContestJudges",
                column: "MentorID");

            migrationBuilder.AddForeignKey(
                name: "FK_ContestJudges_Contests_ContestID",
                table: "ContestJudges",
                column: "ContestID",
                principalTable: "Contests",
                principalColumn: "ContestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestJudges_Mentors_MentorID",
                table: "ContestJudges",
                column: "MentorID",
                principalTable: "Mentors",
                principalColumn: "MentorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestProblems_Contests_ContestID",
                table: "ContestProblems",
                column: "ContestID",
                principalTable: "Contests",
                principalColumn: "ContestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestProblems_Problems_ProblemID",
                table: "ContestProblems",
                column: "ProblemID",
                principalTable: "Problems",
                principalColumn: "ProblemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestSubmissions_Contestants_ContestantID",
                table: "ContestSubmissions",
                column: "ContestantID",
                principalTable: "Contestants",
                principalColumn: "ContestantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestSubmissions_Contests_ContestID",
                table: "ContestSubmissions",
                column: "ContestID",
                principalTable: "Contests",
                principalColumn: "ContestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContestSubmissions_Problems_ProblemID",
                table: "ContestSubmissions",
                column: "ProblemID",
                principalTable: "Problems",
                principalColumn: "ProblemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentorships_Contestants_ContestantID",
                table: "Mentorships",
                column: "ContestantID",
                principalTable: "Contestants",
                principalColumn: "ContestantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Mentorships_Mentors_MentorID",
                table: "Mentorships",
                column: "MentorID",
                principalTable: "Mentors",
                principalColumn: "MentorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Contestants_ContestantID",
                table: "Participants",
                column: "ContestantID",
                principalTable: "Contestants",
                principalColumn: "ContestantID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_Contests_ContestID",
                table: "Participants",
                column: "ContestID",
                principalTable: "Contests",
                principalColumn: "ContestID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemAreas_Areas_AreaID",
                table: "ProblemAreas",
                column: "AreaID",
                principalTable: "Areas",
                principalColumn: "AreaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemAreas_Problems_ProblemID",
                table: "ProblemAreas",
                column: "ProblemID",
                principalTable: "Problems",
                principalColumn: "ProblemId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemAuthors_Mentors_MentorID",
                table: "ProblemAuthors",
                column: "MentorID",
                principalTable: "Mentors",
                principalColumn: "MentorID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProblemAuthors_Problems_ProblemID",
                table: "ProblemAuthors",
                column: "ProblemID",
                principalTable: "Problems",
                principalColumn: "ProblemId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContestJudges_Contests_ContestID",
                table: "ContestJudges");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestJudges_Mentors_MentorID",
                table: "ContestJudges");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestProblems_Contests_ContestID",
                table: "ContestProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestProblems_Problems_ProblemID",
                table: "ContestProblems");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestSubmissions_Contestants_ContestantID",
                table: "ContestSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestSubmissions_Contests_ContestID",
                table: "ContestSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_ContestSubmissions_Problems_ProblemID",
                table: "ContestSubmissions");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentorships_Contestants_ContestantID",
                table: "Mentorships");

            migrationBuilder.DropForeignKey(
                name: "FK_Mentorships_Mentors_MentorID",
                table: "Mentorships");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Contestants_ContestantID",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_Participants_Contests_ContestID",
                table: "Participants");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemAreas_Areas_AreaID",
                table: "ProblemAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemAreas_Problems_ProblemID",
                table: "ProblemAreas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemAuthors_Mentors_MentorID",
                table: "ProblemAuthors");

            migrationBuilder.DropForeignKey(
                name: "FK_ProblemAuthors_Problems_ProblemID",
                table: "ProblemAuthors");

            migrationBuilder.DropIndex(
                name: "IX_ProblemAuthors_MentorID",
                table: "ProblemAuthors");

            migrationBuilder.DropIndex(
                name: "IX_ProblemAreas_AreaID",
                table: "ProblemAreas");

            migrationBuilder.DropIndex(
                name: "IX_Participants_ContestantID",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Mentorships_ContestantID",
                table: "Mentorships");

            migrationBuilder.DropIndex(
                name: "IX_ContestSubmissions_ContestantID",
                table: "ContestSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_ContestSubmissions_ProblemID",
                table: "ContestSubmissions");

            migrationBuilder.DropIndex(
                name: "IX_ContestProblems_ProblemID",
                table: "ContestProblems");

            migrationBuilder.DropIndex(
                name: "IX_ContestJudges_MentorID",
                table: "ContestJudges");

            migrationBuilder.AddColumn<int>(
                name: "ContestProblemsContestID",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestProblemsProblemID",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestSubmissionsContestID",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestSubmissionsContestantID",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestSubmissionsProblemID",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProblemAreasAreaID",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProblemAreasProblemID",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProblemAuthorsMentorID",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProblemAuthorsProblemID",
                table: "Problems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestJudgesContestID",
                table: "Mentors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestJudgesMentorID",
                table: "Mentors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MentorshipContestantID",
                table: "Mentors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MentorshipMentorID",
                table: "Mentors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProblemAuthorsMentorID",
                table: "Mentors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProblemAuthorsProblemID",
                table: "Mentors",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestJudgesContestID",
                table: "Contests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestJudgesMentorID",
                table: "Contests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestProblemsContestID",
                table: "Contests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestProblemsProblemID",
                table: "Contests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestSubmissionsContestID",
                table: "Contests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestSubmissionsContestantID",
                table: "Contests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestSubmissionsProblemID",
                table: "Contests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipantsContestID",
                table: "Contests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipantsContestantID",
                table: "Contests",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestSubmissionsContestID",
                table: "Contestants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestSubmissionsContestantID",
                table: "Contestants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ContestSubmissionsProblemID",
                table: "Contestants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MentorshipContestantID",
                table: "Contestants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MentorshipMentorID",
                table: "Contestants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipantsContestID",
                table: "Contestants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipantsContestantID",
                table: "Contestants",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProblemAreasAreaID",
                table: "Areas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProblemAreasProblemID",
                table: "Areas",
                type: "int",
                nullable: true);

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
                name: "IX_Areas_ProblemAreasProblemID_ProblemAreasAreaID",
                table: "Areas",
                columns: new[] { "ProblemAreasProblemID", "ProblemAreasAreaID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Areas_ProblemAreas_ProblemAreasProblemID_ProblemAreasAreaID",
                table: "Areas",
                columns: new[] { "ProblemAreasProblemID", "ProblemAreasAreaID" },
                principalTable: "ProblemAreas",
                principalColumns: new[] { "ProblemID", "AreaID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Contestants_ContestSubmissions_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Contestants",
                columns: new[] { "ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID" },
                principalTable: "ContestSubmissions",
                principalColumns: new[] { "ContestID", "ProblemID", "ContestantID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Contestants_Mentorships_MentorshipMentorID_MentorshipContestantID",
                table: "Contestants",
                columns: new[] { "MentorshipMentorID", "MentorshipContestantID" },
                principalTable: "Mentorships",
                principalColumns: new[] { "MentorID", "ContestantID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Contestants_Participants_ParticipantsContestID_ParticipantsContestantID",
                table: "Contestants",
                columns: new[] { "ParticipantsContestID", "ParticipantsContestantID" },
                principalTable: "Participants",
                principalColumns: new[] { "ContestID", "ContestantID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Contests_ContestJudges_ContestJudgesContestID_ContestJudgesMentorID",
                table: "Contests",
                columns: new[] { "ContestJudgesContestID", "ContestJudgesMentorID" },
                principalTable: "ContestJudges",
                principalColumns: new[] { "ContestID", "MentorID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Contests_ContestProblems_ContestProblemsContestID_ContestProblemsProblemID",
                table: "Contests",
                columns: new[] { "ContestProblemsContestID", "ContestProblemsProblemID" },
                principalTable: "ContestProblems",
                principalColumns: new[] { "ContestID", "ProblemID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Contests_ContestSubmissions_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Contests",
                columns: new[] { "ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID" },
                principalTable: "ContestSubmissions",
                principalColumns: new[] { "ContestID", "ProblemID", "ContestantID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Contests_Participants_ParticipantsContestID_ParticipantsContestantID",
                table: "Contests",
                columns: new[] { "ParticipantsContestID", "ParticipantsContestantID" },
                principalTable: "Participants",
                principalColumns: new[] { "ContestID", "ContestantID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_ContestJudges_ContestJudgesContestID_ContestJudgesMentorID",
                table: "Mentors",
                columns: new[] { "ContestJudgesContestID", "ContestJudgesMentorID" },
                principalTable: "ContestJudges",
                principalColumns: new[] { "ContestID", "MentorID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_Mentorships_MentorshipMentorID_MentorshipContestantID",
                table: "Mentors",
                columns: new[] { "MentorshipMentorID", "MentorshipContestantID" },
                principalTable: "Mentorships",
                principalColumns: new[] { "MentorID", "ContestantID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Mentors_ProblemAuthors_ProblemAuthorsProblemID_ProblemAuthorsMentorID",
                table: "Mentors",
                columns: new[] { "ProblemAuthorsProblemID", "ProblemAuthorsMentorID" },
                principalTable: "ProblemAuthors",
                principalColumns: new[] { "ProblemID", "MentorID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_ContestProblems_ContestProblemsContestID_ContestProblemsProblemID",
                table: "Problems",
                columns: new[] { "ContestProblemsContestID", "ContestProblemsProblemID" },
                principalTable: "ContestProblems",
                principalColumns: new[] { "ContestID", "ProblemID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_ContestSubmissions_ContestSubmissionsContestID_ContestSubmissionsProblemID_ContestSubmissionsContestantID",
                table: "Problems",
                columns: new[] { "ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID" },
                principalTable: "ContestSubmissions",
                principalColumns: new[] { "ContestID", "ProblemID", "ContestantID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_ProblemAreas_ProblemAreasProblemID_ProblemAreasAreaID",
                table: "Problems",
                columns: new[] { "ProblemAreasProblemID", "ProblemAreasAreaID" },
                principalTable: "ProblemAreas",
                principalColumns: new[] { "ProblemID", "AreaID" });

            migrationBuilder.AddForeignKey(
                name: "FK_Problems_ProblemAuthors_ProblemAuthorsProblemID_ProblemAuthorsMentorID",
                table: "Problems",
                columns: new[] { "ProblemAuthorsProblemID", "ProblemAuthorsMentorID" },
                principalTable: "ProblemAuthors",
                principalColumns: new[] { "ProblemID", "MentorID" });
        }
    }
}
