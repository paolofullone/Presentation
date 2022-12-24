using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Presentation.Domain.Interfaces;
using Presentation.Infra.Data.Context;
using Presentation.Infra.Data.Repository;

namespace CleanArchMvc.Infra.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("MSSqlConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            // segudo Macoratti a recomendação para aplicações web é AddScoped
            services.AddScoped<IPersonRepository, PersonRepository>();

            return services;

        }
    }
}