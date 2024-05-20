using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleAPI.DTO;
using ScheduleBLL.Models;
using ScheduleBLL.Services.Abstractions;

namespace ScheduleAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class SchedulesController : GenericController<ScheduleModel, ScheduleDTO>
{
    public SchedulesController(IMapper mapper, IGenericService<ScheduleModel> service)
        : base(mapper, service)
    {
    }
}
