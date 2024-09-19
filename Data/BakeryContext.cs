using Microsoft.EntityFrameworkCore;
using REST_API.Models.Entities;

namespace REST_API.Data;
public class BakeryContext : DbContext
{
    public DbSet<Bakery> Bakery { get; set; }

    // <summary> constructor initializes the BakeryContext with the options that determine how the context behaves and connects to the database </summary>
    public BakeryContext(DbContextOptions<BakeryContext> options) : base(options)
    {
    }

}