using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ECommercyModels.DTOs
{
    public class ProductDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Descripton { get; set; }
        public bool ShopFavorites { get; set; }
        public bool CustomerFavorites { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a Category")]
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}