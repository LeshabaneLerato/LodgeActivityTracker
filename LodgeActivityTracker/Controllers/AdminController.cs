using Microsoft.AspNetCore.Mvc;
using LodgeActivityTracker.Data;
using LodgeActivityTracker.Models;

using System;
using System.Linq;

public class AdminController : Controller
{
    private readonly ApplicationDbContext _context;

    public AdminController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        var model = new AdminDashboardViewModel
        {
            TotalActivities = _context.Activities.Count(),
            ActivitiesToday = _context.Activities
                .Count(a => a.Date.Date == DateTime.Today),
            RecentActivities = _context.Activities
                .OrderByDescending(a => a.Date)
                .Take(5)
                .ToList()
        };

        return View(model);
    }

}
    

