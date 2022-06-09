﻿// <auto-generated />
using System;
using Mathemat.io.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Mathematio.Migrations
{
    [DbContext(typeof(MathematioContext))]
    [Migration("20220604180201_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AreaProblem", b =>
                {
                    b.Property<int>("AreasAreaID")
                        .HasColumnType("int");

                    b.Property<int>("ProblemsProblemId")
                        .HasColumnType("int");

                    b.HasKey("AreasAreaID", "ProblemsProblemId");

                    b.HasIndex("ProblemsProblemId");

                    b.ToTable("AreaProblem");
                });

            modelBuilder.Entity("ContestantMentor", b =>
                {
                    b.Property<int>("ContestantsContestantID")
                        .HasColumnType("int");

                    b.Property<int>("MentorsMentorID")
                        .HasColumnType("int");

                    b.HasKey("ContestantsContestantID", "MentorsMentorID");

                    b.HasIndex("MentorsMentorID");

                    b.ToTable("ContestantMentor");
                });

            modelBuilder.Entity("ContestContestant", b =>
                {
                    b.Property<int>("ContestsContestID")
                        .HasColumnType("int");

                    b.Property<int>("ParticipantsContestantID")
                        .HasColumnType("int");

                    b.HasKey("ContestsContestID", "ParticipantsContestantID");

                    b.HasIndex("ParticipantsContestantID");

                    b.ToTable("ContestContestant");
                });

            modelBuilder.Entity("ContestMentor", b =>
                {
                    b.Property<int>("ContestsContestID")
                        .HasColumnType("int");

                    b.Property<int>("JudgesMentorID")
                        .HasColumnType("int");

                    b.HasKey("ContestsContestID", "JudgesMentorID");

                    b.HasIndex("JudgesMentorID");

                    b.ToTable("ContestMentor");
                });

            modelBuilder.Entity("Mathemat.io.Models.Area", b =>
                {
                    b.Property<int>("AreaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AreaID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("ProblemAreasAreaID")
                        .HasColumnType("int");

                    b.Property<int?>("ProblemAreasProblemID")
                        .HasColumnType("int");

                    b.HasKey("AreaID");

                    b.HasIndex("ProblemAreasProblemID", "ProblemAreasAreaID");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("Mathemat.io.Models.Contest", b =>
                {
                    b.Property<int>("ContestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContestID"), 1L, 1);

                    b.Property<int?>("ContestJudgesContestID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestJudgesMentorID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestProblemsContestID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestProblemsProblemID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestSubmissionsContestID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestSubmissionsContestantID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestSubmissionsProblemID")
                        .HasColumnType("int");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("ParticipantsContestID")
                        .HasColumnType("int");

                    b.Property<int?>("ParticipantsContestantID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ContestID");

                    b.HasIndex("ContestJudgesContestID", "ContestJudgesMentorID");

                    b.HasIndex("ContestProblemsContestID", "ContestProblemsProblemID");

                    b.HasIndex("ParticipantsContestID", "ParticipantsContestantID");

                    b.HasIndex("ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID");

                    b.ToTable("Contests");
                });

            modelBuilder.Entity("Mathemat.io.Models.Contestant", b =>
                {
                    b.Property<int>("ContestantID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContestantID"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ContestSubmissionsContestID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestSubmissionsContestantID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestSubmissionsProblemID")
                        .HasColumnType("int");

                    b.Property<int>("ContestantPoints")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("MentorshipContestantID")
                        .HasColumnType("int");

                    b.Property<int?>("MentorshipMentorID")
                        .HasColumnType("int");

                    b.Property<int?>("ParticipantsContestID")
                        .HasColumnType("int");

                    b.Property<int?>("ParticipantsContestantID")
                        .HasColumnType("int");

                    b.Property<string>("School")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ContestantID");

                    b.HasIndex("MentorshipMentorID", "MentorshipContestantID");

                    b.HasIndex("ParticipantsContestID", "ParticipantsContestantID");

                    b.HasIndex("ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID");

                    b.ToTable("Contestants");
                });

            modelBuilder.Entity("Mathemat.io.Models.ContestJudges", b =>
                {
                    b.Property<int>("ContestID")
                        .HasColumnType("int");

                    b.Property<int>("MentorID")
                        .HasColumnType("int");

                    b.HasKey("ContestID", "MentorID");

                    b.ToTable("ContestJudges");
                });

            modelBuilder.Entity("Mathemat.io.Models.ContestProblems", b =>
                {
                    b.Property<int>("ContestID")
                        .HasColumnType("int");

                    b.Property<int>("ProblemID")
                        .HasColumnType("int");

                    b.HasKey("ContestID", "ProblemID");

                    b.ToTable("ContestProblems");
                });

            modelBuilder.Entity("Mathemat.io.Models.ContestSubmissions", b =>
                {
                    b.Property<int>("ContestID")
                        .HasColumnType("int");

                    b.Property<int>("ProblemID")
                        .HasColumnType("int");

                    b.Property<int>("ContestantID")
                        .HasColumnType("int");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.Property<string>("Solution")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContestID", "ProblemID", "ContestantID");

                    b.ToTable("ContestSubmissions");
                });

            modelBuilder.Entity("Mathemat.io.Models.Mentor", b =>
                {
                    b.Property<int>("MentorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MentorID"), 1L, 1);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ContestJudgesContestID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestJudgesMentorID")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("MentorPoints")
                        .HasColumnType("int");

                    b.Property<int?>("MentorshipContestantID")
                        .HasColumnType("int");

                    b.Property<int?>("MentorshipMentorID")
                        .HasColumnType("int");

                    b.Property<int?>("ProblemAuthorsMentorID")
                        .HasColumnType("int");

                    b.Property<int?>("ProblemAuthorsProblemID")
                        .HasColumnType("int");

                    b.Property<string>("Profession")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MentorID");

                    b.HasIndex("ContestJudgesContestID", "ContestJudgesMentorID");

                    b.HasIndex("MentorshipMentorID", "MentorshipContestantID");

                    b.HasIndex("ProblemAuthorsProblemID", "ProblemAuthorsMentorID");

                    b.ToTable("Mentors");
                });

            modelBuilder.Entity("Mathemat.io.Models.Mentorship", b =>
                {
                    b.Property<int>("MentorID")
                        .HasColumnType("int");

                    b.Property<int>("ContestantID")
                        .HasColumnType("int");

                    b.HasKey("MentorID", "ContestantID");

                    b.ToTable("Mentorships");
                });

            modelBuilder.Entity("Mathemat.io.Models.Participants", b =>
                {
                    b.Property<int>("ContestID")
                        .HasColumnType("int");

                    b.Property<int>("ContestantID")
                        .HasColumnType("int");

                    b.HasKey("ContestID", "ContestantID");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("Mathemat.io.Models.Problem", b =>
                {
                    b.Property<int>("ProblemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProblemId"), 1L, 1);

                    b.Property<int?>("ContestProblemsContestID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestProblemsProblemID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestSubmissionsContestID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestSubmissionsContestantID")
                        .HasColumnType("int");

                    b.Property<int?>("ContestSubmissionsProblemID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<int?>("ProblemAreasAreaID")
                        .HasColumnType("int");

                    b.Property<int?>("ProblemAreasProblemID")
                        .HasColumnType("int");

                    b.Property<int?>("ProblemAuthorsMentorID")
                        .HasColumnType("int");

                    b.Property<int?>("ProblemAuthorsProblemID")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ProblemId");

                    b.HasIndex("ContestProblemsContestID", "ContestProblemsProblemID");

                    b.HasIndex("ProblemAreasProblemID", "ProblemAreasAreaID");

                    b.HasIndex("ProblemAuthorsProblemID", "ProblemAuthorsMentorID");

                    b.HasIndex("ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID");

                    b.ToTable("Problems");
                });

            modelBuilder.Entity("Mathemat.io.Models.ProblemAreas", b =>
                {
                    b.Property<int>("ProblemID")
                        .HasColumnType("int");

                    b.Property<int>("AreaID")
                        .HasColumnType("int");

                    b.HasKey("ProblemID", "AreaID");

                    b.ToTable("ProblemAreas");
                });

            modelBuilder.Entity("Mathemat.io.Models.ProblemAuthors", b =>
                {
                    b.Property<int>("ProblemID")
                        .HasColumnType("int");

                    b.Property<int>("MentorID")
                        .HasColumnType("int");

                    b.HasKey("ProblemID", "MentorID");

                    b.ToTable("ProblemAuthors");
                });

            modelBuilder.Entity("MentorProblem", b =>
                {
                    b.Property<int>("AuthorsMentorID")
                        .HasColumnType("int");

                    b.Property<int>("ProblemsProblemId")
                        .HasColumnType("int");

                    b.HasKey("AuthorsMentorID", "ProblemsProblemId");

                    b.HasIndex("ProblemsProblemId");

                    b.ToTable("MentorProblem");
                });

            modelBuilder.Entity("AreaProblem", b =>
                {
                    b.HasOne("Mathemat.io.Models.Area", null)
                        .WithMany()
                        .HasForeignKey("AreasAreaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mathemat.io.Models.Problem", null)
                        .WithMany()
                        .HasForeignKey("ProblemsProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContestantMentor", b =>
                {
                    b.HasOne("Mathemat.io.Models.Contestant", null)
                        .WithMany()
                        .HasForeignKey("ContestantsContestantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mathemat.io.Models.Mentor", null)
                        .WithMany()
                        .HasForeignKey("MentorsMentorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContestContestant", b =>
                {
                    b.HasOne("Mathemat.io.Models.Contest", null)
                        .WithMany()
                        .HasForeignKey("ContestsContestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mathemat.io.Models.Contestant", null)
                        .WithMany()
                        .HasForeignKey("ParticipantsContestantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContestMentor", b =>
                {
                    b.HasOne("Mathemat.io.Models.Contest", null)
                        .WithMany()
                        .HasForeignKey("ContestsContestID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mathemat.io.Models.Mentor", null)
                        .WithMany()
                        .HasForeignKey("JudgesMentorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mathemat.io.Models.Area", b =>
                {
                    b.HasOne("Mathemat.io.Models.ProblemAreas", null)
                        .WithMany("Areas")
                        .HasForeignKey("ProblemAreasProblemID", "ProblemAreasAreaID");
                });

            modelBuilder.Entity("Mathemat.io.Models.Contest", b =>
                {
                    b.HasOne("Mathemat.io.Models.ContestJudges", null)
                        .WithMany("Contests")
                        .HasForeignKey("ContestJudgesContestID", "ContestJudgesMentorID");

                    b.HasOne("Mathemat.io.Models.ContestProblems", null)
                        .WithMany("Contests")
                        .HasForeignKey("ContestProblemsContestID", "ContestProblemsProblemID");

                    b.HasOne("Mathemat.io.Models.Participants", null)
                        .WithMany("Contests")
                        .HasForeignKey("ParticipantsContestID", "ParticipantsContestantID");

                    b.HasOne("Mathemat.io.Models.ContestSubmissions", null)
                        .WithMany("Contests")
                        .HasForeignKey("ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID");
                });

            modelBuilder.Entity("Mathemat.io.Models.Contestant", b =>
                {
                    b.HasOne("Mathemat.io.Models.Mentorship", null)
                        .WithMany("Contestants")
                        .HasForeignKey("MentorshipMentorID", "MentorshipContestantID");

                    b.HasOne("Mathemat.io.Models.Participants", null)
                        .WithMany("Contestants")
                        .HasForeignKey("ParticipantsContestID", "ParticipantsContestantID");

                    b.HasOne("Mathemat.io.Models.ContestSubmissions", null)
                        .WithMany("Contestants")
                        .HasForeignKey("ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID");
                });

            modelBuilder.Entity("Mathemat.io.Models.Mentor", b =>
                {
                    b.HasOne("Mathemat.io.Models.ContestJudges", null)
                        .WithMany("Judges")
                        .HasForeignKey("ContestJudgesContestID", "ContestJudgesMentorID");

                    b.HasOne("Mathemat.io.Models.Mentorship", null)
                        .WithMany("Mentors")
                        .HasForeignKey("MentorshipMentorID", "MentorshipContestantID");

                    b.HasOne("Mathemat.io.Models.ProblemAuthors", null)
                        .WithMany("Authors")
                        .HasForeignKey("ProblemAuthorsProblemID", "ProblemAuthorsMentorID");
                });

            modelBuilder.Entity("Mathemat.io.Models.Problem", b =>
                {
                    b.HasOne("Mathemat.io.Models.ContestProblems", null)
                        .WithMany("Problems")
                        .HasForeignKey("ContestProblemsContestID", "ContestProblemsProblemID");

                    b.HasOne("Mathemat.io.Models.ProblemAreas", null)
                        .WithMany("Problems")
                        .HasForeignKey("ProblemAreasProblemID", "ProblemAreasAreaID");

                    b.HasOne("Mathemat.io.Models.ProblemAuthors", null)
                        .WithMany("Problems")
                        .HasForeignKey("ProblemAuthorsProblemID", "ProblemAuthorsMentorID");

                    b.HasOne("Mathemat.io.Models.ContestSubmissions", null)
                        .WithMany("Problems")
                        .HasForeignKey("ContestSubmissionsContestID", "ContestSubmissionsProblemID", "ContestSubmissionsContestantID");
                });

            modelBuilder.Entity("MentorProblem", b =>
                {
                    b.HasOne("Mathemat.io.Models.Mentor", null)
                        .WithMany()
                        .HasForeignKey("AuthorsMentorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Mathemat.io.Models.Problem", null)
                        .WithMany()
                        .HasForeignKey("ProblemsProblemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Mathemat.io.Models.ContestJudges", b =>
                {
                    b.Navigation("Contests");

                    b.Navigation("Judges");
                });

            modelBuilder.Entity("Mathemat.io.Models.ContestProblems", b =>
                {
                    b.Navigation("Contests");

                    b.Navigation("Problems");
                });

            modelBuilder.Entity("Mathemat.io.Models.ContestSubmissions", b =>
                {
                    b.Navigation("Contestants");

                    b.Navigation("Contests");

                    b.Navigation("Problems");
                });

            modelBuilder.Entity("Mathemat.io.Models.Mentorship", b =>
                {
                    b.Navigation("Contestants");

                    b.Navigation("Mentors");
                });

            modelBuilder.Entity("Mathemat.io.Models.Participants", b =>
                {
                    b.Navigation("Contestants");

                    b.Navigation("Contests");
                });

            modelBuilder.Entity("Mathemat.io.Models.ProblemAreas", b =>
                {
                    b.Navigation("Areas");

                    b.Navigation("Problems");
                });

            modelBuilder.Entity("Mathemat.io.Models.ProblemAuthors", b =>
                {
                    b.Navigation("Authors");

                    b.Navigation("Problems");
                });
#pragma warning restore 612, 618
        }
    }
}