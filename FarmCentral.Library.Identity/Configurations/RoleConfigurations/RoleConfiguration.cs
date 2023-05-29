using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmCentral.Library.Identity.Configurations.RoleConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            //Generates the in database when adding migration.
            builder.HasData
            (
                new IdentityRole
                {
                    Id = "b44f89d8-f20e-4c50-a7ff-87bbb103e9a6",
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE"
                },
                new IdentityRole
                {
                    Id = "25d25043-76d9-41f5-8a50-63640f4ce078",
                    Name = "Farmer",
                    NormalizedName = "FARMER"
                }
            );
        }
    }
}
