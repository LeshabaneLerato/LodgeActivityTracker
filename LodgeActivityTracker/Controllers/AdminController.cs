using LodgeActivityTracker.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    // ✅ THIS FIXES /Admin/Dashboard NOT FOUND
    [HttpGet]
    public async Task<IActionResult> Dashboard()
    {
        var activities = await _context.Activities
            .OrderByDescending(a => a.Date)
            .ToListAsync();

        return View(activities); // IMPORTANT
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Approve(int id)
    {
        var activity = await _context.Activities.FindAsync(id);
        if (activity == null) return NotFound();

        activity.Status = "Approved";
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Dashboard));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Reject(int id)
    {
        var activity = await _context.Activities.FindAsync(id);
        if (activity == null) return NotFound();

        activity.Status = "Rejected";
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Dashboard));
    }
}
