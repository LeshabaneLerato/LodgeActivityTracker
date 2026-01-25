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
            Console.WriteLine("Activities count: " + activities.Count);
            return View(activities);
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
                activity.Status = "Pending"; // default status
                _context.Activities.Add(activity);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(activity);
        }
    }
}
