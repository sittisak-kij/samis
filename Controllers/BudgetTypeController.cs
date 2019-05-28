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
    public class BudgetTypeController : Controller
    {
        private readonly SamisDbContext _context;

        public BudgetTypeController(SamisDbContext context)
        {
            _context = context;
        }

        // GET: BudgetType
        public async Task<IActionResult> Index()
        {
            return View(await _context.BudgetTypes.ToListAsync());
        }

        // GET: BudgetType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetType = await _context.BudgetTypes
                .FirstOrDefaultAsync(m => m.budgetTypeId == id);
            if (budgetType == null)
            {
                return NotFound();
            }

            return View(budgetType);
        }

        // GET: BudgetType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BudgetType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("budgetTypeId,budgetTypeName")] BudgetType budgetType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(budgetType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(budgetType);
        }

        // GET: BudgetType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetType = await _context.BudgetTypes.FindAsync(id);
            if (budgetType == null)
            {
                return NotFound();
            }
            return View(budgetType);
        }

        // POST: BudgetType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("budgetTypeId,budgetTypeName")] BudgetType budgetType)
        {
            if (id != budgetType.budgetTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(budgetType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BudgetTypeExists(budgetType.budgetTypeId))
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
            return View(budgetType);
        }

        // GET: BudgetType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var budgetType = await _context.BudgetTypes
                .FirstOrDefaultAsync(m => m.budgetTypeId == id);
            if (budgetType == null)
            {
                return NotFound();
            }

            return View(budgetType);
        }

        // POST: BudgetType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var budgetType = await _context.BudgetTypes.FindAsync(id);
            _context.BudgetTypes.Remove(budgetType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BudgetTypeExists(int id)
        {
            return _context.BudgetTypes.Any(e => e.budgetTypeId == id);
        }
    }
}
