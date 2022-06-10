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
    public class ContestantsController : Controller
    {
        private readonly MathematioContext _context;

        public ContestantsController(MathematioContext context)
        {
            _context = context;
        }

        // GET: Contestants
        public async Task<IActionResult> Index(string? fn,string? ln,string? country)
        {
            var contestantFilter = _context.Contestants.AsQueryable();
            if (!string.IsNullOrEmpty(fn))
            {
                contestantFilter = contestantFilter.Where(c => c.FirstName.Contains(fn));
            }
            if (!string.IsNullOrEmpty(ln))
            {
                contestantFilter = contestantFilter.Where(c => c.LastName.Contains(ln));
            }
            if (!string.IsNullOrEmpty(country))
            {
                contestantFilter = contestantFilter.Where(c => c.Country.Equals(country));
            }
            return View(await contestantFilter.ToListAsync());
        }

        // GET: Contestants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contestants == null)
            {
                return NotFound();
            }

            var contestant = await _context.Contestants
                .FirstOrDefaultAsync(m => m.ContestantID == id);
            if (contestant == null)
            {
                return NotFound();
            }

            return View(contestant);
        }

        // GET: Contestants/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contestants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ContestantID,FirstName,LastName,Country,BirthDate,School,ContestantPoints")] Contestant contestant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contestant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contestant);
        }

        // GET: Contestants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contestants == null)
            {
                return NotFound();
            }

            var contestant = await _context.Contestants.FindAsync(id);
            if (contestant == null)
            {
                return NotFound();
            }
            return View(contestant);
        }

        // POST: Contestants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ContestantID,FirstName,LastName,Country,BirthDate,School,ContestantPoints")] Contestant contestant)
        {
            if (id != contestant.ContestantID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contestant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContestantExists(contestant.ContestantID))
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
            return View(contestant);
        }

        // GET: Contestants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contestants == null)
            {
                return NotFound();
            }

            var contestant = await _context.Contestants
                .FirstOrDefaultAsync(m => m.ContestantID == id);
            if (contestant == null)
            {
                return NotFound();
            }

            return View(contestant);
        }

        // POST: Contestants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contestants == null)
            {
                return Problem("Entity set 'MathematioContext.Contestants'  is null.");
            }
            var contestant = await _context.Contestants.FindAsync(id);
            if (contestant != null)
            {
                _context.Contestants.Remove(contestant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContestantExists(int id)
        {
          return (_context.Contestants?.Any(e => e.ContestantID == id)).GetValueOrDefault();
        }
    }
}
