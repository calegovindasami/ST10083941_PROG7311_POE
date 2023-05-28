using System;
using System.Collections.Generic;

namespace FarmCentral.API.Identity.Models
{
    public partial class Product
    {
        public Product()
        {
            FarmerProducts = new HashSet<FarmerProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;

        public virtual ICollection<FarmerProduct> FarmerProducts { get; set; }
    }
}
