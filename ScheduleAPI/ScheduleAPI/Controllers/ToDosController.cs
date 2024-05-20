using AutoMapper;
using ScheduleAPI.DTO;
using ScheduleBLL.Models;
using ScheduleBLL.Services.Abstractions;

namespace ScheduleAPI.Controllers;

public class ToDosController : GenericController<ToDoModel, ToDoDTO>
{
    public ToDosController(IMapper mapper, IGenericService<ToDoModel> service)
        : base(mapper, service)
    {
    }
}
