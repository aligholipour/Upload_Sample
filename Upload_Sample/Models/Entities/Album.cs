using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upload_Sample.Models.Entities
{
    public class Album
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public int TrackCount { get; set; }

        // Relation
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        
        public IEnumerable<Song> Songs { get; set; }
    }
}
