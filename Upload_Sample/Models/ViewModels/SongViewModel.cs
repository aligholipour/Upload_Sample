using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_Sample.Models.Entities;

namespace Upload_Sample.Models.ViewModels
{
    public class SongViewModel
    {
        public List<Song> Song { get; set; }
        public string AlbumName { get; set; }
        public string AlbumImage { get; set; }
    }
}
