namespace REST_API.Models.DTO;

public class AddOrderDto
{
    public Guid BakeryId { get; set; }
    public Guid UserId { get; set; }
    public required string Address { get; set; }
    public required string Type { get; set; }
    public required int Quantity { get; set; }
}

