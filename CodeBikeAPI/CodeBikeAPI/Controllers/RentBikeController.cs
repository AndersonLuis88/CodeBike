using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSwag.Annotations;
using CodeBikeAPI.DataAccess.Models;
using CodeBikeAPI.DataAccess.Repositories;
using CodeBikeAPI.DataAccess.Repositories.Interfaces;
using CodeBikeAPI.Services;

namespace CodeBikeAPI.Controllers
{
    [ApiController]
    [Route(LocalApiControllerConsts.StandardRoute)]
    public class RentBikeController : ApiControllerBase<ControllerServices<BikeRepository>, BikeRepository>
    {
        #region fields
        private IBikeRepository BikeRepository { get; set; }

        #endregion

        #region Constructor
        public RentBikeController(IBikeRepository bikeRepository)
        {
            BikeRepository = bikeRepository;
        }
        #endregion

        /// Retorna bike pelo ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
             [FromRoute, Required] int id
            )
        {
            return OkOrNotFound(await BikeRepository.Get(id));
        }

        /// Retorna todas as bikes.
        [HttpGet("Bikes")]
        public async Task<IActionResult> GetAllBikes()
        {
            return OkOrNotFound(await BikeRepository.GetAllBikes());
        }

        /// Retorna todas disponíveis.
        [HttpGet("AvailableBikes")]
        public async Task<IActionResult> GetAvailableBikes()
        {
            return OkOrNotFound(await BikeRepository.GetAvailableBikes());
        }

        /// Retorna todas alugadas.
        [HttpGet("RentBikes")]
        public async Task<IActionResult> GetRentBikes()
        {
            return OkOrNotFound(await BikeRepository.GetRentBikes());
        }

        /// Adiciona nova bike para aluguel.
        [HttpPost]
        public async Task<IActionResult> Create(
            [FromBody, Required] Bike bike
            )
        {
            if (bike == null)
            {
                return BadRequest();
            }

            return OkOrNotFound(await BikeRepository.Create(bike));
        }

        /// Deleta pelo ID.
        [HttpDelete("{id}")]
        public async Task Delete(
             [FromRoute, Required] int id
            )
        {
            await BikeRepository.Delete(id);
        }

        /// Seta bike como alugada pelo ID.
        [HttpPut("{id}/SetRent")]
        public async Task<IActionResult> SetRent(
             [FromRoute, Required] int id
            )
        {
            return OkOrNotFound(await BikeRepository.SetRent(id));
        }

        /// Cancela/Retira bike do status alugada.
        [HttpPut("{id}/CancelRent")]
        public async Task<IActionResult> CancelRent(
             [FromRoute, Required] int id
            )
        {
            return OkOrNotFound(await BikeRepository.CancelRent(id));
        }

        /// Atualiza Informações pelo ID
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRent(
             [FromRoute, Required] int id,
             [FromBody, Required] Bike model
            )
        {
            if (model == null || model.Id != id)
            {
                return BadRequest();
            }

            var bike = BikeRepository.Get(id);
            if (bike == null)
            {
                return NotFound();
            }

            return OkOrNotFound(await BikeRepository.Update(model));
        }
    }
}

