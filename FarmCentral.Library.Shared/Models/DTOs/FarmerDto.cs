using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Shared.Models.DTOs
{
    public class FarmerDto
    {
        public string FarmerId { get; set; } = null!;
        [Required]
        [MaxLength(64)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(64)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } = null!;
        [Required]
        [MaxLength(64)]
        public string? Address { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }
        [Required]
        [MaxLength(64)]
        public string Email { get; set; } = null!;
    }
}
