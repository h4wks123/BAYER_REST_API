using REST_API.Data.Context;

using REST_API.Models.DTO.Order;
using REST_API.Models.DTO.Users;
using REST_API.Models.DTO.Bakery;

using REST_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace REST_API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    private readonly OrderContext _orderContext;
    private readonly BakeryContext _bakeryContext;
    private readonly UserContext _userContext;
    public OrderController(OrderContext orderContext, BakeryContext bakeryContext, UserContext userContext)
    {
        _orderContext = orderContext;
        _bakeryContext = bakeryContext;
        _userContext = userContext;
    }

    [HttpGet("all")]
    public IActionResult GetAllOrders()
    {
        var allOrders = _orderContext.Order.ToList();
        return Ok(allOrders);
    }

    [HttpGet("ongoing")]
    public IActionResult GetOngoingOrders()
    {
        var ongoingOrders = _orderContext.Order.Where(o => o.Type == "ongoing").ToList();
        return Ok(ongoingOrders);
    }

    [HttpGet("cancelled")]
    public IActionResult GetCancelledOrders()
    {
        var cancelledOrders = _orderContext.Order.Where(o => o.Type == "cancelled").ToList();
        return Ok(cancelledOrders);
    }

    [HttpGet("completed")]
    public IActionResult GetCompletedOrders()
    {
        var completedOrders = _orderContext.Order.Where(o => o.Type == "completed").ToList();
        return Ok(completedOrders);
    }


    [HttpPost]
    [Route("createOrder")]
    public IActionResult CreateOrder(Guid userId, Guid bakeryId, AddOrderDto addOrderDto)
    {

        var food = _bakeryContext.Bakery.Find(bakeryId);
        var user = _userContext.User.Find(userId);

        if (food == null)
        {
            return BadRequest("Bakery does not exist.");
        }

        if (user == null)
        {
            return BadRequest("User does not exist.");
        }

        if (addOrderDto.Quantity > food.Quantity)
        {
            return BadRequest("Cannot order more than what is available.");
        }

        if (addOrderDto.Quantity <= 0)
        {
            return BadRequest("Must order an existing meal.");
        }

        var order = new Order()
        {
            BakeryId = addOrderDto.BakeryId,
            UserId = addOrderDto.UserId,
            Address = addOrderDto.Address,
            Type = "ongoing",
            Quantity = addOrderDto.Quantity,
        };

        food.Quantity -= addOrderDto.Quantity;
        _orderContext.Order.Add(order);
        _orderContext.SaveChanges();
        _bakeryContext.SaveChanges();

        return Ok(order);

    }

    [HttpPut]
    [Route("OrderType")]
    public IActionResult UpdateOrderType(Guid OrderId, UpdateOrderDto updateOrderDTO)
    {
        var order = _orderContext.Order.Find(OrderId);

        if (order == null)
        {
            return BadRequest("order Id does not exist.");
        }
        
        order.Type = updateOrderDTO.Type;
        
        _orderContext.SaveChanges();

        return Ok(order.Type);
    }

}

