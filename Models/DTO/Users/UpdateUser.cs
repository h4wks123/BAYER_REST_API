using System.ComponentModel.DataAnnotations;

namespace REST_API.Models.DTO.Users;

public class UpdateUserDto
{
    [Required(ErrorMessage = "Name cannot be empty.")]
    [StringLength(20, ErrorMessage = "Name cannot exceed 20 characters. ")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Email cannot be empty.")]
    [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters. ")]
    [EmailAddress(ErrorMessage = "Email must have a valid format.")]
    public required string Email { get; set; }

}