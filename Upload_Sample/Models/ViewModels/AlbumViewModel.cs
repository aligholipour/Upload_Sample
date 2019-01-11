using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_Sample.Models.Entities;

namespace Upload_Sample.Models.ViewModels
{
    public class AlbumViewModel
    {
        public Album Album { get; set; }
        public IFormFile File { get; set; }
    }
}
