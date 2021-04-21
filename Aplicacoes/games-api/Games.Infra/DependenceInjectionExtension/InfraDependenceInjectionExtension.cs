using Games.Infra.Db;
using Games.Infra.Repository.Implementations;
using Games.Infra.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Games.Infra.DependenceInjectionExtension
{
    public static class InfraDependenceInjectionExtension
    {
        public static IServiceCollection AddGameInfra(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));

            services.AddScoped<IGameResultRepository, GameResultRepository>();
            services.AddScoped<ILeaderboardRepository, LeaderboardRepository>();

            return services;
        }
    }
}
