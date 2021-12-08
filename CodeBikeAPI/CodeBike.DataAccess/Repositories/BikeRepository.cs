using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CodeBikeAPI.DataAccess.EF;
using CodeBikeAPI.DataAccess.Models;
using CodeBikeAPI.DataAccess.Repositories.Interfaces;

namespace CodeBikeAPI.DataAccess.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private BikesDbContext Context { get; set; }
        public BikeRepository(BikesDbContext context)
        {
            Context = context;
        }

       
        public async Task<List<Bike>> GetItems()
        {
            return await Context.Bikes.ToListAsync();
        }

       
        public async Task<Bike> Get(Guid id)
        {
            return await Context.Bikes.FindAsync(id);
        }

        
        public async Task<List<Bike>> GetAvailableBikes()
        {
            return await Context.Bikes
                .Where(b => b.IsAvailable == true)
                .ToListAsync();
        }

       
        public async Task<List<Bike>> GetRentBikes()
        {
            return await Context.Bikes
                .Where(b => b.IsRent == true)
                .ToListAsync();
        }

        
        public async Task<Bike> Create(Bike item)
        {
            await Context.Bikes.AddAsync(item);
            await Context.SaveChangesAsync();
            return await Get(item.PublicId);
        }

       
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
