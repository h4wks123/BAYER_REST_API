using Microsoft.EntityFrameworkCore;
using REST_API.Models.Entities;

namespace REST_API.Data;
public class UserContext : DbContext
{
    public DbSet<User> User { get; set; }
    
    // <summary> constructor initializes the UserContext with the options that determine how the context behaves and connects to the database </summary>
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

    // <summary> every user spawns with type customer as a safety net outside of controller logic </summary>
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //      modelBuilder.Entity<User>()
    //         .Property(u => u.Type)
    //         .HasDefaultValue("customer"); 
    // }
 
}
