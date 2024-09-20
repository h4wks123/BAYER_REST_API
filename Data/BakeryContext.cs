using Microsoft.EntityFrameworkCore;
using REST_API.Models.Entities;

namespace REST_API.Data;

// <summary> Context class for interacting with the bakery database. </summary>
public class BakeryContext : DbContext
{
    // <summary> Represents the collection of foods in the database. </summary>
    public DbSet<Bakery> Bakery { get; set; }

    // <summary> Constructor that initializes the BakeryContext with the specified options. </summary>
    public BakeryContext(DbContextOptions<BakeryContext> options) : base(options)
    {
    }

}