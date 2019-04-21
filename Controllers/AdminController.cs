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
    public class AdminController : Controller
    {
        private readonly SamisDbContext _context;

        public AdminController(SamisDbContext context)
        {
            _context = context;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            return View(await _context.ActivityUnits.ToListAsync());
        }

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityUnit = await _context.ActivityUnits
                .FirstOrDefaultAsync(m => m.activityUnitId == id);
            if (activityUnit == null)
            {
                return NotFound();
            }

            return View(activityUnit);
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("activityUnitId,name,username,password")] ActivityUnit activityUnit)
        {
            if (ModelState.IsValid)
            {
                _context.Add(activityUnit);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(activityUnit);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityUnit = await _context.ActivityUnits.FindAsync(id);
            if (activityUnit == null)
            {
                return NotFound();
            }
            return View(activityUnit);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("activityUnitId,name,username,password")] ActivityUnit activityUnit)
        {
            if (id != activityUnit.activityUnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityUnit);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityUnitExists(activityUnit.activityUnitId))
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
            return View(activityUnit);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityUnit = await _context.ActivityUnits
                .FirstOrDefaultAsync(m => m.activityUnitId == id);
            if (activityUnit == null)
            {
                return NotFound();
            }

            return View(activityUnit);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityUnit = await _context.ActivityUnits.FindAsync(id);
            _context.ActivityUnits.Remove(activityUnit);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityUnitExists(int id)
        {
            return _context.ActivityUnits.Any(e => e.activityUnitId == id);
        }
    }
}
