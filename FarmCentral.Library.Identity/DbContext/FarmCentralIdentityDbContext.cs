using FarmCentral.Library.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Identity.DbContext
{
    public class FarmCentralIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public FarmCentralIdentityDbContext(DbContextOptions<FarmCentralIdentityDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(FarmCentralIdentityDbContext).Assembly);
        }
    }
}
