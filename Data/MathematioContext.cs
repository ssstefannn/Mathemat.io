using Mathemat.io.Models;
using Mathematio.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mathemat.io.Data
{
    public class MathematioContext : IdentityDbContext<MathematioUser>
    {
        public MathematioContext(DbContextOptions<MathematioContext> options) : base(options)
        {

        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Contestant> Contestants { get; set; }
        public DbSet<ContestJudges> ContestJudges { get; set; }
        public DbSet<ContestProblems> ContestProblems { get; set; }
        public DbSet<ContestSubmissions> ContestSubmissions { get; set; }
        public DbSet<Mentor> Mentors { get; set; }
        public DbSet<Mentorship> Mentorships { get; set; }
        public DbSet<Participants> Participants { get; set; }
        public DbSet<Problem> Problems { get; set; }
        public DbSet<ProblemAreas> ProblemAreas { get; set; }
        public DbSet<ProblemAuthors> ProblemAuthors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProblemAreas>().HasKey(c => new { c.ProblemID, c.AreaID });
            modelBuilder.Entity<ProblemAuthors>().HasKey(c => new { c.ProblemID, c.MentorID });
            modelBuilder.Entity<ContestJudges>().HasKey(c => new { c.ContestID, c.MentorID });
            modelBuilder.Entity<Mentorship>().HasKey(c => new { c.MentorID, c.ContestantID });
            modelBuilder.Entity<Participants>().HasKey(c => new { c.ContestID, c.ContestantID });
            modelBuilder.Entity<ContestProblems>().HasKey(c => new { c.ContestID, c.ProblemID });
            modelBuilder.Entity<ContestSubmissions>().HasKey(c => new { c.ContestID, c.ProblemID, c.ContestantID });

            base.OnModelCreating(modelBuilder);
        }
    }
}
