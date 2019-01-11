using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_Sample.Models.Entities;

namespace Upload_Sample.Models.ViewModels
{
    public class ArtistViewModel
    {
        public List<Album> Albums { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
