using Microsoft.EntityFrameworkCore;
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
    }
}
