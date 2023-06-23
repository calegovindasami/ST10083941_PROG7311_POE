using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Shared.Models.DTOs
{
    public class ProductTypeDto
    {
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; } = null!;
    }
}
