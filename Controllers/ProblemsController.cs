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
    public class ProblemsController : Controller
    {
        private readonly MathematioContext _context;

        public enum DifficultyLevel
        {
            Easy,
            Medium,
            Hard
        }

        public ProblemsController(MathematioContext context)
        {
            _context = context;
        }

        // GET: Problems
        public async Task<IActionResult> Index(string? title,int? difficulty,string? areaName)
        {
            var filteredProblems = _context.Problems.AsQueryable();
            if(title != null)
            {
                filteredProblems = filteredProblems.Where(p => p.Title.Contains(title));
            }
            if(difficulty != null)
            {
                filteredProblems = filteredProblems.Where(p => (int)p.Difficulty == difficulty);
            }
            if(areaName != null)
            {
                int areaID = _context.Areas.First(a => a.Name.Equals(areaName)).AreaID;
                var problemAreas = _context.ProblemAreas.Where(pa => pa.AreaID == areaID);
                filteredProblems = problemAreas.Join<ProblemAreas,Problem,int,Problem>(filteredProblems, pa => pa.ProblemID, p => p.ProblemId,(pa,p)=>p);
            }
              return _context.Problems != null ? 
                          View(await filteredProblems.ToListAsync()) :
                          Problem("Entity set 'MathematioContext.Problems'  is null.");
        }

        // GET: Problems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Problems == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems
                .FirstOrDefaultAsync(m => m.ProblemId == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }

        // GET: Problems/Create
        public IActionResult Create()
        {
            ViewBag.Areas = new SelectList(_context.Set<Area>(), "AreaID", "Name");
            ViewBag.Authors = new SelectList(_context.Set<Mentor>(), "MentorID", "FirstName");
            return View();
        }

        // POST: Problems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProblemId,Title,Difficulty,Description,DateAdded,AreaIDs,AuthorIDs")] Problem problem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(problem);
                _context.SaveChanges();
                foreach(var AreaID in problem.AreaIDs)
                {
                    ProblemAreas problemAreas = new ProblemAreas();
                    problemAreas.ProblemID = problem.ProblemId;
                    problemAreas.AreaID = AreaID;
                    await _context.ProblemAreas.AddAsync(problemAreas);
                }
                await _context.SaveChangesAsync();
                foreach (var AuthorID in problem.AuthorIDs)
                {
                    ProblemAuthors problemAuthors = new ProblemAuthors();
                    problemAuthors.ProblemID = problem.ProblemId;
                    problemAuthors.MentorID = AuthorID;
                    await _context.ProblemAuthors.AddAsync(problemAuthors);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(problem);
        }

        // GET: Problems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Problems == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems.FindAsync(id);
            if (problem == null)
            {
                return NotFound();
            }
            return View(problem);
        }

        // POST: Problems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProblemId,Title,Difficulty,Description,DateAdded")] Problem problem)
        {
            if (id != problem.ProblemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(problem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProblemExists(problem.ProblemId))
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
            return View(problem);
        }

        // GET: Problems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Problems == null)
            {
                return NotFound();
            }

            var problem = await _context.Problems
                .FirstOrDefaultAsync(m => m.ProblemId == id);
            if (problem == null)
            {
                return NotFound();
            }

            return View(problem);
        }

        // POST: Problems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Problems == null)
            {
                return Problem("Entity set 'MathematioContext.Problems'  is null.");
            }
            var problem = await _context.Problems.FindAsync(id);
            if (problem != null)
            {
                _context.Problems.Remove(problem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProblemExists(int id)
        {
          return (_context.Problems?.Any(e => e.ProblemId == id)).GetValueOrDefault();
        }
    }
}
