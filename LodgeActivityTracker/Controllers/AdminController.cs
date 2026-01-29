using LodgeActivityTracker.Data;
using LodgeActivityTracker.Models.ViewModels;
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

        [HttpGet]
        public async Task<IActionResult> Dashboard()
        {
            var activities = await _context.Activities
                .OrderByDescending(a => a.Date)
                .ToListAsync();

            var vm = new AdminDashboardViewModel
            {
                RecentActivities = activities,
                TotalActivities = activities.Count,
                PendingCount = activities.Count(a => a.Status == "Pending"),
                ApprovedCount = activities.Count(a => a.Status == "Approved"),
                RejectedCount = activities.Count(a => a.Status == "Rejected")
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Approve(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null) return NotFound();

            activity.Status = "Approved";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Dashboard));
        }

        [HttpPost]
        public async Task<IActionResult> Reject(int id)
        {
            var activity = await _context.Activities.FindAsync(id);
            if (activity == null) return NotFound();

            activity.Status = "Rejected";
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Dashboard));
        }
    }
}
