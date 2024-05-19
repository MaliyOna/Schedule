namespace ScheduleBLL.Mappers;
using AutoMapper;
using ScheduleBLL.Models;
using ScheduleDAL.Entities;

public class MapperBLLProfile : Profile
{
    public MapperBLLProfile()
    {
        CreateMap<MealModel, MealEntity>().ReverseMap();
        CreateMap<ScheduleModel, ScheduleEntity>().ReverseMap();
        CreateMap<ToDoModel, ToDoEntity>().ReverseMap();
    }
}
