using FarmCentral.Library.Shared.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Shared.Contracts
{
    //Authentication interface to register, login and logout
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(string email, string password);
        Task<string?> RegisterAsync(RegistrationRequest request);
        Task Logout();
    }
}
