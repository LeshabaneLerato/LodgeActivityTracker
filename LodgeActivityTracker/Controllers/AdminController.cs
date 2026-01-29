using LodgeActivityTracker.Data;
using LodgeActivityTracker.ViewModels;
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

    public async Task<IActionResult> Dashboard()
    {
        var model = new AdminDashboardViewModel
        {
            TotalActivities = await _context.Activities.CountAsync(),
            RecentActivities = await _context.Activities
                .OrderByDescending(a => a.Date)
                .Take(5)
                .ToListAsync()
        };

        return View(model);
    }
}
