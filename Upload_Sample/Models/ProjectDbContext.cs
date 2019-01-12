using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Upload_Sample.Models.Entities;

namespace Upload_Sample.Models
{
    public class ProjectDbContext : DbContext
    {
        public ProjectDbContext(DbContextOptions<ProjectDbContext> options) : base(options)
        {

        }

        public DbSet<Artist> Artists { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
