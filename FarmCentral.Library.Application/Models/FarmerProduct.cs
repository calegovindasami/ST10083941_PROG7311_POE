using System;
using System.Collections.Generic;

namespace FarmCentral.Library.Application.Models
{
    public partial class FarmerProduct
    {
        public FarmerProduct()
        {
            OutgoingTransactions = new HashSet<OutgoingTransaction>();
        }

        public int FarmerProductId { get; set; }
        public string FarmerId { get; set; } = null!;
        public decimal PricePerUnit { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }

        public virtual Farmer Farmer { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<OutgoingTransaction> OutgoingTransactions { get; set; }
    }
}
