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
    public class StatusTypesController : Controller
    {
        private readonly SamisDbContext _context;

        public StatusTypesController(SamisDbContext context)
        {
            _context = context;
        }

        // GET: StatusTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.StatusTypes.ToListAsync());
        }

        // GET: StatusTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusType = await _context.StatusTypes
                .FirstOrDefaultAsync(m => m.statusTypeId == id);
            if (statusType == null)
            {
                return NotFound();
            }

            return View(statusType);
        }

        // GET: StatusTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("statusTypeId,statusTypeName")] StatusType statusType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusType);
        }

        // GET: StatusTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusType = await _context.StatusTypes.FindAsync(id);
            if (statusType == null)
            {
                return NotFound();
            }
            return View(statusType);
        }

        // POST: StatusTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("statusTypeId,statusTypeName")] StatusType statusType)
        {
            if (id != statusType.statusTypeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusTypeExists(statusType.statusTypeId))
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
            return View(statusType);
        }

        // GET: StatusTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var statusType = await _context.StatusTypes
                .FirstOrDefaultAsync(m => m.statusTypeId == id);
            if (statusType == null)
            {
                return NotFound();
            }

            return View(statusType);
        }

        // POST: StatusTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var statusType = await _context.StatusTypes.FindAsync(id);
            _context.StatusTypes.Remove(statusType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusTypeExists(int id)
        {
            return _context.StatusTypes.Any(e => e.statusTypeId == id);
        }
    }
}
