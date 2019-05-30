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
    public class BudgetDescriptionController : Controller
    {
        private readonly SamisDbContext _context;

        public BudgetDescriptionController(SamisDbContext context)
        {
            _context = context;
        }

        // GET: BudgetDescription
        public async Task<IActionResult> Index()
        {
            var samisDbContext = _context.BudgetDescription.Include(b => b.budgetType);
            return View(await samisDbContext.ToListAsync());
        }

        // GET: BudgetDescription/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetDescription = await _context.BudgetDescription
                .Include(b => b.budgetType)
                .FirstOrDefaultAsync(m => m.budgetDescriptionId == id);
            if (budgetDescription == null)
            {
                return NotFound();
            }

            return View(budgetDescription);
        }

        // GET: BudgetDescription/Create
        public IActionResult Create()
        {
            ViewData["budgetTypeId"] = new SelectList(_context.BudgetTypes, "budgetTypeId", "budgetTypeName");
            return View();
        }

        // POST: BudgetDescription/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("budgetDescriptionId,name,budgetTypeId")] BudgetDescription budgetDescription)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budgetDescription);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["budgetTypeId"] = new SelectList(_context.BudgetTypes, "budgetTypeId", "budgetTypeId", budgetDescription.budgetTypeId);
            return View(budgetDescription);
        }

        // GET: BudgetDescription/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetDescription = await _context.BudgetDescription.FindAsync(id);
            if (budgetDescription == null)
            {
                return NotFound();
            }
            ViewData["budgetTypeId"] = new SelectList(_context.BudgetTypes, "budgetTypeId", "budgetTypeId", budgetDescription.budgetTypeId);
            return View(budgetDescription);
        }

        // POST: BudgetDescription/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("budgetDescriptionId,name,budgetTypeId")] BudgetDescription budgetDescription)
        {
            if (id != budgetDescription.budgetDescriptionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budgetDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetDescriptionExists(budgetDescription.budgetDescriptionId))
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
            ViewData["budgetTypeId"] = new SelectList(_context.BudgetTypes, "budgetTypeId", "budgetTypeId", budgetDescription.budgetTypeId);
            return View(budgetDescription);
        }

        // GET: BudgetDescription/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetDescription = await _context.BudgetDescription
                .Include(b => b.budgetType)
                .FirstOrDefaultAsync(m => m.budgetDescriptionId == id);
            if (budgetDescription == null)
            {
                return NotFound();
            }

            return View(budgetDescription);
        }

        // POST: BudgetDescription/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budgetDescription = await _context.BudgetDescription.FindAsync(id);
            _context.BudgetDescription.Remove(budgetDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetDescriptionExists(int id)
        {
            return _context.BudgetDescription.Any(e => e.budgetDescriptionId == id);
        }
    }
}
