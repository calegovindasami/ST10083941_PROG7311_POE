using FarmCentral.Library.Shared.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Shared.Identity
{
    //UNUSED
    public interface IFarmerService
    {
        Task<List<Farmer>> GetFarmers();

        Task<Farmer> GetFarmer(string id);
    }
}
