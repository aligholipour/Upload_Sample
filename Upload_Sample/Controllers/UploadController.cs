using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var list = _context.Artists.Include(a=>a.Albums).ToList();
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
            upload.ImagePath = "/images/" +  file.FileName;
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

        [HttpGet]
        public IActionResult CreateAlbum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateAlbum(Album album, IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/albums", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            _context.Albums.Add(new Album
            {
                Name = album.Name,
                TrackCount = album.TrackCount,
                ImagePath = "/images/albums/" + file.FileName,
                ArtistId = album.Id
            });

            _context.SaveChanges();

            return RedirectToAction("ArtistList");
        }

        public IActionResult Song(int id)
        {
            var findAlbum = _context.Songs
                .Where(s=>s.AlbumId == id)
                .Include(a => a.Album)
                .ToList();

            var model = new SongViewModel
            {
                Song = findAlbum,
                AlbumImage = _context.Albums.Find(id).ImagePath,
                AlbumName = _context.Albums.Find(id).Name
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult CreateSong()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSong(Song song, IFormFile file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files/songs", file.FileName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            var model = _context.Songs.Add(new Song
            {
                Name = song.Name,
                File = "/files/songs/" + file.FileName,
                AlbumId = song.Id
            });

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}