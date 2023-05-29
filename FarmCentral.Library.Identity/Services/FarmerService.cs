using FarmCentral.Library.Identity.Models;
using FarmCentral.Library.Shared.Identity;
using FarmCentral.Library.Shared.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Identity.Services
{
    //UNUSED SERVICE.
    public class FarmerService : IFarmerService
    {

        private readonly UserManager<ApplicationUser> _userManager;

        public FarmerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<Farmer> GetFarmer(string id)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);
            
            Farmer farmer = new()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Address = user.Address!
            };
            return farmer;
        }

        public async Task<List<Farmer>> GetFarmers()
        {
            IList<ApplicationUser>? users = await _userManager.GetUsersInRoleAsync("Farmer");

            List<Farmer> farmers = users.Select(x => new Farmer()
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Address = x.Address!
            }).ToList();

            return farmers;
            
        }
    }
}
