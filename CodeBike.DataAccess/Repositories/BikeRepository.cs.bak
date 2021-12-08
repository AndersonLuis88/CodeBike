using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentBikes.DataAccess.EF;
using RentBikes.DataAccess.Models;
using RentBikes.DataAccess.Repositories.Interfaces;

namespace RentBikes.DataAccess.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private BikesDbContext Context { get; set; }
        public BikeRepository(BikesDbContext context)
        {
            Context = context;
        }

        /// <summary>
        /// Return all items.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Bike>> GetItems()
        {
            return await Context.Bikes.ToListAsync();
        }

        /// <summary>
        /// Return bike by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Bike> Get(Guid id)
        {
            return await Context.Bikes.FindAsync(id);
        }

        /// <summary>
        /// Returns all available bikes.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Bike>> GetAvailableBikes()
        {
            return await Context.Bikes
                .Where(b => b.IsAvailable == true)
                .ToListAsync();
        }

        /// <summary>
        /// Returns all rent bikes.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Bike>> GetRentBikes()
        {
            return await Context.Bikes
                .Where(b => b.IsRent == true)
                .ToListAsync();
        }

        /// <summary>
        /// Creates a new bike.
        /// </summary>
        /// <param name="item"></param>
        public async Task<Bike> Create(Bike item)
        {
            await Context.Bikes.AddAsync(item);
            await Context.SaveChangesAsync();
            return await Get(item.PublicId);
        }

        /// <summary>
        /// Deletes the bike by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Bike> Delete(Guid id)
        {
            var todoItem = Get(id);

            if (todoItem != null)
            {
                Context.Bikes.Remove(todoItem.Result);
                Context.SaveChangesAsync();
            }

            return todoItem;
        }

        /// <summary>
        /// Updates information about the bike.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<Bike> Update(Bike item)
        {
            var bike = Get(item.PublicId).Result;
            bike.IsAvailable = item.IsAvailable;
            bike.IsRent = item.IsRent;
            bike.Name = item.Name;
            bike.RentCost = item.RentCost;
            bike.Type = item.Type;
            Context.Bikes.Update(bike);
            await Context.SaveChangesAsync();
            return bike;
        }

    }
}
