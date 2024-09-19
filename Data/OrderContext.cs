using Microsoft.EntityFrameworkCore;
using REST_API.Models.Entities;

namespace REST_API.Data;
public class OrderContext : DbContext
{
    public DbSet<Order> Order { get; set; }

    // <summary> constructor initializes the BakeryContext with the options that determine how the context behaves and connects to the database </summary>
    public OrderContext(DbContextOptions<OrderContext> options) : base(options)
    {
    }

}