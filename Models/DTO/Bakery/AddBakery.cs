using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace REST_API.Models.DTO.Bakery;

public class AddBakeryDto
{
    [DefaultValue("")]
    [Required(ErrorMessage = "Name cannot be empty.")]
    [StringLength(25, ErrorMessage = "Name cannot exceed 25 characters. ")]
    public required string Name { get; set; }

    [DefaultValue("")]
    [Required(ErrorMessage = "Description cannot be empty.")]
    [StringLength(75, ErrorMessage = "Name cannot exceed 75 characters. ")]
    public required string Description { get; set; }

    [DefaultValue(0)]
    [Required(ErrorMessage = "Quantity cannot be empty.")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0.")]
    public required int Quantity { get; set; }

}

