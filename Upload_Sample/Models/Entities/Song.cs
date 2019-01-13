using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upload_Sample.Models.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TrackName { get; set; }
        public string File { get; set; }

        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }
}
