using Microsoft.EntityFrameworkCore;
using REST_API.Models.Entities;

namespace REST_API.Data;

// <summary> Context class for interacting with the user database. </summary>
public class UserContext : DbContext
{
    // <summary> Represents the collection of users in the database. </summary>
    public DbSet<User> User { get; set; }

    // <summary> Constructor that initializes the UserContext with the specified options. </summary>
    public UserContext(DbContextOptions<UserContext> options) : base(options)
    {
    }

}
