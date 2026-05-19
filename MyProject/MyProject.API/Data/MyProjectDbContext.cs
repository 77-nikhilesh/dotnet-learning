using Microsoft.EntityFrameworkCore;
using MyProject.API.Models.Domain;

namespace MyProject.API.Data
{
    public class MyProjectDbContext : DbContext

    {
        public MyProjectDbContext(DbContextOptions<MyProjectDbContext> dbContextOptions) : base (dbContextOptions)
        {
            
        }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }

        public DbSet<Walk> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Dees data for Difficulties
            //Easy, Medium, Hard
            var difficulties= new List<Difficulty>()
            {
                new Difficulty
                {
                    Id=Guid.Parse("d1bfbf8e-9c3a-4c5e-8b0a-1a2b3c4d5e6f"),
                    Name="Easy"
                },
                new Difficulty {
                    Id=Guid.Parse("e2c1a9b8-7d6f-4a5e-9b0c-2d3e4f5a6b7c"),
                    Name="Medium"

                },
                new Difficulty {
                    Id=Guid.Parse("f3d2b7c6-8e5f-4a9b-0c1d-3e4f5a6b7c8d"),
                    Name="Hard"
                }
            };

            //Seed difficulties to the database
            modelBuilder.Entity<Difficulty>().HasData(difficulties.ToArray());

            //Seed data for Region
            var region = new List<Region>()
            {
                new Region
                {
                    Id=Guid.Parse("a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d"),
                    Code="US",
                    Name="United States",
                    RegionImageUrl="https://example.com/images/usa.png"
                },
                new Region
                {
                    Id=Guid.Parse("b2c3d4e5-f6a7-8b9c-0d1e-2f3a4b5c6d7e"),
                    Code="CA",
                    Name="Canada",
                    RegionImageUrl=null
                },
            };

            //Seed regions to the database
            modelBuilder.Entity<Region>().HasData(region.ToArray());
        }

    }
}
