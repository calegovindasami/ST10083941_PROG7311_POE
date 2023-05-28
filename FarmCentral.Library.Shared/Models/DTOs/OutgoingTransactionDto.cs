using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Shared.Models.DTOs
{
    public class OutgoingTransactionDto
    {
        public int OutgoingTransactionId { get; set; }
        public int FarmerProductId { get; set; }
        public string FarmerId { get; set; } = null!;
        public decimal SaleAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string BuyerName { get; set; } = null!;
    }
}
