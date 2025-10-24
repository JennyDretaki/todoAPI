using Microsoft.AspNetCore.Mvc;

namespace TodoListApp.Controllers
{
    public class MotivationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}