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

    // GET: Activities
    public async Task<IActionResult> Index()
    {
        var activities = await _context.Activities
            .Where(a => a.Status == "Approved")
            .ToListAsync();
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
    public async Task<IActionResult> Create(Activity activity)
    {
        if (ModelState.IsValid)
        {
            activity.Status = "Pending";
            _context.Add(activity);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Activity submitted for approval.";
            return RedirectToAction(nameof(Index));
        }
        return View(activity);
    }

    // GET: Activities/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var activity = await _context.Activities.FindAsync(id);
        if (activity == null) return NotFound();

        return View(activity);
    }

    // POST: Activities/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Activity activity)
    {
        if (id != activity.Id) return NotFound();

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(activity);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ActivityExists(activity.Id))
                    return NotFound();
                else
                    throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(activity);
    }

    // GET: Activities/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();

        var activity = await _context.Activities
            .FirstOrDefaultAsync(a => a.Id == id);
        if (activity == null) return NotFound();

        return View(activity);
    }

    // POST: Activities/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var activity = await _context.Activities.FindAsync(id);
        if (activity != null)
        {
            _context.Activities.Remove(activity);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }

    private bool ActivityExists(int id)
    {
        return _context.Activities.Any(e => e.Id == id);
    }
}
