using FootballManager.Bll.Abstract;
using FootballManager.Bll.Concrete;
using FootballManager.Dal.Abstract;
using FootballManager.Dal.Concrete.EntityFramework;
using FootBallManager.Entities.Abstract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FootballManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddScoped<IAdressesService, AdressManager>();
            services.AddScoped<IAdressDal, EfAdresstDal>();
            services.AddScoped<ICoachService, CoachManager>();
            services.AddScoped<ICoachDal, EfCoachtDal>();
            services.AddScoped<ICoachSkillService, CoachSkillManager>();
            services.AddScoped<ICoachSkillsDal, EfCoachSkillDal>();
            services.AddScoped<IDescriptionService, DescriptionManager>();
            services.AddScoped<IDescriptionDal, EfDescriptionDal>();
            services.AddScoped<INationService, NationManager>();
            services.AddScoped<INationDal, EfNationDal>();
            services.AddScoped<IPlayerService, PlayerManager>();
            services.AddScoped<IPlayerDal, EfPlayerDal>();
            services.AddScoped<IPlayerSkillService, PlayerSkillManager>();
            services.AddScoped<IPlayerSkillDal, EfPlayerSkillDal>();
            services.AddScoped<IPostalcodeService, PostalcodeManager>();
            services.AddScoped<IPostalcodeDal, EfPostalcodeDal>();
            services.AddScoped<IStadiumService, StadiumManager>();
            services.AddScoped<IStadiumDal, EfStadiumDal>();
            services.AddScoped<ITeamService, TeamManager>();
            services.AddScoped<ITeamDal, EfTeamDal>();
            services.AddScoped<ITrophyService, TrophyManager>();
            services.AddScoped<ITrophyDal, EfTrophyDal>();
            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDal, EfUserDal>();

            services.AddScoped<IMatchesService, MatchesManager>();
            services.AddScoped<IMatchesDal, EfMatchesDal>();

            services.AddScoped<ISeasonService, SeasonManager>();
            services.AddScoped<ISeasonDal, EfSeasonDal>();
            services.AddScoped<ILeagueService, LeagueManager>();
            services.AddScoped<ILeagueDal, EfLeagueDal>();

            services.AddScoped<ILeagueTeamService, LeagueTeamManager>();
            services.AddScoped<ILeagueTeamDal, EfLeagueTeamDal>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
