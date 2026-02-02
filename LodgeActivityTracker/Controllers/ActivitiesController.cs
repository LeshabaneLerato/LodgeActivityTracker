using LodgeActivityTracker.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LodgeActivityTracker.Controllers
{
    [Authorize(Roles = "Admin,User,Guest")]
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // VIEW ACTIVITIES (ALL ROLES)
        public async Task<IActionResult> Index()
        {
            var activities = await _context.Activities
                .Where(a => a.Status == "Approved")
                .OrderByDescending(a => a.Date)
                .ToListAsync();

            return View(activities);
        }
    }
}
