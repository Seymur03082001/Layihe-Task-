using Layihe_Task_.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Layihe_Task_.Controllers
{
    public class HomeController : Controller
    {
        public readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Post()
        {
            return View();
        }
    }
}
