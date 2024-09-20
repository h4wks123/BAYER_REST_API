namespace REST_API.Models.DTO.Bakery;
public class UpdateBakeryDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required int Quantity { get; set; }
}

