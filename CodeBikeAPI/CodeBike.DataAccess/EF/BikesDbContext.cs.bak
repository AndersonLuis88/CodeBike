using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using RentBikes.DataAccess.Models;

namespace RentBikes.DataAccess.EF
{
    public class BikesDbContext: DbContext
    {
        public BikesDbContext(DbContextOptionsBuilder<BikesDbContext> options)
        {
        }
        public DbSet<Bike> Bikes { get; set; }
    }
}
