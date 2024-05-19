using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScheduleDAL.Entities;
using ScheduleDAL.Repositories;
using ScheduleDAL.Repositories.Abstractions;

namespace ScheduleDAL.DI;
public static class DependencyRegistration
{
    public static void AddDALServices(this IServiceCollection services, string? connectionString)
    {
        services.AddScoped<IGenericRepository<MealEntity>, GenericRepository<MealEntity>>();
        services.AddScoped<IGenericRepository<ScheduleEntity>, GenericRepository<ScheduleEntity>>();
        services.AddScoped<IGenericRepository<ToDoEntity>, GenericRepository<ToDoEntity>>();

        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    }
}
