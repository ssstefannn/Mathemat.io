using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mathemat.io.Data;
using Mathemat.io.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Mathematio.Areas.Identity.Data;

namespace Mathematio.Controllers
{
    public class ContestsController : Controller
    {
        private readonly MathematioContext _context;
        public IServiceProvider _serviceProvider;

        public ContestsController(MathematioContext context,IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        // GET: Contests
        public async Task<IActionResult> Index(string? title,int? difficulty,int? status)
        {
            var contests = _context.Contests.ToList();
            contests = contests.Select(c =>
            {
                DateTime sd = c.StartDate;
                if (DateTime.Now.CompareTo(sd) > 0 && DateTime.Now.CompareTo(sd.AddMinutes(c.Duration)) < 0)
                {
                    c.Status = Contest.StatusLevel.InProgress;
                }
                if (DateTime.Now.CompareTo(sd.AddMinutes(c.Duration)) > 0 && c.Status!=Contest.StatusLevel.ResultsOut)
                {
                    c.Status = Contest.StatusLevel.Finished;
                }
                _context.Contests.Update(c);
                _context.SaveChanges();
                return c;
            }).ToList();
            var contestFilter = _context.Contests.AsQueryable();
            if (!string.IsNullOrEmpty(title))
            {
                contestFilter = contestFilter.Where(c => c.Title.Contains(title));
            }
            if(difficulty != null)
            {
                contestFilter = contestFilter.Where(c => (int)c.Difficulty == difficulty);
            }
            if(status != null)
            {
                contestFilter = contestFilter.Where(c => (int)c.Status == status);
            }
            return View(await contestFilter.ToListAsync());
        }

        // GET: Contests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contests == null)
            {
                return NotFound();
            }

            var contest = await _context.Contests
                .FirstOrDefaultAsync(m => m.ContestID == id);
            if (contest == null)
            {
                return NotFound();
            }

            return View(contest);
        }

        // GET: Contests/Create
        [Authorize(Roles = "Admin,Mentor")]
        public IActionResult Create()
        {
            //var userService = _serviceProvider.GetRequiredService<UserManager<MathematioUser>>();
            //var user = userService.GetUserAsync(HttpContext.User);
            ViewBag.Judges = new SelectList(_context.Set<Mentor>(), "MentorID", "FirstName");
            ViewBag.Problems = new SelectList(_context.Set<Problem>(), "ProblemId", "Title");
            ViewBag.Participants = new SelectList(_context.Set<Contestant>(), "ContestantID", "FirstName");
            return View();
        }

        // POST: Contests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Mentor")]
        public async Task<IActionResult> Create([Bind("ContestID,Title,Difficulty,StartDate,Status,Duration,JudgeIDs,ProblemIDs,ParticipantIDs")] Contest contest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contest);
                await _context.SaveChangesAsync();
                foreach (var JudgeID in contest.JudgeIDs)
                {
                    ContestJudges contestJudges = new ContestJudges();
                    contestJudges.MentorID = JudgeID;
                    contestJudges.ContestID = contest.ContestID;
                    await _context.AddAsync<ContestJudges>(contestJudges);
                }
                foreach (var ProblemID in contest.ProblemIDs)
                {
                    ContestProblems contestProblems = new ContestProblems();
                    contestProblems.ContestID = contest.ContestID;
                    contestProblems.ProblemID = ProblemID;
                    await _context.AddAsync<ContestProblems>(contestProblems);
                }
                foreach (var ParticipantID in contest.ParticipantIDs)
                {
                    Participants participant = new Participants();
                    participant.ContestID = contest.ContestID;
                    participant.ContestantID = ParticipantID;
                    await _context.AddAsync<Participants>(participant);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contest);
        }

        // GET: Contests/Edit/5
        [Authorize(Roles = "Admin,Mentor")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contests == null)
            {
                return NotFound();
            }

            var contest = await _context.Contests.FindAsync(id);
            if (contest == null)
            {
                return NotFound();
            }
            return View(contest);
        }

        // POST: Contests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Mentor")]
        public async Task<IActionResult> Edit(int id, [Bind("ContestID,Title,Difficulty,StartDate,Status,Duration")] Contest contest)
        {
            if (id != contest.ContestID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContestExists(contest.ContestID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contest);
        }

        // GET: Contests/Delete/5
        [Authorize(Roles = "Admin,Mentor")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contests == null)
            {
                return NotFound();
            }

            var contest = await _context.Contests
                .FirstOrDefaultAsync(m => m.ContestID == id);
            if (contest == null)
            {
                return NotFound();
            }

            return View(contest);
        }

        // POST: Contests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin,Mentor")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contests == null)
            {
                return Problem("Entity set 'MathematioContext.Contests'  is null.");
            }
            var contest = await _context.Contests.FindAsync(id);
            if (contest != null)
            {
                _context.Contests.Remove(contest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContestExists(int id)
        {
            return (_context.Contests?.Any(e => e.ContestID == id)).GetValueOrDefault();
        }


        public async Task<IActionResult> Start(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userManager = _serviceProvider.GetRequiredService<UserManager<MathematioUser>>();
            var userID = userManager.FindByNameAsync(User.Identity.Name).Result.LinkId;
            if(!_context.Participants.Any(p=>p.ContestID==id && p.ContestantID == userID))
            {
                return NotFound();
            }
            var contest = _context.Contests.Find(id);
            if(contest.Status != Contest.StatusLevel.InProgress)
            {
                return NotFound();
            }
            ViewBag.Contest = _context.Contests.Find(id);
            var problems = await _context.ContestProblems.Where(cp => cp.ContestID == id).Select(cp => cp.Problem).ToListAsync<Problem>();
            return View(problems);

        }

        [Route("Contests/Submit/{id:int}/{problemId:int}")]
        public async Task<IActionResult> Submit(int? id, int? problemId)
        {
            if (id == null || problemId == null)
            {
                return NotFound();
            }

            ContestSubmissions submission = new ContestSubmissions();
            submission.ProblemID = (int)problemId;
            submission.ContestID = (int)id;

            return View(submission);
        }

        [HttpPost]
        [Route("Contests/SubmitConfirmed/{id:int}/{problemId:int}")]
        public async Task<IActionResult> SubmitConfirmed(int? id, int? problemId, [Bind("ContestID", "ProblemID", "ContestantID", "Solution", "SolutionFile")] ContestSubmissions submission)
        {
            if (submission.SolutionFile != null)
            {
                string uniqueFileName = UploadedFile(submission);
                submission.Solution = uniqueFileName;
            }
            var userManager = _serviceProvider.GetRequiredService<UserManager<MathematioUser>>();
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            submission.ContestantID = user.LinkId;
            await _context.ContestSubmissions.AddAsync(submission);
            await _context.SaveChangesAsync();

            var uri = "Contests";
            return RedirectToRoute(new { controller = "Contests", action = "Start", id=submission.ContestID });

        }

        private string UploadedFile(ContestSubmissions submission)
        {
            string uniqueFileName = null;

            if (submission.SolutionFile != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/profilePictures");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }
                uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(submission.SolutionFile.FileName);
                string fileNameWithPath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
                {
                    submission.SolutionFile.CopyTo(stream);
                }
            }
            return uniqueFileName;
        }

        [Authorize(Roles = "Admin,Mentor")]
        public async Task<IActionResult> Submissions(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userManager = _serviceProvider.GetRequiredService<UserManager<MathematioUser>>();
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var userID = user.LinkId;
            if (!_context.ContestJudges.Any(cj => cj.ContestID == id && cj.MentorID == userID))
            {
                return NotFound();
            }

            var submissions = await _context.ContestSubmissions.Where(cs => cs.ContestID == id).Include(cs => cs.Contest).Include(cs => cs.Problem).Include(cs => cs.Contestant).ToListAsync();

            return View(submissions);
        }

        [Authorize(Roles = "Admin,Mentor")]
        public async Task<IActionResult> SubmissionsEdit(int? contestID, int? problemID, int? contestantID)
        {
            if (contestID == null || problemID == null || contestantID == null)
            {
                return NotFound();
            }
            return View(await _context.ContestSubmissions.Where(cs => cs.ContestID == contestID && cs.ProblemID == problemID && cs.ContestantID == contestantID).FirstAsync());
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Mentor")]
        public async Task<IActionResult> SubmissionsEdit([Bind("ContestID","ProblemID","ContestantID","Solution","Points","Contest","Problem","Contestant")] ContestSubmissions cs)
        {
            if (ModelState.IsValid)
            {
                var contestant = _context.Contestants.Where(c => c.ContestantID == cs.ContestantID).FirstOrDefault();
                _context.ContestSubmissions.Update(cs);
                contestant.ContestantPoints += cs.Points;
                _context.Contestants.Update(contestant);
                await _context.SaveChangesAsync();
                return RedirectToRoute(new { controller = "Contests", action = "Submissions", id=cs.ContestID });
            }

            return NotFound();
        }

        public async Task<IActionResult> Results(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var contest = _context.Contests.Find(id);
            if (contest.Status != Contest.StatusLevel.ResultsOut)
            {
                return NotFound();
            }
            var results = _context.ContestSubmissions.Where(cs => cs.ContestID == id).ToList().GroupBy(li => li.ContestantID).Select(ge => new ContestSubmissions
            {
                ContestID = (int)id,
                ProblemID = 0,
                ContestantID = ge.Key,
                Contestant = _context.Contestants.Where(c=>c.ContestantID == ge.Key).First(),
                Points = ge.Select(submission => submission.Points).Sum()
            }).OrderBy(cs => -1*cs.Points); 
            return View(results);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,Mentor")]
        public async Task<IActionResult> ResultsOut(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var contest = _context.Contests.Find(id);
            contest.Status = Contest.StatusLevel.ResultsOut;
            _context.Contests.Update(contest);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
