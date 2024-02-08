using Microsoft.EntityFrameworkCore;

namespace SimpleAPI;

//I guess this class works as a bridge between what we want to have in our DB and the code
public class SystemTaskContext : DbContext
{
    public SystemTaskContext(DbContextOptions<SystemTaskContext> options)
        : base(options)
    {
    }

    public DbSet<UserModel> Users { get; set; }
    public DbSet<TaskModel> Tasks { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new TaskMap());
        base.OnModelCreating(modelBuilder);
    }
}
