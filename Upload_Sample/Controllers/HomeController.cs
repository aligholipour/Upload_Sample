using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Upload_Sample.Models;

namespace Upload_Sample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProjectDbContext _context;

        public HomeController(ProjectDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Artists.ToList());
        }
    }
}