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
    public class ProjectLevelController : Controller
    {
        private readonly SamisDbContext _context;

        public ProjectLevelController(SamisDbContext context)
        {
            _context = context;
        }

        // GET: ProjectLevel
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProjectLevels.ToListAsync());
        }

        // GET: ProjectLevel/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectLevel = await _context.ProjectLevels
                .FirstOrDefaultAsync(m => m.projectLevelId == id);
            if (projectLevel == null)
            {
                return NotFound();
            }

            return View(projectLevel);
        }

        // GET: ProjectLevel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProjectLevel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("projectLevelId,name")] ProjectLevel projectLevel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projectLevel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(projectLevel);
        }

        // GET: ProjectLevel/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectLevel = await _context.ProjectLevels.FindAsync(id);
            if (projectLevel == null)
            {
                return NotFound();
            }
            return View(projectLevel);
        }

        // POST: ProjectLevel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("projectLevelId,name")] ProjectLevel projectLevel)
        {
            if (id != projectLevel.projectLevelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projectLevel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjectLevelExists(projectLevel.projectLevelId))
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
            return View(projectLevel);
        }

        // GET: ProjectLevel/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var projectLevel = await _context.ProjectLevels
                .FirstOrDefaultAsync(m => m.projectLevelId == id);
            if (projectLevel == null)
            {
                return NotFound();
            }

            return View(projectLevel);
        }

        // POST: ProjectLevel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var projectLevel = await _context.ProjectLevels.FindAsync(id);
            _context.ProjectLevels.Remove(projectLevel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectLevelExists(int id)
        {
            return _context.ProjectLevels.Any(e => e.projectLevelId == id);
        }
    }
}
