﻿namespace ScheduleDAL.Entities;
public class ScheduleEntity : BaseEntity
{
    public List<MealEntity> MealEntities { get; set; } = new List<MealEntity>();
    public List<ToDoEntity> ToDoEntities { get; set; } = new List<ToDoEntity>();
    public string TimeForRest { get; set; } = null!;
}
