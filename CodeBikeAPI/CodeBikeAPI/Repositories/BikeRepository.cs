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

        /// Retorna todas as Bikes
        public async Task<List<Bike>> GetAllBikes()
        {
            return await Context.Bikes.ToListAsync();
        }

        /// Retorno de pesquisa pelo ID da Bike
        public async Task<Bike> Get(int id)
        {
            return await Context.Bikes.FindAsync(id);
        }

        /// Retorna bikes disponíveis para aluguel.
        public async Task<List<Bike>> GetAvailableBikes()
        {
            return await Context.Bikes
                .Where(b => b.IsAvailable == true)
                .ToListAsync();
        }

        /// Retorna bikes alugadas.
        public async Task<List<Bike>> GetRentBikes()
        {
            return await Context.Bikes
                .Where(b => b.IsRent == true)
                .ToListAsync();
        }

        /// Cria nova bike. Pelo Swagger usa a tag (POST)
        public async Task<Bike> Create(Bike bike)
        {
            bike.PublicId = Guid.NewGuid();
            bike.IsRent = true;
            bike.IsAvailable = false;
            await Context.Bikes.AddAsync(bike);
            await Context.SaveChangesAsync();
            return await Get(bike.Id);
        }

        /// Retira bike pelo ID
        public async Task Delete(int id)
        {
            var bike = await Get(id);
            if (bike != null)
            {
                Context.Bikes.Remove(bike);
                await Context.SaveChangesAsync();
            }
        }


        /// Adiciona/Altera bike para alugada
        public async Task<Bike> SetRent(int id)
        {
            var bike = await Get(id);

            if (bike != null)
            {
                bike.IsRent = true;
                bike.IsAvailable = false;
                await Context.SaveChangesAsync();
            }

            return bike;
        }

        /// Cancela/Retira bike de alugada
        public async Task<Bike> CancelRent(int id)
        {
            var bike = await Get(id);

            if (bike != null)
            {
                bike.IsRent = false;
                bike.IsAvailable = true;
                await Context.SaveChangesAsync();
            }

            return bike;
        }

        /// Atualizar informações sobre a bike
        public async Task<Bike> Update(Bike item)
        {
            var bike = await Get(item.Id);
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
