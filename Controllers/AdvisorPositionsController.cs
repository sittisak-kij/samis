using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using samis.Data;
using samis.Models;

namespace samis.Controllers
{
    public class AdvisorPositionsController : Controller
    {
        private readonly SamisDbContext _context;

        public AdvisorPositionsController(SamisDbContext context)
        {
            _context = context;
        }

        // GET: AdvisorPositions
        public async Task<IActionResult> Index()
        {
            return View(await _context.AdvisorPositions.ToListAsync());
        }

        // GET: AdvisorPositions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisorPosition = await _context.AdvisorPositions
                .FirstOrDefaultAsync(m => m.advisorPositionId == id);
            if (advisorPosition == null)
            {
                return NotFound();
            }

            return View(advisorPosition);
        }

        // GET: AdvisorPositions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdvisorPositions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("advisorPositionId,advisorPositionName")] AdvisorPosition advisorPosition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advisorPosition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(advisorPosition);
        }

        // GET: AdvisorPositions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisorPosition = await _context.AdvisorPositions.FindAsync(id);
            if (advisorPosition == null)
            {
                return NotFound();
            }
            return View(advisorPosition);
        }

        // POST: AdvisorPositions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("advisorPositionId,advisorPositionName")] AdvisorPosition advisorPosition)
        {
            if (id != advisorPosition.advisorPositionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advisorPosition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvisorPositionExists(advisorPosition.advisorPositionId))
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
            return View(advisorPosition);
        }

        // GET: AdvisorPositions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisorPosition = await _context.AdvisorPositions
                .FirstOrDefaultAsync(m => m.advisorPositionId == id);
            if (advisorPosition == null)
            {
                return NotFound();
            }

            return View(advisorPosition);
        }

        // POST: AdvisorPositions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advisorPosition = await _context.AdvisorPositions.FindAsync(id);
            _context.AdvisorPositions.Remove(advisorPosition);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvisorPositionExists(int id)
        {
            return _context.AdvisorPositions.Any(e => e.advisorPositionId == id);
        }
    }
}
