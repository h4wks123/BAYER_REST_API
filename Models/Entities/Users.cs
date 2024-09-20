using System.ComponentModel.DataAnnotations;

namespace REST_API.Models.Entities;
public class User
{
    public Guid UserId { get; set; }
    
    public required string Name { get; set; }

    [EmailAddress(ErrorMessage = "Email must be a valid email address.")]
    public required string Email { get; set; }
    public required string Password { get; set; }
}

