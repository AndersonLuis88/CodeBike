using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using CodeBikeAPI.DataAccess.Models.Abstract;

namespace CodeBikeAPI.DataAccess.Models
{
    
    public class Bike : BaseModel
    {
      
        [Required]
        public string Name { get; set; }

        
        [Required]
        public BikeType Type { get; set; }

        
        [Required]
        public decimal RentCost { get; set; }

     
        public bool IsAvailable { get; set; } = true;

        
        public bool IsRent { get; set; }
    }
}
