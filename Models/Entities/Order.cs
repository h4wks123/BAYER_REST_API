using System.ComponentModel.DataAnnotations;

namespace REST_API.Models.Entities;

public class Order
{
    public Guid OrderId { get; set; }
    public Guid BakeryId { get; set; }
    public Guid UserId { get; set; }
    public required string Address { get; set; }
    [AllowedValuesAttribute("ongoing", "cancelled", "completed", ErrorMessage = "Type must either be ongoing, cancelled, or completed.")]
    public required string Type { get; set; }
    public required int Quantity { get; set; }
}

