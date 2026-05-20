using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyProject.API.Data
{
    public class MyProjectAuthDbContext : IdentityDbContext
    {
        public MyProjectAuthDbContext(DbContextOptions<MyProjectAuthDbContext> options) : base(options)
        {

        }

        public object Password { get; internal set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = Guid.Parse("1a2b3c4d-5e6f-7a8b-9c0d-1e2f3a4b5c6d").ToString();
            var writerRoleId = Guid.Parse("2b3c4d5e-6f7a-8b9c-0d1e-2f3a4b5c6d7e").ToString();
            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id=readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name="Reader",
                    NormalizedName="Reader".ToUpper(),
                },
                new IdentityRole
                {
                    Id=writerRoleId,
                    ConcurrencyStamp= writerRoleId,
                    Name="Writer",
                    NormalizedName="Writer".ToUpper()
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
