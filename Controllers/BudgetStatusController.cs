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
    public class BudgetStatusController : Controller
    {
        private readonly SamisDbContext _context;

        public BudgetStatusController(SamisDbContext context)
        {
            _context = context;
        }

        // GET: BudgetStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.BudgetStatus.ToListAsync());
        }

        // GET: BudgetStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetStatus = await _context.BudgetStatus
                .FirstOrDefaultAsync(m => m.budgetStatusId == id);
            if (budgetStatus == null)
            {
                return NotFound();
            }

            return View(budgetStatus);
        }

        // GET: BudgetStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BudgetStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("budgetStatusId,name")] BudgetStatus budgetStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budgetStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(budgetStatus);
        }

        // GET: BudgetStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetStatus = await _context.BudgetStatus.FindAsync(id);
            if (budgetStatus == null)
            {
                return NotFound();
            }
            return View(budgetStatus);
        }

        // POST: BudgetStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("budgetStatusId,name")] BudgetStatus budgetStatus)
        {
            if (id != budgetStatus.budgetStatusId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budgetStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetStatusExists(budgetStatus.budgetStatusId))
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
            return View(budgetStatus);
        }

        // GET: BudgetStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetStatus = await _context.BudgetStatus
                .FirstOrDefaultAsync(m => m.budgetStatusId == id);
            if (budgetStatus == null)
            {
                return NotFound();
            }

            return View(budgetStatus);
        }

        // POST: BudgetStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budgetStatus = await _context.BudgetStatus.FindAsync(id);
            _context.BudgetStatus.Remove(budgetStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetStatusExists(int id)
        {
            return _context.BudgetStatus.Any(e => e.budgetStatusId == id);
        }
    }
}
