using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upload_Sample.Models.Entities
{
    public class Podcast
    {
        public int Id { get; set; }
        public string ArtistName { get; set; }
        public string PodcastName { get; set; }
        public string Image { get; set; }
        public string TrackFile { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
