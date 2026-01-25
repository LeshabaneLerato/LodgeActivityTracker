using Microsoft.AspNetCore.Mvc;
using LodgeActivityTracker.Data;
using LodgeActivityTracker.Models;
using System.Linq;

namespace LodgeActivityTracker.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Activities
        public IActionResult Index()
        {
            var activities = _context.Activities.ToList();
            return View(activities);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        public IActionResult Create(Activity activity)
        {
            if (ModelState.IsValid)
            {
                activity.Status = "Pending";
                _context.Activities.Add(activity);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }
    }
}
