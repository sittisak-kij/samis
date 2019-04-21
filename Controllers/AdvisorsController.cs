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
    public class AdvisorsController : Controller
    {
        private readonly SamisDbContext _context;

        public AdvisorsController(SamisDbContext context)
        {
            _context = context;
        }

        // GET: Advisors
        public async Task<IActionResult> Index()
        {
            var samisDbContext = _context.Advisors.Include(a => a.advisorPosition);
            return View(await samisDbContext.ToListAsync());
        }

        // GET: Advisors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisor = await _context.Advisors
                .Include(a => a.advisorPosition)
                .FirstOrDefaultAsync(m => m.advisorId == id);
            if (advisor == null)
            {
                return NotFound();
            }

            return View(advisor);
        }

        // GET: Advisors/Create
        public IActionResult Create()
        {
            ViewData["advisorPositionId"] = new SelectList(_context.AdvisorPositions, "advisorPositionId", "advisorPositionId");
            return View();
        }

        // POST: Advisors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("advisorId,name,phoneNumber,lineID,email,advisorPositionId")] Advisor advisor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(advisor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["advisorPositionId"] = new SelectList(_context.AdvisorPositions, "advisorPositionId", "advisorPositionId", advisor.advisorPositionId);
            return View(advisor);
        }

        // GET: Advisors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisor = await _context.Advisors.FindAsync(id);
            if (advisor == null)
            {
                return NotFound();
            }
            ViewData["advisorPositionId"] = new SelectList(_context.AdvisorPositions, "advisorPositionId", "advisorPositionId", advisor.advisorPositionId);
            return View(advisor);
        }

        // POST: Advisors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("advisorId,name,phoneNumber,lineID,email,advisorPositionId")] Advisor advisor)
        {
            if (id != advisor.advisorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(advisor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdvisorExists(advisor.advisorId))
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
            ViewData["advisorPositionId"] = new SelectList(_context.AdvisorPositions, "advisorPositionId", "advisorPositionId", advisor.advisorPositionId);
            return View(advisor);
        }

        // GET: Advisors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var advisor = await _context.Advisors
                .Include(a => a.advisorPosition)
                .FirstOrDefaultAsync(m => m.advisorId == id);
            if (advisor == null)
            {
                return NotFound();
            }

            return View(advisor);
        }

        // POST: Advisors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var advisor = await _context.Advisors.FindAsync(id);
            _context.Advisors.Remove(advisor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdvisorExists(int id)
        {
            return _context.Advisors.Any(e => e.advisorId == id);
        }
    }
}
