using LodgeActivityTracker.Data;
using LodgeActivityTracker.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LodgeActivityTracker.Controllers
{
    [Authorize(Roles = "User,Guest")]
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Activities
        public async Task<IActionResult> Index()
        {
            var activities = await _context.Activities
                .Where(a => a.Status == "Approved")
                .ToListAsync();
            return View(activities);
        }
    }
}
