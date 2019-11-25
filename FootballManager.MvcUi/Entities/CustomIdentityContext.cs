using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FootballManager.MvcUi.Entities
{
    public class CustomIdentityContext:IdentityDbContext<CustomIdentityUser,CustomIdentityRole,string>
    {
        public CustomIdentityContext(DbContextOptions<CustomIdentityContext> options):base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=tcp:avanceretprog.database.windows.net,1433;Initial Catalog=AvanceretProgrammering;Persist Security Info=False;User ID=Sisqo;Password=Menekse1-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
