using Microsoft.EntityFrameworkCore;
using SoftKartGoWire;
using SoftKartGoWire.Startup;

public static class Startup
{
    public static void RegisterDbServices(this WebApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("PrimaryDatabase");
        builder.Services.AddDbContext<KartingContext>(options => options.UseSqlServer(connectionString));
        builder.Services.AddDatabaseDeveloperPageExceptionFilter();
    }

    public static void BootstrapDbOnStartup(this IHost webAppHost)
    {
        using var scope = webAppHost.Services.CreateScope();

        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<KartingContext>();
            DbInitializer.Initialize(context);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred creating the DB.");
        }
    }

}
