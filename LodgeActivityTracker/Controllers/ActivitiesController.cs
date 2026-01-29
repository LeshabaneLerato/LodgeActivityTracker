using LodgeActivityTracker.Data;
using LodgeActivityTracker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

public class ActivitiesController : Controller
{
    private readonly ApplicationDbContext _context;

    public ActivitiesController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Activities
    public async Task<IActionResult> Index()
    {
        return View(await _context.Activities.ToListAsync());
    }

    // GET: Activities/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Activities/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Activity activity)
    {
        if (!ModelState.IsValid)
            return View(activity);

        _context.Activities.Add(activity);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Activity created successfully!";
        return RedirectToAction(nameof(Index));
    }

    // GET: Activities/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
            return NotFound();

        var activity = await _context.Activities.FindAsync(id);
        if (activity == null)
            return NotFound();

        return View(activity);
    }

    // POST: Activities/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Activity activity)
    {
        if (!ModelState.IsValid)
            return View(activity);

        _context.Activities.Update(activity);
        await _context.SaveChangesAsync();

        TempData["SuccessMessage"] = "Activity updated successfully!";
        return RedirectToAction(nameof(Index));
    }

    // GET: Activities/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
            return NotFound();

        var activity = await _context.Activities
            .FirstOrDefaultAsync(a => a.Id == id);

        if (activity == null)
            return NotFound();

        return View(activity);
    }

    // POST: Activities/DeleteConfirmed/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var activity = await _context.Activities.FindAsync(id);
        if (activity != null)
        {
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
            TempData["SuccessMessage"] = "Activity deleted successfully!";
        }

        return RedirectToAction(nameof(Index));
    }
}
