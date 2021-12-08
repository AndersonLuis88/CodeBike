using System;
using System.Collections.Generic;
using System.Text;
using RentBikes.DataAccess.Models;
using System.Threading.Tasks;


namespace RentBikes.DataAccess.Repositories.Interfaces
{
    public interface IBikeRepository : IBaseRepository<Bike>
    {
        Task<List<Bike>> GetAvailableBikes();
        Task<List<Bike>> GetRentBikes();
    }
}
