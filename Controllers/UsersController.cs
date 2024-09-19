using REST_API.Data;
using REST_API.Models.DTO;
using REST_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYER_REST_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserContext dbContext;

        public UsersController(UserContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var allUsers = dbContext.User.ToList();

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

            dbContext.User.Add(userEntity);
            dbContext.SaveChanges();

            return Ok(userEntity);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteUsers(Guid id)
        {
            var user = dbContext.User.Find(id);

            if (user is null)
            {
                return NotFound();
            }

            dbContext.User.Remove(user);
            dbContext.SaveChanges();

            return Ok();
        }

    }

}
