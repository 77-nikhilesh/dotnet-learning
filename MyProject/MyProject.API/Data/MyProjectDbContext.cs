using Microsoft.EntityFrameworkCore;
using MyProject.API.Models.Domain;

namespace MyProject.API.Data
{
    public class MyProjectDbContext : DbContext

    {
        public MyProjectDbContext(DbContextOptions dbContextOptions) : base (dbContextOptions)
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

    }
}
