using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyProject.API.Data
{
    public class MyProjectAuthDbContext : IdentityDbContext
    {
        public MyProjectAuthDbContext(DbContextOptions<MyProjectAuthDbContext> options) : base(options)
        {

        }
    }
}
