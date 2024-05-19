namespace ScheduleDAL.Entities;
public class ToDoEntity : BaseEntity
{
    public string Title { get; set; } = null!;
    public string TimeInWeek { get; set; } = null!;
}
