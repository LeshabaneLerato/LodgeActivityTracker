using LodgeActivityTracker.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        var activities = _context.Activities.ToList();
        return View(activities);
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
