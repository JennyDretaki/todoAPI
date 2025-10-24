using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Controllers
{
    public class GoalsController : Controller
    {
        private readonly TodoDbContext _context;

        public GoalsController(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Goals.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Goal goal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(goal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index)); // <-- Redirect instead of returning View()
            }
            return View(goal); // This line expects a Create.cshtml view. If you don't have one, consider returning PartialView or handling differently.
        }


        [HttpPost]
        public async Task<IActionResult> Complete(int id)
        {
            var goal = await _context.Goals.FindAsync(id);
            if (goal != null)
            {
                goal.IsCompleted = true;
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}