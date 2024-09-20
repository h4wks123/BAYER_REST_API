using REST_API.Data.Context;
using REST_API.Models.DTO.Users;
using REST_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace REST_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly UserContext _userContext;

    public UsersController(UserContext userContext)
    {
        _userContext = userContext;
    }


    [HttpGet]
    public IActionResult GetAllUsers()
    {
        var allUsers = _userContext.User.ToList();

        return Ok(allUsers);
    }


    [HttpPost]
    public IActionResult AddCustomer(AddUserDto addUserDto)
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

    [HttpDelete]
    [Route("{userId:guid}")]
    public IActionResult DeleteUsers(Guid userId)
    {
        var user = _userContext.User.Find(userId);

        if (user is null)
        {
            return NotFound();
        }

        _userContext.User.Remove(user);
        _userContext.SaveChanges();

        return Ok();
    }

    [HttpPut]
    [Route("{userId:guid}")]
    public IActionResult UpdateOrderType(Guid userId, UpdateUserDto updateUserDto)
    {
        var user = _userContext.User.Find(userId);

        if (user is null)
        {
            return NotFound("User does not exist.");
        }

        user.Name = updateUserDto.Name;
        user.Email = updateUserDto.Email;

        _userContext.SaveChanges();

        return Ok(user.Name + user.Email);
    }

}


