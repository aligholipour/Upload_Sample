using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Upload_Sample.Models;
using Upload_Sample.Models.Entities;
using Upload_Sample.Models.ViewModels;

namespace Upload_Sample.Controllers
{
    public class UploadController : Controller
    {
        private readonly ProjectDbContext _context;

        public UploadController(ProjectDbContext context)
        {
            _context = context;
        }

        public IActionResult ArtistList()
        {
            var list = _context.Artists.ToList();
            return View(list);
        }

        public IActionResult CreateArtist()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateArtist(Artist upload, IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            upload.TimeCreated = DateTime.Now;
            upload.ImagePath = file.FileName;
            _context.Artists.Add(upload);
            _context.SaveChanges();

            return RedirectToAction("ArtistList");
        }

        public IActionResult EditArtist(int id)
        {
            var find = _context.Artists.Find(id);
            return View(find);
        }

        [HttpPost]
        public IActionResult EditArtist(Artist upload, IFormFile file)
        {
            if (file == null || file.Length < 0)
            {
                upload.ImagePath = upload.ImagePath;
            }
            else
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
                upload.ImagePath = file.FileName;
            }

            _context.Entry(upload).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("ArtistList");
        }

        public IActionResult DeleteArtist(int id)
        {
            var find = _context.Artists.Find(id);
            _context.Entry(find).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _context.SaveChanges();
            return RedirectToAction("ArtistList");
        }

        public IActionResult Album(int id)
        {
            var findAlbum = _context.Albums.Where(a => a.ArtistId == id).ToList();
            var findArtist = _context.Artists.Find(id);
            var artist = new ArtistViewModel()
            {
                Albums = findAlbum,
                Name = findArtist.Name,
                ImagePath = findArtist.ImagePath
            };

            return View(artist);
        }

        public IActionResult CreateAlbum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAlbum(List<AlbumViewModel> album /*Album album, IList<IFormFile> file*/)
        {
            foreach (var item in album)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/albums", item.File.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    item.File.CopyTo(stream);
                }

                _context.Albums.Add(new Album
                {
                    Name = item.Album.Name,
                    TrackCount = item.Album.TrackCount,
                    ImagePath = item.File.FileName,
                    ArtistId = item.Album.Id
                });
            }

            _context.SaveChanges();

            return RedirectToAction("ArtistList");
        }

        public IActionResult MultipleUploadFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MultipleUploadFile(Artist upload, IList<IFormFile> file)
        {
            upload.TimeCreated = DateTime.Now;
            var newUpload = _context.Artists.Add(upload);
            _context.SaveChanges();

            foreach (var item in file)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", item.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    item.CopyTo(stream);
                }

                _context.Albums.Add(new Album
                {
                    ImagePath = item.FileName,
                    ArtistId = newUpload.Entity.Id
                });
            }

            _context.SaveChanges();
            
            return RedirectToAction("UploadList");
        }
    }
}