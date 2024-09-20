using REST_API.Data;
using REST_API.Models.DTO.Users;
using REST_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace REST_API.Controllers;

// <summary> controller for users which defines api calls  </summary>
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    // <summary> Context for accessing user data in the database. </summary>
    private readonly UserContext _userContext;

    // <summary> Constructor for the UsersController. </summary>
    public UsersController(UserContext userContext)
    {
        _userContext = userContext;
    }

    // <summary> controller action for getting all users from database  </summary>
    [HttpGet]
    [Route("AllUsers")]
    public IActionResult GetAllUsers()
    {
        var allUsers = _userContext.User.ToList();

        return Ok(allUsers);
    }

    // <summary> controller action for adding a user to database  </summary>
    [HttpPost]
    public IActionResult AddUser(AddUserDto addUserDto)
    {
        var userEntity = new User()
        {
            Name = addUserDto.Name,
            Email = addUserDto.Email,
            Password = addUserDto.Password,
        };

        _userContext.User.Add(userEntity);
        _userContext.SaveChanges();

        return Ok(userEntity);
    }

    // <summary> controller action for deleting a user from database  </summary>
    [HttpDelete]
    public IActionResult DeleteUsers(Guid userId)
    {
        var user = _userContext.User.Find(userId);

        if (user is null)
        {
            return NotFound();
        }

        _userContext.User.Remove(user);
        _userContext.SaveChanges();

        return Ok($"User {userId} has been deleted successfully");
    }

    // <summary> controller for updating user in database </summary>
    [HttpPut]
    public IActionResult UpdateUserType(Guid userId, UpdateUserDto updateUserDto)
    {
        var user = _userContext.User.Find(userId);

        if (user is null)
        {
            return NotFound("User does not exist.");
        }

        user.Name = updateUserDto.Name;
        user.Email = updateUserDto.Email;

        _userContext.SaveChanges();

        return Ok($"User {userId} has been updated successfully");
    }

}


