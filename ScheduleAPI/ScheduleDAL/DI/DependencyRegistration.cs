using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ScheduleDAL.DI;
public static class DependencyRegistration
{
    public static void AddDALServices(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    }
}
