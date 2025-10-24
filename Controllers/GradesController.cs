using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.Controllers
{
    public class GradesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string course, double grade)
        {
            ViewBag.Course = course;
            ViewBag.Grade = grade;
            return View();
        }
    }
}