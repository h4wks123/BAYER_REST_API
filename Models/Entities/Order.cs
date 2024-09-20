using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace REST_API.Models.Entities;

public class Order
{
    public Guid OrderId { get; set; }
    public Guid BakeryId { get; set; }
    public Guid UserId { get; set; }

    [DefaultValue("")]
    [Required(ErrorMessage = "Address cannot be empty.")]
    [StringLength(30, ErrorMessage = "Address cannot exceed 30 characters. ")]
    public required string Address { get; set; }

    [DefaultValue("ongoing")]
    [AllowedValuesAttribute("ongoing", "cancelled", "completed", ErrorMessage = "Type must either be ongoing, cancelled, or completed.")]
    public required string Type { get; set; }
    
    [DefaultValue(0)]
    [Required(ErrorMessage = "Quantity cannot be empty.")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
    public required int Quantity { get; set; }
}

