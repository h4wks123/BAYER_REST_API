using Microsoft.EntityFrameworkCore;
using REST_API.Models.Entities;

namespace REST_API.Data;

// <summary> Context class for interacting with the order database. </summary>
public class OrderContext : DbContext
{
    // <summary> Represents the collection of orders in the database. </summary>
    public DbSet<Order> Order { get; set; }

     // <summary> Constructor that initializes the OrderContext with the specified options. </summary>
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

}