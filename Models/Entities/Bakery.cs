namespace REST_API.Models.Entities;
public class Bakery
{
    public Guid BakeryId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Quantity { get; set; }

}

