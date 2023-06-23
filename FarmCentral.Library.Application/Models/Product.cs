using System;
using System.Collections.Generic;

namespace FarmCentral.Library.Application.Models
{
    public partial class Product
    {
        public Product()
        {
            FarmerProducts = new HashSet<FarmerProduct>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public int? ProductTypeId { get; set; }

        public virtual ProductType? ProductType { get; set; }
        public virtual ICollection<FarmerProduct> FarmerProducts { get; set; }
    }
}
