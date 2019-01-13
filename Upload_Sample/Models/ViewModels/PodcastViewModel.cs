using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_Sample.Models.Entities;

namespace Upload_Sample.Models.ViewModels
{
    public class PodcastViewModel
    {
        public Podcast Podcasts { get; set; }
        public List<PodcastFile> PodcastFile { get; set; }
    }
}
