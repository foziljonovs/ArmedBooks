using ArmedBooks.BBL.Services;
using ArmedBooks.DAL.Data.Contexts;
using ArmedBooks.Web.Services;
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

    public static IServiceCollection AddServices(
        this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IImageService, ImageService>();

        return services;
    }
}
