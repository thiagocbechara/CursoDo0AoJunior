using Banco.Domain.Factories;
using Banco.Domain.Repositories;
using Banco.Infra.Db;
using Banco.Infra.Factories;
using Banco.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Banco.Infra.DependenceInjectionExtesion
{
    public static class InfraDependenceInjectionExtension
    {
        public static IServiceCollection AddBancoInfra(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DatabaseConnection")));

            services.AddScoped<IContaRepository, ContaRepository>();
            services.AddSingleton<IContaFactory, ContaFactory>();
            return services;
        }
    }
}
