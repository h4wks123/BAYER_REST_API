using REST_API.Data;
using REST_API.Models.DTO;
using REST_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYER_REST_API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BakeryController : ControllerBase
    {
        private readonly BakeryContext dbContext;

        public BakeryController(BakeryContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAllAvailableFood()
        {
            var allFood = dbContext.Bakery.ToList();

            return Ok(allFood);
        }


        [HttpPost]
        public IActionResult AddFood(AddBakeryDto addBakeryDto)
        {
            var bakeryEntity = new Bakery()
            {
                Name = addBakeryDto.Name,
                Description = addBakeryDto.Description,
                Quantity = addBakeryDto.Quantity,
            };

            // <summary> use case so chef cannot add empty food </summary>
            if (addBakeryDto.Quantity < 1)
            {
                return BadRequest("Food cannot be empty");
            }

            
            dbContext.Bakery.Add(bakeryEntity);
            dbContext.SaveChanges();

            return Ok(bakeryEntity);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public IActionResult DeleteFood(Guid id)
        {
            var food = dbContext.Bakery.Find(id);

            if (food is null)
            {
                return NotFound("Food does not exist within the database");
            }

            dbContext.Bakery.Remove(food);
            dbContext.SaveChanges();

            return Ok();
        }

    }

}
