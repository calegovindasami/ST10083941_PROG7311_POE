using System;
using System.Collections.Generic;

namespace FarmCentral.Library.Application.Models
{
    public partial class Farmer
    {
        public Farmer()
        {
            FarmerProducts = new HashSet<FarmerProduct>();
        }

        public string FarmerId { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; } = null!;

        public virtual ICollection<FarmerProduct> FarmerProducts { get; set; }
    }
}
