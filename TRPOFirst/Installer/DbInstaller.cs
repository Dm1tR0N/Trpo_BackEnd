using TRPOFirst.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace TRPOFirst.Installer;

/// <summary>
/// Методы расширения с более удобный внедрением реализации контекста
/// </summary>
public static class DbInstaller
{
    public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        // services.AddDbContext<DataContext>(options =>
        //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        // services.AddDefaultIdentity<IdentityUser>()
        //     .AddEntityFrameworkStores<DataContext>();
        services.AddSingleton<IDoctorService, DoctorService>();
    }
}