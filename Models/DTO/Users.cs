namespace REST_API.Models.DTO;

public class AddUserDto
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
}