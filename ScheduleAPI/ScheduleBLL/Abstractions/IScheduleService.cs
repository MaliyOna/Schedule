using ScheduleBLL.Models;

namespace ScheduleBLL.Abstraction;
public interface IScheduleService
{
    Task CreateSchedule(ScheduleModel scheduleModel, CancellationToken cancellationToken);
}
