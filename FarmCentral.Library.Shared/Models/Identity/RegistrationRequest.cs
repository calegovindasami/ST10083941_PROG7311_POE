using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Shared.Models.Identity
{
    public class RegistrationRequest
    {
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; } = null!;
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        [DataType(DataType.Password)]
        [StringLength(64, MinimumLength = 6)]
        public string Password { get; set; } = null!;

        [MaxLength(64)]
        public string? Address { get; set; }

        public string Role { get; set; } = null!;
    }
}
