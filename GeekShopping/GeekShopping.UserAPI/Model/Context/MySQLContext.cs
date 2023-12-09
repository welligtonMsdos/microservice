using Microsoft.EntityFrameworkCore;

namespace GeekShopping.UserAPI.Model.Context;

public class MySQLContext : DbContext
{
    public MySQLContext() { }

    public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {        
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            UserName = "welligton",
            Password = "Admin123%",
            Role = "admin"
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 2,
            UserName = "joao",
            Password = "Joao123%",
            Role = "client"
        });

        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 3,
            UserName = "maria",
            Password = "Maria123%",
            Role = "client"
        });
    }
}
