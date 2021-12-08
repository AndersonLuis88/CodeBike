using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using RentBikes.DataAccess.Models.Abstract;

namespace RentBikes.DataAccess.Models
{
    /// <summary>
    /// Contains information about a bike.
    /// </summary>
    public class Bike : BaseModel
    {
        /// <summary>
        /// Name.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Type
        /// </summary>
        [Required]
        public BikeType Type { get; set; }

        /// <summary>
        /// Rent cost
        /// </summary>
        [Required]
        public decimal RentCost { get; set; }

        /// <summary>
        /// Available status.
        /// </summary>
        public bool IsAvailable { get; set; } = true;

        /// <summary>
        /// Rent status.
        /// </summary>
        public bool IsRent { get; set; }
    }
}
