using REST_API.Data;
using REST_API.Models.DTO.Bakery;
using REST_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace REST_API.Controllers;

// <summary> controller for bakery which defines api calls </summary>
[Route("api/[controller]")]
[ApiController]
public class BakeryController : ControllerBase
{

    // <summary> Context for accessing food data in the database. </summary>
    private readonly BakeryContext _bakeryContext;

    // <summary> Constructor for the BakeryController. </summary>
    public BakeryController(BakeryContext bakeryContext)
    {
        _bakeryContext = bakeryContext;
    }

    // <summary> controller action for getting all food from database  </summary>
    [HttpGet]
    [Route("AllFood")]
    public IActionResult GetAllAvailableFood()
    {
        var allFood = _bakeryContext.Bakery.ToList();

        return Ok(allFood);
    }

    // <summary> controller action for adding a food to database  </summary>
    [HttpPost]
    public IActionResult AddFood(AddBakeryDto addBakeryDto)
    {
        var bakeryEntity = new Bakery()
        {
            Name = addBakeryDto.Name,
            Description = addBakeryDto.Description,
            Quantity = addBakeryDto.Quantity,
        };

        _bakeryContext.Bakery.Add(bakeryEntity);
        _bakeryContext.SaveChanges();

        return Ok(bakeryEntity);
    }

    // <summary> controller action for deleting a food from database  </summary>
    [HttpDelete]
    public IActionResult DeleteFood(Guid bakeryId)
    {
        var food = _bakeryContext.Bakery.Find(bakeryId);

        if (food is null)
        {
            return NotFound("Food does not exist within the database");
        }

        _bakeryContext.Bakery.Remove(food);
        _bakeryContext.SaveChanges();

        return Ok($"Food {bakeryId} has been deleted successfully");
    }

    // <summary> controller for updating food in database </summary>
    [HttpPut]
    public IActionResult UpdateFood(Guid bakeryId, UpdateBakeryDto updateBakeryDto)
    {
        var food = _bakeryContext.Bakery.Find(bakeryId);

        if (food is null)
        {
            return NotFound("Food does not exist.");
        }

        food.Name = updateBakeryDto.Name;
        food.Description = updateBakeryDto.Description;
        food.Quantity = updateBakeryDto.Quantity;

        return Ok($"Food {bakeryId} has been updated successfully");
    }
}


