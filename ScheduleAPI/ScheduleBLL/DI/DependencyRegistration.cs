using Microsoft.Extensions.DependencyInjection;
using ScheduleDAL.DI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleBLL.DI;
public static class DependencyRegistration
{
    public static void AddBLLServices(this IServiceCollection services, string? connectionString)
    {
        services.AddDALServices(connectionString);
    }
}
