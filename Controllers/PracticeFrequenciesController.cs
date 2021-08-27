using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MusicDating.Data;
using MusicDating.Models.Entities;

namespace MusicDating.Controllers
{
    public class PracticeFrequenciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PracticeFrequenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PracticeFrequencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.PracticeFrequencies.ToListAsync());
        }

        // GET: PracticeFrequencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practiceFrequency = await _context.PracticeFrequencies
                .FirstOrDefaultAsync(m => m.PracticeFrequencyId == id);
            if (practiceFrequency == null)
            {
                return NotFound();
            }

            return View(practiceFrequency);
        }

        // GET: PracticeFrequencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PracticeFrequencies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PracticeFrequencyId,Description")] PracticeFrequency practiceFrequency)
        {
            if (ModelState.IsValid)
            {
                _context.Add(practiceFrequency);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(practiceFrequency);
        }

        // GET: PracticeFrequencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practiceFrequency = await _context.PracticeFrequencies.FindAsync(id);
            if (practiceFrequency == null)
            {
                return NotFound();
            }
            return View(practiceFrequency);
        }

        // POST: PracticeFrequencies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PracticeFrequencyId,Description")] PracticeFrequency practiceFrequency)
        {
            if (id != practiceFrequency.PracticeFrequencyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(practiceFrequency);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PracticeFrequencyExists(practiceFrequency.PracticeFrequencyId))
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
            return View(practiceFrequency);
        }

        // GET: PracticeFrequencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var practiceFrequency = await _context.PracticeFrequencies
                .FirstOrDefaultAsync(m => m.PracticeFrequencyId == id);
            if (practiceFrequency == null)
            {
                return NotFound();
            }

            return View(practiceFrequency);
        }

        // POST: PracticeFrequencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var practiceFrequency = await _context.PracticeFrequencies.FindAsync(id);
            _context.PracticeFrequencies.Remove(practiceFrequency);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PracticeFrequencyExists(int id)
        {
            return _context.PracticeFrequencies.Any(e => e.PracticeFrequencyId == id);
        }
    }
}
