namespace REST_API.Models.Entities;

public class Order
{
    public Guid OrderId { get; set; }
    public Guid BakeryId { get; set; }
    public Guid UserId { get; set; }
    public required string Address { get; set; }
    public required string Type { get; set; }
    public required int Quantity { get; set; }
}

