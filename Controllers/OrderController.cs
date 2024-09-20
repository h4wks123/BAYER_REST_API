using REST_API.Data;

using REST_API.Models.DTO.Order;
using REST_API.Models.DTO.Users;
using REST_API.Models.DTO.Bakery;

using REST_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace REST_API.Controllers;

// <summary> controller for orders which defines api calls </summary>
[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
    // <summary> Context for accessing order, bakery, and user data in the database. </summary>
    private readonly OrderContext _orderContext;
    private readonly BakeryContext _bakeryContext;
    private readonly UserContext _userContext;

    // <summary> Constructor for the OrderContext, BakeryContext, and UserContext. </summary>
    public OrderController(OrderContext orderContext, BakeryContext bakeryContext, UserContext userContext)
    {
        _orderContext = orderContext;
        _bakeryContext = bakeryContext;
        _userContext = userContext;
    }

    // <summary> controller action for getting all orders from database  </summary>
    [HttpGet("all")]
    public IActionResult GetAllOrders()
    {
        var allOrders = _orderContext.Order.ToList();
        return Ok(allOrders);
    }

    // <summary> controller action for getting all ongoing orders from database  </summary>
    [HttpGet("ongoing")]
    public IActionResult GetOngoingOrders()
    {
        var ongoingOrders = _orderContext.Order.Where(o => o.Type == "ongoing").ToList();
        return Ok(ongoingOrders);
    }

    // <summary> controller action for getting all cancelled orders from database  </summary>
    [HttpGet("cancelled")]
    public IActionResult GetCancelledOrders()
    {
        var cancelledOrders = _orderContext.Order.Where(o => o.Type == "cancelled").ToList();
        return Ok(cancelledOrders);
    }

    // <summary> controller action for getting all completed orders from database  </summary>
    [HttpGet("completed")]
    public IActionResult GetCompletedOrders()
    {
        var completedOrders = _orderContext.Order.Where(o => o.Type == "completed").ToList();
        return Ok(completedOrders);
    }

    // <summary> controller action for creating an order from database </summary>
    [HttpPost]
    public IActionResult CreateOrder(Guid userId, Guid bakeryId, AddOrderDto addOrderDto)
    {

        var food = _bakeryContext.Bakery.Find(bakeryId);
        var user = _userContext.User.Find(userId);

        if (food == null)
        {
            return NotFound("Bakery does not exist.");
        }

        if (user == null)
        {
            return NotFound("User does not exist.");
        }

        if (addOrderDto.Quantity > food.Quantity)
        {
            return BadRequest("Cannot order more than what is available.");
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

    // <summary> controller for updating order in database </summary>
    [HttpPut]
    public IActionResult UpdateOrderType(Guid OrderId, UpdateOrderDto updateOrderDTO)
    {
        var order = _orderContext.Order.Find(OrderId);

        if (order == null)
        {
            return NotFound("order Id does not exist.");
        }
        
        order.Type = updateOrderDTO.Type;
        
        _orderContext.SaveChanges();

        return Ok(order.Type);
    }

}

