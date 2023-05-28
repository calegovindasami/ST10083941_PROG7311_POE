using System;
using System.Collections.Generic;

namespace FarmCentral.Library.Application.Models
{
    public partial class OutgoingTransaction
    {
        public int OutgoingTransactionId { get; set; }
        public int FarmerProductId { get; set; }
        public string FarmerId { get; set; } = null!;
        public decimal SaleAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string BuyerName { get; set; } = null!;

        public virtual Farmer Farmer { get; set; } = null!;
        public virtual FarmerProduct FarmerProduct { get; set; } = null!;
    }
}
