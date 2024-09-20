using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace REST_API.Models.DTO.Order;

public class UpdateOrderDto
{
        [DefaultValue("ongoing")]
        [AllowedValuesAttribute("ongoing", "cancelled", "completed", ErrorMessage = "Type must either be ongoing, cancelled, or completed.")]
        public required string Type { get; set; }
}