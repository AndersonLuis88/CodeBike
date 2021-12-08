using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using CodeBikeAPI.DataAccess.Models;

namespace CodeBikeAPI.DataAccess.EF
{
    public class BikesDbContext: DbContext
    {
        public BikesDbContext(DbContextOptionsBuilder<BikesDbContext> options)
        {
        }
        public DbSet<Bike> Bikes { get; set; }
    }
}
