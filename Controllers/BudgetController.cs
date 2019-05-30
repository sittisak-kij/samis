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
    public class BudgetController : Controller
    {
        private readonly SamisDbContext _context;

        public BudgetController(SamisDbContext context)
        {
            _context = context;
        }

        // GET: Budget
        public async Task<IActionResult> Index()
        {
            var samisDbContext = _context.Bugets.Include(b => b.activityInformation).Include(b => b.budgetDescription).Include(b => b.budgetStatus);
            return View(await samisDbContext.ToListAsync());
        }

        // GET: Budget/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _context.Bugets
                .Include(b => b.activityInformation)
                .Include(b => b.budgetDescription)
                .Include(b => b.budgetStatus)
                .FirstOrDefaultAsync(m => m.budgetId == id);
            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // GET: Budget/Create
        public IActionResult Create()
        {
            ViewData["activityId"] = new SelectList(_context.ActivityInformations, "activityId", "activityName");
            ViewData["budgetDescriptionId"] = new SelectList(_context.BudgetDescription, "budgetDescriptionId", "name");
            ViewData["budgetStatusId"] = new SelectList(_context.BudgetStatus, "budgetStatusId", "name");
            return View();
        }

        // POST: Budget/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("budgetId,activityId,budgetDescriptionId,budgetStatusId,amount")] Budget budget)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budget);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["activityId"] = new SelectList(_context.ActivityInformations, "activityId", "activityId", budget.activityId);
            ViewData["budgetDescriptionId"] = new SelectList(_context.BudgetDescription, "budgetDescriptionId", "budgetDescriptionId", budget.budgetDescriptionId);
            ViewData["budgetStatusId"] = new SelectList(_context.BudgetStatus, "budgetStatusId", "budgetStatusId", budget.budgetStatusId);
            return View(budget);
        }

        // GET: Budget/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _context.Bugets.FindAsync(id);
            if (budget == null)
            {
                return NotFound();
            }
            ViewData["activityId"] = new SelectList(_context.ActivityInformations, "activityId", "activityId", budget.activityId);
            ViewData["budgetDescriptionId"] = new SelectList(_context.BudgetDescription, "budgetDescriptionId", "budgetDescriptionId", budget.budgetDescriptionId);
            ViewData["budgetStatusId"] = new SelectList(_context.BudgetStatus, "budgetStatusId", "budgetStatusId", budget.budgetStatusId);
            return View(budget);
        }

        // POST: Budget/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("budgetId,activityId,budgetDescriptionId,budgetStatusId,amount")] Budget budget)
        {
            if (id != budget.budgetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budget);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetExists(budget.budgetId))
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
            ViewData["activityId"] = new SelectList(_context.ActivityInformations, "activityId", "activityId", budget.activityId);
            ViewData["budgetDescriptionId"] = new SelectList(_context.BudgetDescription, "budgetDescriptionId", "budgetDescriptionId", budget.budgetDescriptionId);
            ViewData["budgetStatusId"] = new SelectList(_context.BudgetStatus, "budgetStatusId", "budgetStatusId", budget.budgetStatusId);
            return View(budget);
        }

        // GET: Budget/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budget = await _context.Bugets
                .Include(b => b.activityInformation)
                .Include(b => b.budgetDescription)
                .Include(b => b.budgetStatus)
                .FirstOrDefaultAsync(m => m.budgetId == id);
            if (budget == null)
            {
                return NotFound();
            }

            return View(budget);
        }

        // POST: Budget/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budget = await _context.Bugets.FindAsync(id);
            _context.Bugets.Remove(budget);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetExists(int id)
        {
            return _context.Bugets.Any(e => e.budgetId == id);
        }
    }
}
