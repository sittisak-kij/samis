using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
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
        public IActionResult Index()
        {
            var projects = new List<Project>();
            var activities = _context.ActivityInformations.Where(x => x.activityUnitId == 1);
            foreach (var activity in activities)
            {
                var budgets = _context.Bugets.Where(x => x.activityId == activity.activityId);
                var project = new Project();
                project.activityInformation = activity;
                project.budgets = budgets.ToList();
                foreach (var b in project.budgets)
                {
                    b.budgetDescription = _context.BudgetDescription.SingleOrDefault(x => x.budgetDescriptionId == b.budgetDescriptionId);
                }
                projects.Add(project);
            }

            ViewBag.Projects = projects.OrderByDescending(x => x.activityInformation.timestamp.TimeOfDay).ThenBy(x => x.activityInformation.timestamp.Date).ThenBy(x => x.activityInformation.timestamp.Year);

            return View();
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(int? id)
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

            var i = 0;
            var totalAmounts = new List<Double>();
            totalAmounts.Add(0.0);
            totalAmounts.Add(0.0);
            totalAmounts.Add(0.0);
            totalAmounts.Add(0.0);
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

                i++;

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
        public async Task<IActionResult> Create(Project project)
        {
            var temp = project.activityInformation.referenceNumber.Split("/");
            project.activityInformation.semester = int.Parse(temp[0]);
            project.activityInformation.year = int.Parse(temp[1]);
            var referenceNumber = "S" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                  "0001";
            project.activityInformation.referenceNumber = referenceNumber;
            project.activityInformation.activityTypeId = 1;
            project.activityInformation.activityUnitId = 1;
            project.activityInformation.advisorId = 1;
            project.activityInformation.statusTypeId = 1;
            project.activityInformation.timestamp = DateTime.Now;
            var budgets = JsonConvert.DeserializeObject<List<Budget>>(Request.Form["budgets"]);
            if (ModelState.IsValid)
            {
                _context.ActivityInformations.Add(project.activityInformation);
                await _context.SaveChangesAsync();
                project.budgets = budgets;
                foreach (var budget in budgets)
                {
                    budget.activityId = project.activityInformation.activityId;
                }

                _context.Bugets.AddRange(project.budgets);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return Content("Something went wrong");
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

            var project = new Project
            {
                activityInformation = activityInformation,
                budgets = _context.Bugets.Where(x => x.activityId == activityInformation.activityId).ToList()
            };

            ViewData["activityTypeName"] = new SelectList(_context.ActivityTypes, "activityTypeId", "activityTypeName");
            ViewData["projectLevelName"] = new SelectList(_context.ProjectLevels, "projectLevelId", "name");
            ViewBag.revenues = _context.BudgetDescription.Where(x => x.budgetTypeId == 1);
            ViewBag.expenses = _context.BudgetDescription.Where(x => x.budgetTypeId == 2);

            foreach (var budget in project.budgets)
            {
                budget.budgetDescription = _context.BudgetDescription.SingleOrDefault(x =>
                    x.budgetDescriptionId == budget.budgetDescriptionId);
            }

            var budgetProjects = new List<BudgetProject>();

            var i = 0;
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
                        budgetTypeId = budget.budgetDescription.budgetTypeId
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

                i++;

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

            var amountString = new List<String> {"", "", "", ""};
            var j = 0;
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

            //            ViewData["activityUnitId"] = new SelectList(_context.ActivityUnits, "activityUnitId", "activityUnitId", activityInformation.activityUnitId);
            //            ViewData["advisorId"] = new SelectList(_context.Advisors, "advisorId", "advisorId", activityInformation.advisorId);
            //            ViewData["statusTypeId"] = new SelectList(_context.StatusTypes, "statusTypeId", "statusTypeId", activityInformation.statusTypeId);
            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project project)
        {
            var temp = project.activityInformation.referenceNumber.Split("/");
            project.activityInformation.semester = int.Parse(temp[0]);
            project.activityInformation.year = int.Parse(temp[1]);
            var referenceNumber = "S" + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString().PadLeft(2, '0') +
                                  "0001";
            project.activityInformation.referenceNumber = referenceNumber;
            project.activityInformation.activityTypeId = 1;
            project.activityInformation.activityUnitId = 1;
            project.activityInformation.advisorId = 1;
            project.activityInformation.statusTypeId = 1;
            project.activityInformation.timestamp = DateTime.Now;
            project.budgets = JsonConvert.DeserializeObject<List<Budget>>(Request.Form["budgets"]);
            if (ModelState.IsValid)
            {
                project.activityInformation.activityId = id;
                try
                {
                    _context.ActivityInformations.Update(project.activityInformation);
                    _context.Bugets.AddRange(project.budgets);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction("Details", new {id = id});
//                return RedirectToAction("Edit", "Project", new {id = id});
            }

//            if (id != activityInformation.activityId)
//            {
//                return NotFound();
//            }
//
//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(activityInformation);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ActivityInformationExists(activityInformation.activityId))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }
//                return RedirectToAction(nameof(Index));
//            }
//            ViewData["activityUnitId"] = new SelectList(_context.ActivityUnits, "activityUnitId", "activityUnitId", activityInformation.activityUnitId);
//            ViewData["advisorId"] = new SelectList(_context.Advisors, "advisorId", "advisorId", activityInformation.advisorId);
//            ViewData["statusTypeId"] = new SelectList(_context.StatusTypes, "statusTypeId", "statusTypeId", activityInformation.statusTypeId);
            return RedirectToAction("Index");
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

        [HttpGet]
        public async Task<IActionResult> DeleteBudgets(int id)
        {
            var oldBudgets = _context.Bugets.Where(x => x.activityId == id);
            _context.RemoveRange(oldBudgets);
            await _context.SaveChangesAsync();
            return Json("Success");
        }
    }
}
