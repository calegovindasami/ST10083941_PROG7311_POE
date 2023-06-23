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
        [Display(Name = "Price per Unit")]
        [Range(1, 1000000)]
        public decimal PricePerUnit { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [MaxLength(64)]
        [Display(Name = "Product Name")]
        public string ProductName { get; set; } = null!;
        [Required]
        [MaxLength(64)]
        [Display(Name = "Product Type")]
        public string ProductType { get; set; } = null!;
        [Required]
        [Display(Name = "Date Added")]
        public DateTime? DateAdded { get; set; }
    }
}
