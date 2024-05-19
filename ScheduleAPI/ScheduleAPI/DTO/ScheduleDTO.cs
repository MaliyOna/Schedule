namespace ScheduleAPI.DTO;

public class ScheduleDTO
{
    public string Id { get; set; } = null!;
    public List<MealDTO> Meal { get; set; } = new List<MealDTO>();
    public List<ToDoDTO> ToDo { get; set; } = new List<ToDoDTO>();
    public string TimeForRest { get; set; } = null!;
}
