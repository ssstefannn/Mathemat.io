using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mathemat.io.Data;
using Mathemat.io.Models;
using Microsoft.AspNetCore.Identity;
using Mathematio.Areas.Identity.Data;

namespace Mathematio.Controllers
{
    public class MentorsController : Controller
    {
        private readonly MathematioContext _context;
        public IServiceProvider _serviceProvider;

        public MentorsController(MathematioContext context, IServiceProvider serviceProvider)
        {
            _context = context;
            _serviceProvider = serviceProvider;
        }

        // GET: Mentors
        public async Task<IActionResult> Index(string? fn, string? ln, string? country)
        {
            var mentorFilter = _context.Mentors.AsQueryable();
            if (!string.IsNullOrEmpty(fn))
            {
                mentorFilter = mentorFilter.Where(c => c.FirstName.Contains(fn));
            }
            if (!string.IsNullOrEmpty(ln))
            {
                mentorFilter = mentorFilter.Where(c => c.LastName.Contains(ln));
            }
            if (!string.IsNullOrEmpty(country))
            {
                mentorFilter = mentorFilter.Where(c => c.Country.Equals(country));
            }
            ViewBag.CountryList = new SelectList(_context.Mentors.GroupBy(c => c.Country).Select(g => g.Key));
            return View(await mentorFilter.ToListAsync());
        }

        // GET: Mentors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Mentors == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentors
                .FirstOrDefaultAsync(m => m.MentorID == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }

        // GET: Mentors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Mentors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MentorID,FirstName,LastName,Country,BirthDate,Profession,MentorPoints")] Mentor mentor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mentor);
                await _context.SaveChangesAsync();
                var UserManager = _serviceProvider.GetRequiredService<UserManager<MathematioUser>>();
                var User = new MathematioUser();
                User.Email = "mentor" + mentor.MentorID + "@mathemat.io";
                User.UserName = "mentor" + mentor.MentorID + "@mathemat.io";
                User.LinkId = mentor.MentorID;
                User.EmailConfirmed = true;
                string userPWD = "Mentor" + mentor.MentorID;
                IdentityResult chkUser = await UserManager.CreateAsync(User, userPWD);
                if (chkUser.Succeeded) { var result1 = await UserManager.AddToRoleAsync(User, "Mentor"); }

                return RedirectToAction(nameof(Index));
            }
            return View(mentor);
        }

        // GET: Mentors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Mentors == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentors.FindAsync(id);
            if (mentor == null)
            {
                return NotFound();
            }
            ViewBag.Contestants = new SelectList(_context.Set<Contestant>(), "ContestantID", "FirstName");
            return View(mentor);
        }

        // POST: Mentors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MentorID,FirstName,LastName,Country,BirthDate,Profession,MentorPoints,ContestantIDs")] Mentor mentor)
        {
            if (id != mentor.MentorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mentor);
                    await _context.SaveChangesAsync();
                    foreach(var ContestantID in mentor.ContestantIDs)
                    {
                        Mentorship mentorship = new Mentorship();
                        mentorship.MentorID = mentor.MentorID;
                        mentorship.ContestantID = ContestantID;
                        await _context.AddAsync<Mentorship>(mentorship);
                    }
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MentorExists(mentor.MentorID))
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
            return View(mentor);
        }

        // GET: Mentors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Mentors == null)
            {
                return NotFound();
            }

            var mentor = await _context.Mentors
                .FirstOrDefaultAsync(m => m.MentorID == id);
            if (mentor == null)
            {
                return NotFound();
            }

            return View(mentor);
        }

        // POST: Mentors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Mentors == null)
            {
                return Problem("Entity set 'MathematioContext.Mentors'  is null.");
            }
            var mentor = await _context.Mentors.FindAsync(id);
            if (mentor != null)
            {
                _context.Mentors.Remove(mentor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MentorExists(int id)
        {
          return (_context.Mentors?.Any(e => e.MentorID == id)).GetValueOrDefault();
        }
    }
}
