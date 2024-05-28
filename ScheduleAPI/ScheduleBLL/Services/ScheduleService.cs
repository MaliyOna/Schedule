using AutoMapper;
using ScheduleBLL.Models;
using ScheduleBLL.Services.Abstractions;
using ScheduleDAL.Entities;
using ScheduleDAL.Repositories.Abstractions;
using ScheduleDomain.Exceptions;
using static ScheduleBLL.Constants.Constants;

namespace ScheduleBLL.Services;
public class ScheduleService : GenericService<ScheduleModel, ScheduleEntity>, IScheduleService
{
    private readonly IGenericRepository<ScheduleEntity> genericRepository;

    public ScheduleService(
        IMapper mapper,
        IGenericRepository<ScheduleEntity> genericRepository)
        : base(mapper, genericRepository)
    {
        this.genericRepository = genericRepository;
    }

    public async Task CreateSchedule(ScheduleModel schedule, CancellationToken cancellationToken)
    {
        if (schedule.TimeToSleep < 7.3)
            throw new SmallValueExeption("Time to sleep should be more then 7.3 hours");

        if (schedule.TimeForRest < 1)
            throw new SmallValueExeption("Time to rest should be more then 1 hour");

        var necessaryHours = schedule.TimeToSleep * 7 + schedule.TimeForRest * 7
            + schedule.Meal.Count * 7 + schedule.ToDo.Sum(x => x.TimeInWeek);

        if (necessaryHours > hoursInWeek)
            throw new ArgumentOutOfRangeException(nameof(necessaryHours), necessaryHours, "Necessary hours should be less than hours in a week.");
    }
}
