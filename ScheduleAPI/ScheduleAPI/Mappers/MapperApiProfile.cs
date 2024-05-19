namespace ScheduleAPI.Mappers;
using AutoMapper;
using ScheduleAPI.DTO;
using ScheduleBLL.Models;

public class MapperApiProfile : Profile
{
    public MapperApiProfile()
    {
        CreateMap<MealDTO, MealModel>().ReverseMap();
        CreateMap<ScheduleDTO, ScheduleModel>().ReverseMap();
        CreateMap<ToDoDTO, ToDoModel>().ReverseMap();
    }
}
