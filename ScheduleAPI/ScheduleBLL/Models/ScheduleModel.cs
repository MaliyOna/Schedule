namespace ScheduleBLL.Models;
public class ScheduleModel
{
    public string Id { get; set; } = null!;
    public List<MealModel> Meal { get; set; } = new List<MealModel>();
    public List<ToDoModel> ToDo { get; set; } = new List<ToDoModel>();
    public double TimeForRest { get; set; }
    public double TimeToSleep { get; set; }
}
