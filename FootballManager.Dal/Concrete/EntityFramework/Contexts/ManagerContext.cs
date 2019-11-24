using FootBallManager.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace FootballManager.Dal.Concrete.EntityFramework.Contexts
{
   public class ManagerContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:avanceretprog.database.windows.net,1433;Initial Catalog=AvanceretProgrammering;Persist Security Info=False;User ID=Sisqo;Password=Menekse1-;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<CoachSkill> CoachSkills { get; set; }
        public DbSet<Description> Descriptions { get; set; }
        public DbSet<Nation> Nations { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerSkill> PlayerSkills { get; set; }
        public DbSet<Postalcode> Postalcodes { get; set; }
        public DbSet<Stadium> Stadiums { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Trophy> Trophies { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
