using ScheduleAPI.Mappers;
using ScheduleBLL.DI;
using ScheduleBLL.Mappers;

namespace ScheduleAPI.DI;

public static class DependencyRegistration
{
    public static void AddApiServices(this IServiceCollection services, string? connectionString)
    {
        services.AddAutoMapper(typeof(MapperApiProfile).Assembly, typeof(MapperBLLProfile).Assembly);

        services.AddBLLServices(connectionString);
    }
}
