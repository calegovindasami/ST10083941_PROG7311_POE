using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Shared.Models.DTOs
{
    public class FarmerProductDto
    {
        public int FarmerProductId { get; set; }
        public string FarmerId { get; set; } = null!;
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public int ProductName { get; set; }
        public DateTime? DateAdded { get; set; }
    }
}
