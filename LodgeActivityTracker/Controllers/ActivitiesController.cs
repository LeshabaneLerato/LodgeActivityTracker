using Microsoft.AspNetCore.Mvc;
using LodgeActivityTracker.Data;
using LodgeActivityTracker.Models;
using System;
using System.Linq;

namespace LodgeActivityTracker.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const int PageSize = 5;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activities
        public IActionResult Index(int page = 1)
        {
            var activities = _context.Activities
                .OrderBy(a => a.Date);

            int totalItems = activities.Count();
            int totalPages = (int)Math.Ceiling(totalItems / (double)PageSize);

            var pagedActivities = activities
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(pagedActivities);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                _context.Activities.Add(activity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }

        // GET: Activities/Edit/5
        public IActionResult Edit(int id)
        {
            var activity = _context.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: Activities/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Activity activity)
        {
            if (id != activity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(activity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }

        // GET: Activities/Delete/5
        public IActionResult Delete(int id)
        {
            var activity = _context.Activities.Find(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var activity = _context.Activities.Find(id);
            _context.Activities.Remove(activity);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
