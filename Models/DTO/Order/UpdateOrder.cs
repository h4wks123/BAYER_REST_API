using System.ComponentModel.DataAnnotations;

namespace REST_API.Models.DTO.Order;

public class UpdateOrderDto
{
        [AllowedValuesAttribute("ongoing", "cancelled", "completed", ErrorMessage = "Type must either be ongoing, cancelled, or completed.")]
        public required string Type { get; set; }
}