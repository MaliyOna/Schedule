namespace ScheduleDAL;
using Microsoft.EntityFrameworkCore;
using ScheduleDAL.Entities;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        
    }

    public DbSet<MealEntity> Meals { get; set; }
    public DbSet<ScheduleEntity> Schedules { get; set; }
    public DbSet<ToDoEntity> ToDos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}
