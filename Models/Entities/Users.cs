using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace REST_API.Models.Entities;

public class User
{
    public Guid UserId { get; set; }

    [DefaultValue("")]
    [Required(ErrorMessage = "Name cannot be empty.")]
    [StringLength(20, ErrorMessage = "Name cannot exceed 20 characters. ")]
    public required string Name { get; set; }

    [DefaultValue("example@gmail.com")]
    [Required(ErrorMessage = "Email cannot be empty.")]
    [StringLength(30, ErrorMessage = "Name cannot exceed 30 characters. ")]
    [EmailAddress(ErrorMessage = "Email must have a valid format.")]
    public required string Email { get; set; }

    [DefaultValue("")]
    [Required(ErrorMessage = "Password cannot be empty.")]
    [StringLength(20, ErrorMessage = "Password cannot exceed 20 characters. ")]
    public required string Password { get; set; }
}

