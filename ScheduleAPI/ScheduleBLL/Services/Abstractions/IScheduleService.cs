using ScheduleBLL.Models;

namespace ScheduleBLL.Services.Abstractions;
public interface IScheduleService : IGenericService<ScheduleModel>
{
    Task CreateSchedule(ScheduleModel schedule, CancellationToken cancellationToken);
}
