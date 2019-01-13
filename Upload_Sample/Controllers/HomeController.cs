using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Upload_Sample.Models;
using Upload_Sample.Models.ViewModels;

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
            var list = new IndexViewModel
            {
                Artist = _context.Artists.ToList(),
                Album = _context.Albums.ToList()
            };

            return View(list);
        }
    }
}