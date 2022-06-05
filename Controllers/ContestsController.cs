using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mathemat.io.Data;
using Mathemat.io.Models;

namespace Mathematio.Controllers
{
    public class ContestsController : Controller
    {
        private readonly MathematioContext _context;

        public ContestsController(MathematioContext context)
        {
            _context = context;
        }

        // GET: Contests
        public async Task<IActionResult> Index()
        {
            return _context.Contests != null ?
                        View(await _context.Contests.ToListAsync()) :
                        Problem("Entity set 'MathematioContext.Contests'  is null.");
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
        public IActionResult Create()
        {
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
        public async Task<IActionResult> SubmitConfirmed(int? id, int? problemId,[Bind("ContestID","ProblemID","ContestantID","Solution","SolutionFile")]ContestSubmissions submission)
        {
            if (submission.SolutionFile != null)
            {
                string uniqueFileName = UploadedFile(submission);
                submission.Solution = uniqueFileName;
            }
            submission.ContestantID = 1;
            await _context.ContestSubmissions.AddAsync(submission);
            await _context.SaveChangesAsync();

            var uri = "Contests";
            return RedirectToAction(nameof(Index));

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
    }
}
