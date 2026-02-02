using LodgeActivityTracker.Data;
using LodgeActivityTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LodgeActivityTracker.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================= DASHBOARD =================
        public async Task<IActionResult> Dashboard()
        {
            var activities = await _context.Activities
                .OrderByDescending(a => a.Date)
                .ToListAsync();

            return View(activities);
        }

        // ================= CREATE =================
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return View(activity);
            }

            // Ensure admin controls status
            if (string.IsNullOrEmpty(activity.Status))
            {
                activity.Status = "Pending";
            }

            _context.Activities.Add(activity);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Activity created successfully.";
            return RedirectToAction(nameof(Dashboard));
        }

        // ================= EDIT =================
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Activity activity)
        {
            if (!ModelState.IsValid)
            {
                return View(activity);
            }

            _context.Activities.Update(activity);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Activity updated successfully.";
            return RedirectToAction(nameof(Dashboard));
        }

        // ================= DELETE =================
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity != null)
            {
                _context.Activities.Remove(activity);
                await _context.SaveChangesAsync();
            }

            TempData["ErrorMessage"] = "Activity deleted.";
            return RedirectToAction(nameof(Dashboard));
        }

        // ================= APPROVE =================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            activity.Status = "Approved";
            _context.Update(activity);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Activity approved.";
            return RedirectToAction(nameof(Dashboard));
        }

        // ================= REJECT =================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }

            activity.Status = "Rejected";
            _context.Update(activity);
            await _context.SaveChangesAsync();

            TempData["ErrorMessage"] = "Activity rejected.";
            return RedirectToAction(nameof(Dashboard));
        }
    }
}
