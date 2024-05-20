using AutoMapper;
using ScheduleAPI.DTO;
using ScheduleBLL.Models;
using ScheduleBLL.Services.Abstractions;

namespace ScheduleAPI.Controllers;

public class MealsController : GenericController<MealModel, MealDTO>
{
    public MealsController(IMapper mapper, IGenericService<MealModel> service)
        : base(mapper, service)
    {
    }
}
