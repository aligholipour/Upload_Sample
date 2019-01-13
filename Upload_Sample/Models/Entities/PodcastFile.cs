using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Upload_Sample.Models.Entities
{
    public class PodcastFile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string File { get; set; }


        public int PodcastId { get; set; }
        public Podcast Podcast { get; set; }
    }
}
