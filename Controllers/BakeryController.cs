using REST_API.Data.Context;
using REST_API.Models.DTO.Bakery;
using REST_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace REST_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BakeryController : ControllerBase
{
    private readonly BakeryContext _bakeryContext;

    public BakeryController(BakeryContext bakeryContext)
    {
        _bakeryContext = bakeryContext;
    }


    [HttpGet]
    public IActionResult GetAllAvailableFood()
    {
        var allFood = _bakeryContext.Bakery.ToList();

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


        _bakeryContext.Bakery.Add(bakeryEntity);
        _bakeryContext.SaveChanges();

        return Ok(bakeryEntity);
    }

    [HttpDelete]
    [Route("{bakeryId:guid}")]
    public IActionResult DeleteFood(Guid bakeryId)
    {
        var food = _bakeryContext.Bakery.Find(bakeryId);

        if (food is null)
        {
            return NotFound("Food does not exist within the database");
        }

        _bakeryContext.Bakery.Remove(food);
        _bakeryContext.SaveChanges();

        return Ok();
    }

    [HttpPut]
    [Route("{bakeryId:guid}")]
    public IActionResult UpdateFood(Guid bakeryId, UpdateBakeryDto updateBakeryDto)
    {
        var food = _bakeryContext.Bakery.Find(bakeryId);

        if (food is null)
        {
            return BadRequest("Food does not exist.");
        }

        food.Name = updateBakeryDto.Name;
        food.Description = updateBakeryDto.Description;
        food.Quantity = updateBakeryDto.Quantity;

        return Ok(food.Name + food.Description + food.Description);
    }
}


