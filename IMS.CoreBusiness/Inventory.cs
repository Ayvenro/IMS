﻿using System.ComponentModel.DataAnnotations;

namespace IMS.CoreBusiness
{
    public class Inventory
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be greater or equal to 0")]
        public int Quantity { get; set; }
		[Range(0, int.MaxValue, ErrorMessage = "Price must be greater or equal to 0")]
		public decimal Price { get; set; }
    }
}
