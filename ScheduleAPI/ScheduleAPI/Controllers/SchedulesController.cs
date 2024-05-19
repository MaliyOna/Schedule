using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.DTO;
using ScheduleBLL.Abstraction;
using ScheduleBLL.Models;

namespace ScheduleAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SchedulesController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IScheduleService scheduleService;

    public SchedulesController(IMapper mapper, IScheduleService scheduleService)
    {
        this.mapper = mapper;
        this.scheduleService = scheduleService;
    }

    [HttpPost]
    public async Task CreateSchedule(ScheduleDTO scheduleDTO, CancellationToken cancellationToken)
    {
        var model = mapper.Map<ScheduleModel>(scheduleDTO);

        await scheduleService.CreateSchedule(model, cancellationToken);
    }
}
