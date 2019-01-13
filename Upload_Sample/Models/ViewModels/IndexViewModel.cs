using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_Sample.Models.Entities;

namespace Upload_Sample.Models.ViewModels
{
    public class IndexViewModel
    {
        public List<Artist> Artist { get; set; }
        public List<Album> Album { get; set; }
    }
}
