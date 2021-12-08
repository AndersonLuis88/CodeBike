using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using CodeBikeAPI.DataAccess.Models.Abstract;

namespace CodeBikeAPI.DataAccess.Models
{
    /// Informações sobre a bike
    public class Bike : BaseModel
    {
        
        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string Name { get; set; }

        
        [Required]
        [Column(TypeName = "nvarchar(40)")]
        public string Type { get; set; }

        /// Custo do aluguel
        [Required]
        [Column(TypeName = "decimal(18,0)")]
        public decimal RentCost { get; set; }

       
        [Column(TypeName = "bit")]
        public bool IsAvailable { get; set; } = true;

      
        [Column(TypeName = "bit")]
        public bool IsRent { get; set; }
    }
}
