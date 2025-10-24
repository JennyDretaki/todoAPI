using Microsoft.AspNetCore.Mvc;
using TodoListApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TodoListApp.Controllers
{
    public class GroceryController : Controller
    {
        private readonly TodoDbContext _context;

        public GroceryController(TodoDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.GroceryItems.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(GroceryItem groceryItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(groceryItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(groceryItem);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var groceryItem = await _context.GroceryItems.FindAsync(id);
            if (groceryItem == null) return NotFound();
            return View(groceryItem);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, GroceryItem groceryItem)
        {
            if (id != groceryItem.Id) return NotFound();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(groceryItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.GroceryItems.Any(e => e.Id == id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(groceryItem);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var groceryItem = await _context.GroceryItems.FindAsync(id);
            if (groceryItem == null) return NotFound();
            return View(groceryItem);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var groceryItem = await _context.GroceryItems.FindAsync(id);
            if (groceryItem != null)
            {
                _context.GroceryItems.Remove(groceryItem);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}