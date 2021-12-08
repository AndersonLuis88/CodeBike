using System;
using System.Collections.Generic;
using System.Text;
using CodeBikeAPI.DataAccess.Models;
using System.Threading.Tasks;

namespace CodeBikeAPI.DataAccess.Repositories.Interfaces
{
    public interface IBikeRepository : IBaseRepository<Bike>
    {
        Task<List<Bike>> GetAvailableBikes();
        Task<List<Bike>> GetRentBikes();
        Task<List<Bike>> GetAllBikes();
        Task<Bike> SetRent(int id);
        Task<Bike> CancelRent(int id);
    }
}
