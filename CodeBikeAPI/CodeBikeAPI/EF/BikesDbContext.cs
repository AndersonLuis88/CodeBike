using Microsoft.EntityFrameworkCore;
using CodeBikeAPI.DataAccess.Models;

namespace CodeBikeAPI.DataAccess.EF
{
    public class BikesDbContext : DbContext
    {
        public BikesDbContext(DbContextOptions<BikesDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Bike> Bikes { get; set; }

    }
}
