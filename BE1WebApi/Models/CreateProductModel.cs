using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BE1WebApi.Models
{
    public class CreateProductModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; } = "";

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; } = "";


    }
}
