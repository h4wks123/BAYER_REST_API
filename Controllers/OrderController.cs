using REST_API.Data;
using REST_API.Models.DTO;
using REST_API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BAYER_REST_API.Controllers
{

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

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var allOrders = _orderContext.Order.ToList();

            return Ok(allOrders);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(AddOrderDto addOrderDto)
        {

            var food = await _bakeryContext.Bakery.FindAsync(addOrderDto.BakeryId);
            var user = await _userContext.User.FindAsync(addOrderDto.UserId);
            
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

            return Ok(order);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderType(Guid id, [FromBody] UpdateOrderTypeDto updateOrderTypeDto)
        {
            var order = await _orderContext.Orders.FindAsync(id);
            
            if (order == null)
            {
                return NotFound("Order not found.");
            }

            if (updateOrderTypeDto.Type != "ongoing" && updateOrderTypeDto.Type != "cancelled" && updateOrderTypeDto.Type != "completed")
            {
                return BadRequest("Invalid order type. Must be ongoing, cancelled, or completed.");
            }

            order.Type = updateOrderTypeDto.Type;

            await _orderContext.SaveChangesAsync();

            return Ok(order);
        }

    }

}
