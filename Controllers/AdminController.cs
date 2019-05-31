using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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

        public IActionResult Projects()
        {
            var projects = new List<Project>();
            var activities = _context.ActivityInformations.Where(x => x.activityUnitId == 1);
            foreach (var activity in activities)
            {
                var budgets = _context.Bugets.Where(x => x.activityId == activity.activityId);
                var project = new Project();
                project.activityInformation = activity;
                project.budgets = budgets.ToList();
                projects.Add(project);
            }

            ViewBag.Projects = projects.OrderByDescending(x => x.activityInformation.timestamp.TimeOfDay).ThenBy(x => x.activityInformation.timestamp.Date).ThenBy(x => x.activityInformation.timestamp.Year);
            return View();
        }

        public IActionResult BudgetManager(int? id)
        {
            var project = new Project
            {
                activityInformation = _context.ActivityInformations.SingleOrDefault(x => x.activityId == id),
                budgets = _context.Bugets.Where(x => x.activityId == id).ToList()
            };

            if (project.activityInformation != null)
            {
                project.activityInformation.activityType = _context.ActivityTypes.SingleOrDefault(x =>
                    x.activityTypeId == project.activityInformation.activityTypeId);
                project.activityInformation.projectLevel = _context.ProjectLevels.SingleOrDefault(x =>
                    x.projectLevelId == project.activityInformation.projectLevelId);
                project.activityInformation.advisor = _context.Advisors.SingleOrDefault(x =>
                    x.advisorId == project.activityInformation.advisorId);
            }

            foreach (var budget in project.budgets)
            {
                budget.budgetDescription = _context.BudgetDescription.SingleOrDefault(x =>
                    x.budgetDescriptionId == budget.budgetDescriptionId);
            }

            var budgetProjects = new List<BudgetProject>();

            var totalAmounts = new List<Double> {0.0, 0.0, 0.0, 0.0};
            foreach (var budget in project.budgets)
            {
                if (budgetProjects.Any(x => x.budgetName == budget.budgetDescription.name))
                {
                    foreach (var b in budgetProjects)
                    {
                        if (b.budgetName == budget.budgetDescription.name)
                        {
                            b.approved = "฿" + budget.amount.ToString("N");
                        }
                    }
//                    if (budget.budgetStatusId == 1)
//                    {
//                        budgetProjects[i].proposed = "฿" + budget.amount.ToString("N");
//                    }
//                    else if (budget.budgetStatusId == 2)
//                    {
//                        budgetProjects[i].approved = "฿" + budget.amount.ToString("N");
//                    }
                }
                else
                {
                    var bp = new BudgetProject
                    {
                        budgetName = budget.budgetDescription.name,
                        proposed = "Pending",
                        approved = "Pending",
                        budgetTypeId = budget.budgetDescription.budgetTypeId,
                        budgetDescriptionId = budget.budgetDescriptionId
                    };
                    if (budget.budgetStatusId == 1)
                    {
                        bp.proposed = "฿" + budget.amount.ToString("N");
                    }
                    else if (budget.budgetStatusId == 2)
                    {
                        bp.approved = "฿" + budget.amount.ToString("N");
                    }

                    budgetProjects.Add(bp);
                }

                if (budget.budgetStatusId == 1)
                {
                    if (budget.budgetDescription.budgetTypeId == 1)
                    {
                        totalAmounts[0] += budget.amount;
                    }
                    else if (budget.budgetDescription.budgetTypeId == 2)
                    {
                        totalAmounts[1] += budget.amount;
                    }
                }
                else if (budget.budgetStatusId == 2)
                {
                    if (budget.budgetDescription.budgetTypeId == 1)
                    {
                        totalAmounts[2] += budget.amount;
                    }
                    else if (budget.budgetDescription.budgetTypeId == 2)
                    {
                        totalAmounts[3] += budget.amount;
                    }
                }
            }

            var amountString = new List<String>();
            amountString.Add("");
            amountString.Add("");
            amountString.Add("");
            amountString.Add("");
            int j = 0;
            foreach (var amount in totalAmounts)
            {
                if (amount > 0)
                {
                    amountString[j] = "฿" + amount.ToString("N");
                }
                else
                {
                    amountString[j] = "Pending";
                }

                j++;
            }

            ViewBag.Project = project;
            ViewBag.BudgetProjects = budgetProjects;
            ViewBag.TotalAmount = amountString;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> BudgetManager(Project project)
        {
            var budgets = JsonConvert.DeserializeObject<List<Budget>>(Request.Form["budgets"]);
            _context.Bugets.AddRange(budgets);
            await _context.SaveChangesAsync();

            return RedirectToAction("Projects");
        }
    }
}
