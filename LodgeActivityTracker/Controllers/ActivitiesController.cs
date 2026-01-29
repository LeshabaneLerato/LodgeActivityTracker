using LodgeActivityTracker.Data;
using LodgeActivityTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ActivitiesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ActivitiesController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        // Users only see APPROVED activities
        var activities = await _context.Activities
            .Where(a => a.Status == "Approved")
            .ToListAsync();

        return View(activities);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Activity activity)
    {
        if (ModelState.IsValid)
        {
            activity.Status = "Pending"; // ✅ REQUIRED
            _context.Add(activity);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Activity submitted for approval.";
            return RedirectToAction(nameof(Index));
        }

        return View(activity);
    }
}
