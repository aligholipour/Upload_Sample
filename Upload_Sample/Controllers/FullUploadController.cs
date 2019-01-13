using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Upload_Sample.Models;
using Upload_Sample.Models.Entities;
using Upload_Sample.Models.ViewModels;

namespace Upload_Sample.Controllers
{
    public class FullUploadController : Controller
    {
        private readonly ProjectDbContext _context;

        public FullUploadController(ProjectDbContext context)
        {
            _context = context;
        }

        public IActionResult PodcastList()
        {
            var list = _context.Podcasts.ToList();
            return View(list);
        }

        public IActionResult CreatePodcast()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreatePodcast(PodcastViewModel Podcasts, IFormFile file, IFormFile image)
        { 
            // Upload Image
            var pathImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/podcasts", image.FileName);
            using (var stream = new FileStream(pathImage, FileMode.Create))
            {
                image.CopyTo(stream);
            }

            var model = _context.Podcasts.Add(new Podcast
            {
                ArtistName = Podcasts.Podcasts.ArtistName,
                PodcastName = Podcasts.Podcasts.PodcastName,
                Image = "/images/podcasts/" + image.FileName,
                CreateDate = DateTime.Now,
            });

            _context.SaveChanges();

            foreach (var item in Podcasts.PodcastFile)
            {
                // Upload File Podcast
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/podcasts", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                _context.PodcastFiles.Add(new PodcastFile
                {
                    Name = item.Name,
                    File = "/files/podcasts/" + file.FileName,
                    PodcastId = model.Entity.Id
                });
            }
            _context.SaveChanges();

            //foreach (var item in podcast)
            //{
            //    // Upload File Podcast
            //    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/podcasts", item.Files.FileName);
            //    using (var stream = new FileStream(path, FileMode.Create))
            //    {
            //        item.Files.CopyTo(stream);
            //    }

            //    // Upload Image
            //    var pathImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/podcasts", item.Image.FileName);
            //    using (var stream = new FileStream(path, FileMode.Create))
            //    {
            //        item.Files.CopyTo(stream);
            //    }

            //    _context.Podcasts.Add(new Podcast
            //    {
            //        ArtistName = item.Podcasts.ArtistName,
            //        PodcastName = item.Podcasts.PodcastName,
            //        Image = "/images/podcasts/" + item.Image.FileName,
            //        CreateDate = DateTime.Now,
            //    });
            //}

            //_context.SaveChanges();

            return RedirectToAction("PodcastList");
        }
    }
}