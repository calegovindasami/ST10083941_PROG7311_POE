using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Shared.Models.DTOs
{
    public class FarmerProductDto
    {
        public int FarmerProductId { get; set; }
        public string FarmerId { get; set; } = null!;
        [Required]
         
        public decimal PricePerUnit { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [MaxLength(64)]
        public string ProductName { get; set; } = null!;
        [Required]
        public DateTime? DateAdded { get; set; }
    }
}
