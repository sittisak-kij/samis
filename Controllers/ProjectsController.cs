﻿using System;
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
    public class ProjectsController : Controller
    {
        private readonly SamisDbContext _context;

        public ProjectsController(SamisDbContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
            return View();
            //    var samisDbContext = _context.ActivityInformations.Include(a => a.activityUnit).Include(a => a.advisor).Include(a => a.locationType).Include(a => a.statusType);
            //    return View(await samisDbContext.ToListAsync());
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            return View();
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            ViewData["activityTypeName"] = new SelectList(_context.ActivityTypes, "activityTypeId", "activityTypeName");
            ViewData["projectLevelName"] = new SelectList(_context.ProjectLevels, "projectLevelId", "name");
            ViewBag.revenues = _context.BudgetDescription.Where(x => x.budgetTypeId == 1);
            ViewBag.expenses = _context.BudgetDescription.Where(x => x.budgetTypeId == 2);
            return View();
        }

        // POST: Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ActivityInformation activityInformation)
        {
            var temp = activityInformation.referenceNumber.Split("/");
            activityInformation.semester = int.Parse(temp[0]);
            activityInformation.year = int.Parse(temp[1]);
            var referenceNumber = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') + "0001";
            activityInformation.referenceNumber = referenceNumber;
            activityInformation.activityTypeId = 1;
            activityInformation.activityUnitId = 1;
            activityInformation.advisorId = 1;
            activityInformation.statusTypeId = 1;
            if (ModelState.IsValid)
            {
                _context.Add(activityInformation);
                await _context.SaveChangesAsync();
                return Json(activityInformation);
            }
            return Content("Failed to add the activity");
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityInformation = await _context.ActivityInformations.FindAsync(id);
            if (activityInformation == null)
            {
                return NotFound();
            }
            ViewData["activityUnitId"] = new SelectList(_context.ActivityUnits, "activityUnitId", "activityUnitId", activityInformation.activityUnitId);
            ViewData["advisorId"] = new SelectList(_context.Advisors, "advisorId", "advisorId", activityInformation.advisorId);
            ViewData["statusTypeId"] = new SelectList(_context.StatusTypes, "statusTypeId", "statusTypeId", activityInformation.statusTypeId);
            return View(activityInformation);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("activityId,activityUnitId,referenceNumber,activityName,typeId,startDate,endDate,venue,semester,year,participant,statusTypeId,advisorId")] ActivityInformation activityInformation)
        {
            if (id != activityInformation.activityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(activityInformation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActivityInformationExists(activityInformation.activityId))
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
            ViewData["activityUnitId"] = new SelectList(_context.ActivityUnits, "activityUnitId", "activityUnitId", activityInformation.activityUnitId);
            ViewData["advisorId"] = new SelectList(_context.Advisors, "advisorId", "advisorId", activityInformation.advisorId);
            ViewData["statusTypeId"] = new SelectList(_context.StatusTypes, "statusTypeId", "statusTypeId", activityInformation.statusTypeId);
            return View(activityInformation);
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var activityInformation = await _context.ActivityInformations
                .Include(a => a.activityUnit)
                .Include(a => a.advisor)
                .Include(a => a.statusType)
                .FirstOrDefaultAsync(m => m.activityId == id);
            if (activityInformation == null)
            {
                return NotFound();
            }

            return View(activityInformation);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activityInformation = await _context.ActivityInformations.FindAsync(id);
            _context.ActivityInformations.Remove(activityInformation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActivityInformationExists(int id)
        {
            return _context.ActivityInformations.Any(e => e.activityId == id);
        }
    }
}
