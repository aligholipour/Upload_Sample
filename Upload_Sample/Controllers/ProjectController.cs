using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Upload_Sample.Models;
using Upload_Sample.Models.Entities;

namespace Upload_Sample.Controllers
{
    public class ProjectController : Controller
    {
        private readonly ProjectDbContext _context;

        public ProjectController(ProjectDbContext context)
        {
            _context = context;
        }

        public IActionResult ProjectManagement()
        {
            var list = _context.Projects.ToList();
            return View(list);
        }

        public IActionResult CreateProject()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProject(Project project, IFormFile file)
        {

            return RedirectToAction("ProjectManagement");
        }
    }
}