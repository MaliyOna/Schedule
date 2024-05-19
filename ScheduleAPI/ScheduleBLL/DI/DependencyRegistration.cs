using Microsoft.Extensions.DependencyInjection;
using ScheduleBLL.Services.Abstractions;
using ScheduleBLL.Services;
using ScheduleDAL.DI;
using ScheduleBLL.Models;
using ScheduleDAL.Entities;

namespace ScheduleBLL.DI;
public static class DependencyRegistration
{
    public static void AddBLLServices(this IServiceCollection services, string? connectionString)
    {
        services.AddScoped<IGenericService<MealModel>, GenericService<MealModel, MealEntity>>();
        services.AddScoped<IGenericService<ScheduleModel>, GenericService<ScheduleModel, ScheduleEntity>>();
        services.AddScoped<IGenericService<ToDoModel>, GenericService<ToDoModel, ToDoEntity>>();
        services.AddDALServices(connectionString);
    }
}
