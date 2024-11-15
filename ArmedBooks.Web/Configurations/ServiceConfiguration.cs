using ArmedBooks.DAL.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ArmedBooks.Web.Configurations;

public static class ServiceConfiguration
{
    public static IServiceCollection AddContext(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("localhost");

        services.AddDbContext<AppDbContext>(options
            => options.UseNpgsql(connectionString));

        return services;
    }
}
